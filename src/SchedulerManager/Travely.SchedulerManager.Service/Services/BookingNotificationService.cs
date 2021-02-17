using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Travely.SchedulerManager.Repository.Entities;
using Travely.SchedulerManager.Repository.Infrastructure.Interfaces;

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


        public async Task<NotificationDTO> GetNotification(long bookingId)
        {
            var entity = (await _scheduleRepository.GetListAsync(n => n.RecurseId == bookingId))?.SingleOrDefault();
            var dto = _mapper.Map<NotificationDTO>(entity);

            return dto;
        }

        public async Task<IEnumerable<NotificationDTO>> GetAllNotifications()
        {
            var entities = await _scheduleRepository.GetListAsync(n => true);
            var dtos = _mapper.Map<List<NotificationDTO>>(entities);

            return dtos;
        }

        public async Task<bool> CreateNotification(CreateNotificationDTO createDTO)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateNotification(CreateNotificationDTO createDTO)
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