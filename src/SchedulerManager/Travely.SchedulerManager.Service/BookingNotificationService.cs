using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Travely.SchedulerManager.Repository.Entities;
using Travely.SchedulerManager.Repository.Infrastructure.Interfaces;

namespace Travely.SchedulerManager.Service
{
    public class BookingNotificationService : IBookingNotificationService
    {
        private readonly IScheduleInfoRepository _scheduleRepository;
        private readonly IEnqueueAsyncJobService<InformationJobParameter> _enqueueJobService;
        private readonly IScheduledAsyncJobService<InformationJobParameter> _scheduledJobService;
        private readonly IRecurrentAsyncJobService<InformationJobParameter> _recurrentJobService;
        private readonly IMapper _mapper;

        public BookingNotificationService(IScheduleInfoRepository scheduleRepository,
                                          IEnqueueAsyncJobService<InformationJobParameter> enqueueJobService,
                                          IScheduledAsyncJobService<InformationJobParameter> scheduledJobService,
                                          IRecurrentAsyncJobService<InformationJobParameter> recurrentJobService,
                                          IMapper mapper)
        {
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
            //TODO hangfire call (create job for each user)

            if (true) //TODO if hangfire jobs created
            {
                var entity = _mapper.Map<ScheduleInfo>(createDTO);
                await this._scheduleRepository.AddAsync(entity);
            }

            return await this._scheduleRepository.AnyAsync(entity => entity.RecurseId == createDTO.BookingId);
        }

        public async Task<bool> UpdateNotification(CreateNotificationDTO createDTO)
        {
            //TODO hangfire call
            //TODO repo call

            return true;
        }

        public async Task<bool> DeleteNotification(long bookingId)
        {
            //TODO hangfire call
            //TODO repo call

            return true;
        }
    }
}
