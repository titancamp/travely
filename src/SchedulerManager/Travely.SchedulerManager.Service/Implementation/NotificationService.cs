using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using Travely.SchedulerManager.Common.Enums;
using Travely.SchedulerManager.Repository;
using Travely.SchedulerManager.Repository.Entities;

namespace Travely.SchedulerManager.Service
{
    public class NotificationService : INotificationService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IMessageCompiler _messageCompiler;
        private readonly IScheduleInfoRepository _scheduleRepository;
        private readonly IScheduleJobRepository _scheduleJobRepository;
        private readonly IScheduledAsyncJobService<NotificationJobParameter> _scheduledJobService;
        private readonly IMapper _mapper;

        public NotificationService(INotifierService notifierService,
                                          IScheduleInfoRepository scheduleRepository,
                                          IScheduleJobRepository scheduleJobRepository,
                                          IScheduledAsyncJobService<NotificationJobParameter> scheduledJobService,
                                          IMapper mapper)
        {
            _scheduleRepository = scheduleRepository;
            _scheduleJobRepository = scheduleJobRepository;
            _scheduledJobService = scheduledJobService;
            _scheduleJobRepository = scheduleJobRepository;
            _mapper = mapper;
        }

        public async Task<NotificationModel> GetNotification(long scheduleId)
        {
            var scheduleInfo = await _scheduleRepository.FindAsync(scheduleId);
            var compiledMessage = await _messageCompiler.Compile(scheduleInfo.ScheduleMessageTemplate.Template, scheduleInfo.JsonData);
            //TODO-Question: Include Users
            return new NotificationModel()
            {
                UserIds = scheduleInfo.UserSchedules.Select(s => s.UserId).ToList(),
                Module = scheduleInfo.Module,
                Message = compiledMessage,
                RecurseId = scheduleInfo.RecurseId
            };
        }

        public async Task<IEnumerable<NotificationModel>> GetAllNotifications()
        {
            var entities = await _scheduleRepository.GetListAsync(n => true);
            var dtos = _mapper.Map<List<NotificationModel>>(entities);
            //TODO-Question:  Include Users in model ?
            return dtos;
        }

        public Task<bool> CreateNotification<T>(T model) where T : INotificationModel
        {
            //TODO: add mapping in automapper
            var mapModel = _mapper.Map<CreateNotificationModel>(model);
            return CreateNotification(mapModel);
        }


        public Task UpdateNotification<T>(T model) where T : INotificationModel
        {
            //TODO: add mapping in automapper
            var mapModel = _mapper.Map<UpdateNotificationModel>(model);
            return UpdateNotification(mapModel);
        }

        public async Task DeleteNotification(long scheduleId)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                _scheduleRepository.Remove(scheduleId);
                await _scheduleRepository.SaveAsync();

                var jobIds = (await _scheduleJobRepository.GetJobIdsAsync(scheduleId)).ToList();
                var removeTasks = jobIds.Select(id => _scheduledJobService.EndJobAsync(id));
                await Task.WhenAll(removeTasks);
            }
        }

        #region Private methods

        private async Task<bool> CreateNotification(CreateNotificationModel model)
        {
            #region Create Schedule

            //TODO: It will be better to use automapper.
            var entity = new ScheduleInfo
            {
                RecurseId = model.RecurseId,
                Module = model.Module,
                ExpirationDate = model.ExpirationDate,
                MessageTemplateId = (long)model.MessageTemplate,
                JsonData = model.JsonData,
                UserSchedules = model.UserIds.Select(id => new UserSchedule()
                {
                    UserId = id,
                    Status = NotificationStatus.None
                }).ToList()
            };

            await _scheduleRepository.AddAsync(entity);
            await _scheduleRepository.SaveAsync();

            #endregion

            #region Create Jobs for schedule

            //TODO: Store job fire interval in DB or in some configuration file
            var jobDates = new List<int> { 2, 10, 15 };
            var createdJobs = new List<ScheduleJob>();
            foreach (var date in jobDates)
            {
                var fireDate = entity.ExpirationDate.AddDays(-date);
                var jobId = await _scheduledJobService.StartJobAsync(new NotificationJob(_serviceProvider), //TODO-Question: Why we create new obj?
                                                                     //TODO: Change this logic when Hangfire will change parameter type to DateTime.
                                                                     fireDate - DateTime.Now,
                                                                     new NotificationJobParameter
                                                                     {
                                                                         ScheduleId = entity.Id
                                                                     });
                createdJobs.Add(new ScheduleJob()
                {
                    JobId = jobId,
                    FireDate = fireDate,
                });
            }

            #endregion

            #region Save created jobs data

            entity.ScheduleJobs = createdJobs;
            return await this._scheduleRepository.SaveAsync();

            #endregion
        }

        private async Task UpdateNotification(UpdateNotificationModel model)
        {
            using var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);

            //find resource from db
            var entity = await _scheduleRepository.FindAsync(model.RecurseId, true);
            var jobs = await _scheduleJobRepository.GetJobIdsAsync(entity.Id);

            //update all fields in db
            _mapper.Map(model, entity);
            await this._scheduleRepository.SaveAsync();

            //end job
            var removeTasks = jobs.Select(id => _scheduledJobService.EndJobAsync(id));
            await Task.WhenAll(removeTasks);

            //TODO: Store job fire interval in DB or in some configuration file
            var jobDates = new List<int> { 2, 10, 15 };
            var createdJobs = new List<ScheduleJob>();
            //TODO: start updated job

            entity.ScheduleJobs = createdJobs;
            await this._scheduleRepository.SaveAsync();

            scope.Complete();
        }

        #endregion
        

        public async Task<bool> SetStatus(long scheduleInfoId)
        {
            throw new NotImplementedException();
        }
    }
}