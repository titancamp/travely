using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using AutoMapper;
using Travely.SchedulerManager.Common.Enums;
using Travely.SchedulerManager.Repository;
using Travely.SchedulerManager.Repository.Entities;

namespace Travely.SchedulerManager.Service
{
    public class NotificationService : INotificationService
    {
        private readonly IMapper _mapper;
        private readonly IMessageCompiler _messageCompiler;
        private readonly IScheduledAsyncJobService<NotificationJobParameter> _scheduledJobService;
        private readonly IScheduleJobRepository _scheduleJobRepository;
        private readonly IUserScheduleRepository _userSchedule;
        private readonly IScheduleInfoRepository _scheduleRepository;
        private readonly IServiceProvider _serviceProvider;

        public NotificationService(INotifierService notifierService,
            IScheduleInfoRepository scheduleRepository,
            IScheduleJobRepository scheduleJobRepository,
            IUserScheduleRepository userSchedule,
            IMessageCompiler messageCompiler,
            IScheduledAsyncJobService<NotificationJobParameter> scheduledJobService,
            IMapper mapper)
        {
            _scheduleRepository = scheduleRepository;
            _scheduleJobRepository = scheduleJobRepository;
            _userSchedule = userSchedule;
            _scheduledJobService = scheduledJobService;
            _scheduleJobRepository = scheduleJobRepository;
            _messageCompiler = messageCompiler;
            _mapper = mapper;
        }

        public async Task<NotificationGeneratedModel> GetNotification(long tourId, long bookingId, MessageTemplate template)
        {
            TravelyModule module;
            long resourceId;

            if(template == MessageTemplate.BookingCancellationExpiration)
            {
                module = TravelyModule.Booking;
                resourceId = bookingId;
            }
            else
            {
                module = TravelyModule.Tour;
                resourceId = tourId;
            }

            var infoList = await _scheduleRepository.GetListAsync(s => s.RecurseId == resourceId && s.Module == module && s.MessageTemplateId == (long)template);
            var scheduleId = infoList.Single().Id;
            //TODO: new implementation
            return await GetNotification(scheduleId);
        }
        public async Task<NotificationGeneratedModel> GetNotification(long scheduleId)
        { 
            var scheduleInfo = await _scheduleRepository.FindAsync(scheduleId);
            var compiledMessage = await _messageCompiler.Compile(scheduleInfo.ScheduleMessageTemplate.Template, scheduleInfo.JsonData);
            return _mapper.Map<ScheduleInfo, NotificationGeneratedModel>(scheduleInfo, x => x.AfterMap((src, dest) => dest.Message = compiledMessage));
        }

        public async Task<IEnumerable<NotificationGeneratedModel>> GetAllNotifications()
        {
            var dtos = new List<NotificationGeneratedModel>();

            var entities = await _scheduleRepository.GetListAsync(n => true);
            foreach (var entity in entities)
            {
                var compiledMessage = await _messageCompiler.Compile(entity.ScheduleMessageTemplate.Template, entity.JsonData);
                var dto = _mapper.Map<ScheduleInfo, NotificationGeneratedModel>(entity, x => x.AfterMap((src, dest) => dest.Message = compiledMessage));
                dtos.Add(dto);
            }

            return dtos;
        }

        public Task<bool> CreateNotification<T>(T model) where T : INotificationModel
        {
            var mapModel = _mapper.Map<NotificationModel>(model);
            return CreateNotification(mapModel);
        }

        public Task<bool> UpdateNotification<T>(T model) where T : INotificationModel
        {
            var mapModel = _mapper.Map<NotificationModel>(model);
            return UpdateNotification(mapModel);
        }

        public async Task<bool> DeleteNotification(long tourId, long bookingId, MessageTemplate template)
        {
            TravelyModule module;
            long resourceId;

            if (template == MessageTemplate.BookingCancellationExpiration)
            {
                module = TravelyModule.Booking;
                resourceId = bookingId;
            }
            else
            {
                module = TravelyModule.Tour;
                resourceId = tourId;
            }

            var infoList = await _scheduleRepository.GetListAsync(s => s.RecurseId == resourceId && s.Module == module && s.MessageTemplateId == (long)template);
            var scheduleId = infoList.Single().Id;
            return await DeleteNotification(scheduleId);
        }

