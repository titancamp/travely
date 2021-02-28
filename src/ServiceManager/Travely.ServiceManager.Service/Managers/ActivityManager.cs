using AutoMapper;
using System;
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
            var activityType = await _unitOfWork.ActivityTypeRepository.GetActivityTypeAsync(activity.Type.AgencyId, activity.Type.ActivityName);
            if (activityType == null)
            {
                activityType = await _unitOfWork.ActivityTypeRepository.CreateAsync(_mapper.Map<ServiceManagerDb.ActivityType>(activity.Type));
            }

            ServiceManagerDb.Activity activityEntity;
            if (activityType.Id != 0)
            {
                activityEntity = await _unitOfWork.ActivityRepository.GetActivityAsync(activityType.AgencyId, activity.Name, activityType.Id);
                if (activityEntity != null) { throw new InvalidOperationException(); }
            }

            activityEntity = _mapper.Map<ServiceManagerDb.Activity>(activity);
            activityEntity.ActivityType = activityType;

            var createdActivity = await _unitOfWork.ActivityRepository.CreateAsync(activityEntity);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<Activity>(createdActivity);
        }

        public async Task<IEnumerable<Activity>> GetActivitiesAsync(long agencyId)
        {
            var activities = await _unitOfWork.ActivityRepository.GetAllActivitiesAsync(agencyId);
            return _mapper.Map<List<Activity>>(activities);
        }

        public async Task DeleteActivityAsync(long activityId)
        {
            await _unitOfWork.ActivityRepository.DeleteAsync(activityId);
            await _unitOfWork.SaveAsync();
        }

        public Activity EditActivity(Activity activity)
        {
            var activityEntity = _mapper.Map<ServiceManagerDb.Activity>(activity);
            _unitOfWork.ActivityRepository.Update(activityEntity);
            _unitOfWork.Save();
            return activity;
        }

        public async Task<List<ActivityType>> SearchActivityTypesAsync(long agenctId, string activityTypeName)
        {
            var activityTypes = await _unitOfWork.ActivityTypeRepository.SearchActivityTypesAsync(agenctId, activityTypeName);
            return _mapper.Map<List<ActivityType>>(activityTypes);
        }
    }
}
