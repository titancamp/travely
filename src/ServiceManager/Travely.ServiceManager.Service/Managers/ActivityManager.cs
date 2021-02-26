using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using Travely.ServiceManager.Abstraction.Interfaces.UnitOfWorks;
using ServiceManagerDb = Travely.ServiceManager.Abstraction.Models.Db;

namespace Travely.ServiceManager.Service.Managers
{
    public class ActivityManager : IActivityManager
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IMapper _mapper;

        public ActivityManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Activity> CreateActivityAsync(Activity activity)
        {
            var activityDTO = _mapper.Map<ServiceManagerDb.Activity>(activity);

            var activityType = await _unitOfWork.ActivityTypeRepository.GetActivityTypeByUniqueKeysAsync(activityDTO.ActivityType.AgencyId, activityDTO.ActivityType.Name);
            if (activityType != null)
            {
                activityDTO.ActivityType = activityType;
            }
            else
            {
                activityDTO.ActivityType = await _unitOfWork.ActivityTypeRepository.CreateAsync(activityDTO.ActivityType);
                await _unitOfWork.SaveAsync();
            }

            var activityEntity = await _unitOfWork.ActivityRepository.GetActivityByUniqueKeysAsync(activityDTO.ActivityType.AgencyId, activityDTO.Name, activityDTO.ActivityType.Id);
            if (activityEntity != null) { return null; }

            var createdActivity = await _unitOfWork.ActivityRepository.CreateAsync(activityDTO);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<Activity>(createdActivity);
        }

        public async Task<IEnumerable<Activity>> GetActivitiesAsync(long agencyId)
        {
            var activities = await _unitOfWork.ActivityRepository.GetAllActivitiesByAgencyIdAsync(agencyId);
            return _mapper.Map<List<Activity>>(activities);
        }

        public async Task DeleteActivityAsync(long activityId)
        {
            await _unitOfWork.ActivityRepository.DeleteAsync(activityId);
            await _unitOfWork.SaveAsync();
        }

        public Activity EditActivity(Activity activity)
        {
            var activityDTO = _mapper.Map<ServiceManagerDb.Activity>(activity);
            _unitOfWork.ActivityRepository.Update(activityDTO);
            return activity;
        }
    }
}