        public async Task<bool> DeleteNotification(long scheduleId)
        {
            using var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            _scheduleRepository.Remove(scheduleId);
            await _scheduleRepository.SaveAsync();

            var jobIds = (await _scheduleJobRepository.GetJobIdsAsync(scheduleId)).ToList();
            var removeTasks = jobIds.Select(id => _scheduledJobService.EndJobAsync(id));
            await Task.WhenAll(removeTasks);
            scope.Complete();
            return true;
        }

        public void SetNotificationStatus(NotificationStatus status, long scheduleId, params long[] userIds)
        {
            _userSchedule.MarkAs(status, scheduleId, userIds);
        }

        #region Private methods

        private async Task<bool> CreateNotification(NotificationModel model)
        {
            #region Create Schedule

            //TODO: It will be better to use automapper.
            var entity = new ScheduleInfo
            {
                RecurseId = model.RecurseId,
                Module = model.Module,
                ExpirationDate = model.ExpirationDate,
                MessageTemplateId = (long) model.MessageTemplate,
                JsonData = model.JsonData,
                UserSchedules = model.UserIds.Select(id => new UserSchedule
                {
                    UserId = id,
                    Status = NotificationStatus.None
                }).ToList()
            };

            await _scheduleRepository.AddAsync(entity);
            await _scheduleRepository.SaveAsync();

            #endregion

            #region Create jobs and save created jobs data

            var jobDays = GetJobDatesByMessageTemplate(model.MessageTemplate);
            var fireDates = jobDays.Select(d => entity.ExpirationDate.AddDays(-d));
            entity.ScheduleJobs = await StartJobs(fireDates, entity);
            return await _scheduleRepository.SaveAsync();

            #endregion
        }

        private async Task<bool> UpdateNotification(NotificationModel model)
        {
            using var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);

            //find resource from db
            var entity = await _scheduleRepository.FindAsync(model.RecurseId, true);
            var jobs = await _scheduleJobRepository.GetJobIdsAsync(entity.Id);

            //update all fields in db
            _mapper.Map(model, entity);
            await _scheduleRepository.SaveAsync();

            //end job
            var removeTasks = jobs.Select(id => _scheduledJobService.EndJobAsync(id));
            await Task.WhenAll(removeTasks);

            //start job
            var jobDays = GetJobDatesByMessageTemplate(model.MessageTemplate);
            var fireDates = jobDays.Select(d => entity.ExpirationDate.AddDays(-d));
            entity.ScheduleJobs = await StartJobs(fireDates, entity);
            var result = await _scheduleRepository.SaveAsync();

            scope.Complete();

            return result;
        }

        private IEnumerable<int> GetJobDatesByMessageTemplate(MessageTemplate template) =>
            template switch
            {
                MessageTemplate.BookingCancellationExpiration => new[] { 2, 5, 10 },
                MessageTemplate.IncompleteBookingRequests => new[] {10, 20, 30},
                MessageTemplate.TourIsApproaching => new[] {5, 10, 20},
                _ => new int[] {},
            };

        private async Task<ScheduleJob> StartJob(DateTime fireDate, ScheduleInfo entity)
        {
            var jobId = await _scheduledJobService.StartJobAsync(
                new NotificationJob(_serviceProvider), //TODO-Question: Why we create new obj?
                //TODO: Change this logic when Hangfire will change parameter type to DateTime.
                fireDate - DateTime.Now,
                new NotificationJobParameter { ScheduleId = entity.Id });

            return new ScheduleJob
            {
                JobId = jobId,
                FireDate = fireDate
            };
        }

        private async Task<List<ScheduleJob>> StartJobs(IEnumerable<DateTime> jobDates, ScheduleInfo entity)
        {
            var createdJobs = new List<ScheduleJob>();
            foreach (var date in jobDates)
            {
                var job = await StartJob(date, entity);
                createdJobs.Add(job);
            }

            return createdJobs;
        }

        #endregion
    }
}