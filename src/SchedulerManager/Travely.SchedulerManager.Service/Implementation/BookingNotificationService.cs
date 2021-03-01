using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Travely.SchedulerManager.Common.Enums;
using Travely.SchedulerManager.Repository;
using Travely.SchedulerManager.Repository.Entities;

namespace Travely.SchedulerManager.Service
{
    public class BookingNotificationService : IBookingNotificationService
    {
        private readonly INotificationService _notificationService;
        private readonly IScheduleInfoRepository _scheduleRepository;
        private readonly IEnqueueAsyncJobService<BookingNotificationParameter> _enqueueJobService;
        private readonly IScheduledAsyncJobService<BookingNotificationParameter> _scheduledJobService;
        private readonly IRecurrentAsyncJobService<BookingNotificationParameter> _recurrentJobService;
        private readonly IMapper _mapper;

        public BookingNotificationService(INotificationService notificationService,
                                          IScheduleInfoRepository scheduleRepository,
                                          IEnqueueAsyncJobService<BookingNotificationParameter> enqueueJobService,
                                          IScheduledAsyncJobService<BookingNotificationParameter> scheduledJobService,
                                          IRecurrentAsyncJobService<BookingNotificationParameter> recurrentJobService,
                                          IMapper mapper)
        {
            _notificationService = notificationService;
            _scheduleRepository = scheduleRepository;
            _enqueueJobService = enqueueJobService;
            _scheduledJobService = scheduledJobService;
            _recurrentJobService = recurrentJobService;
            _mapper = mapper;
        }


        public async Task<Notification> GetNotification(long bookingId)
        {
            var entity = (await _scheduleRepository.GetListAsync(n => n.RecurseId == bookingId))?.SingleOrDefault();
            var dto = _mapper.Map<Notification>(entity);

            return dto;
        }

        public async Task<IEnumerable<Notification>> GetAllNotifications()
        {
            var entities = await _scheduleRepository.GetListAsync(n => true);
            var dtos = _mapper.Map<List<Notification>>(entities);

            return dtos;
        }

        public async Task<bool> CreateNotification(CreateNotification create)
        {
            #region Create Schedule

            //TODO: It will be better to use automapper.
            var entity = new ScheduleInfo
            {
                RecurseId = create.RecurseId,
                Module = create.Module,
                ExpirationDate = create.ExpirationDate,
                MessageTemplateId = (long)create.MessageTemplate,
                JsonData = create.JsonData,
                UserSchedules = create.UserIds.Select(id => new UserSchedule()
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
                var jobId = await _scheduledJobService.StartJobAsync(new BookingNotificationJobManager(_notificationService),
                                                                    //TODO: Change this logic when Hangfire will change parameter type to DateTime.
                                                                     fireDate - DateTime.Now, 
                                                                     new BookingNotificationParameter
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

        public async Task<bool> UpdateNotification(UpdateNotification create)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteNotification(long bookingId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> SetStatus(long scheduleInfoId)
        {
            throw new NotImplementedException();
        }
    }
}