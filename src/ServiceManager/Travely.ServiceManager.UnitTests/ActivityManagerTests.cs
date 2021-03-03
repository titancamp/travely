using System;
using System.Threading.Tasks;
using AutoMapper;
using Moq;
using Travely.ServiceManager.Abstraction.Interfaces.Repositories;
using Travely.ServiceManager.Abstraction.Interfaces.UnitOfWorks;
using Travely.ServiceManager.Service;
using Travely.ServiceManager.Service.Managers;
using Travely.ServiceManager.Service.Mappers;
using Xunit;
using ActivityDbModel = Travely.ServiceManager.Abstraction.Models.Db.Activity;
using ActivityTypeDbModel = Travely.ServiceManager.Abstraction.Models.Db.ActivityType;

namespace Travely.ServiceManager.UnitTests
{
    public class ActivityManagerTests
    {
        private readonly IMapper _mapper;
        private readonly IActivityManager _target;

        private readonly Mock<IUnitOfWork> _unitOfWorkMock = new Mock<IUnitOfWork>(MockBehavior.Strict);
        private readonly Mock<IActivityRepository> _activityRepoMock = new Mock<IActivityRepository>(MockBehavior.Strict);
        private readonly Mock<IActivityTypeRepository> _activityTypeRepoMock = new Mock<IActivityTypeRepository>(MockBehavior.Strict);

        public ActivityManagerTests()
        {
            var activityProfile = new ActivityProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(activityProfile));
            _mapper = new Mapper(configuration);

            _unitOfWorkMock.SetupGet(uow => uow.ActivityRepository).Returns(_activityRepoMock.Object);
            _unitOfWorkMock.SetupGet(uow => uow.ActivityTypeRepository).Returns(_activityTypeRepoMock.Object);

            _activityRepoMock.Setup(repo => repo.Create(It.IsAny<ActivityDbModel>()))
                .Returns<ActivityDbModel>(m => m);

            _activityTypeRepoMock.Setup(repo => repo.Create(It.IsAny<ActivityTypeDbModel>()))
                .Returns<ActivityTypeDbModel>(m => m);

            _unitOfWorkMock.Setup(uow => uow.SaveAsync()).Returns(Task.FromResult(1));

            _target = new ActivityManager(_unitOfWorkMock.Object, _mapper);
        }

        [Fact]
        public async void CreateActivity_NewActivityWithNewType_ShouldNotThrow()
        {
            // Arrange
            _activityTypeRepoMock.Setup(repo => repo.GetActivityTypeAsync(It.IsAny<long>(), It.IsAny<string>()))
                .Returns(Task.FromResult((ActivityTypeDbModel)null));

            _activityRepoMock.Setup(repo => repo.GetActivityAsync(It.IsAny<long>(), It.IsAny<string>(), It.IsAny<long>()))
                .Returns(Task.FromResult((ActivityDbModel)null));

            var activity = new Activity(Mocks.Activity)
            {
                Id = null
            };

            activity.Type.Id = null;
            // Act, Assert
            await _target.CreateActivityAsync(Mocks.Activity);
        }

        [Fact]
        public async void CreateActivity_NewActivityWithExistingType_ShouldNotThrow()
        {
            // Arrange
            _activityTypeRepoMock.Setup(repo => repo.GetActivityTypeAsync(It.IsAny<long>(), It.IsAny<string>()))
                .ReturnsAsync((long agencyId, string typeName) =>
                {
                    var activityType = new ActivityType(Mocks.ActivityType)
                    {
                        AgencyId = agencyId,
                        ActivityName = typeName
                    };

                    return _mapper.Map<ActivityTypeDbModel>(activityType);
                });

            _activityRepoMock.Setup(repo => repo.GetActivityAsync(It.IsAny<long>(), It.IsAny<string>(), It.IsAny<long>()))
                .Returns(Task.FromResult((ActivityDbModel)null));

            var activity = new Activity(Mocks.Activity)
            {
                Id = null
            };

            // Act, Assert
            await _target.CreateActivityAsync(Mocks.Activity);
        }

        [Fact]
        public async void CreateActivity_ExistingActivity_ShouldThrow()
        {
            // Arrange
            _activityTypeRepoMock.Setup(repo => repo.GetActivityTypeAsync(It.IsAny<long>(), It.IsAny<string>()))
                .ReturnsAsync((long agencyId, string typeName) =>
                {
                    var activityType = new ActivityType(Mocks.ActivityType)
                    {
                        AgencyId = agencyId,
                        ActivityName = typeName
                    };

                    return _mapper.Map<ActivityTypeDbModel>(activityType);
                });

            _activityRepoMock.Setup(repo => repo.GetActivityAsync(It.IsAny<long>(), It.IsAny<string>(), It.IsAny<long>()))
                .ReturnsAsync((long agencyId, string typeName, long activityTypeId) =>
                {
                    var activity = new Activity(Mocks.Activity);
                    activity.Type.AgencyId = agencyId;
                    activity.Type.ActivityName = typeName;
                    activity.Type.Id = activityTypeId;

                    return _mapper.Map<ActivityDbModel>(activity);
                });

            var activity = new Activity(Mocks.Activity);

            // Act, Assert
            await Assert.ThrowsAnyAsync<InvalidOperationException>(() => _target.CreateActivityAsync(Mocks.Activity));
        }

        [Fact]
        public async void CreateActivity_NewActivityWithExistingType_ShouldCreateValidActivity()
        {
            // Arrange
            _activityTypeRepoMock.Setup(repo => repo.GetActivityTypeAsync(It.IsAny<long>(), It.IsAny<string>()))
                .ReturnsAsync((long agencyId, string typeName) =>
                {
                    var activityType = new ActivityType(Mocks.ActivityType)
                    {
                        AgencyId = agencyId,
                        ActivityName = typeName
                    };

                    return _mapper.Map<ActivityTypeDbModel>(activityType);
                });

            _activityRepoMock.Setup(repo => repo.GetActivityAsync(It.IsAny<long>(), It.IsAny<string>(), It.IsAny<long>()))
                .Returns(Task.FromResult((ActivityDbModel)null));

            var activity = new Activity(Mocks.Activity)
            {
                Id = null
            };

            // Act
            await _target.CreateActivityAsync(Mocks.Activity);

            // Assert
            _activityTypeRepoMock.Verify(repo => repo.Create(It.IsAny<ActivityTypeDbModel>()), Times.Never);

            var activityModel = _mapper.Map<ActivityDbModel>(activity);
            _activityRepoMock.Verify(repo => repo.Create(It.IsAny<ActivityDbModel>()), Times.Once);

            _activityRepoMock.Verify(repo => repo.Create(It.Is<ActivityDbModel>(m =>
                m.Address == activityModel.Address &&
                m.Currency == activityModel.Currency &&
                m.ChangeUser == activityModel.ChangeUser &&
                m.ContactName == activityModel.ContactName &&
                m.EmailAddress == activityModel.EmailAddress &&
                m.ActivityTypeId == activityModel.ActivityTypeId &&
                m.ActivityType.Id == activityModel.ActivityType.Id &&
                m.ActivityType.Name == activityModel.ActivityType.Name &&
                m.ActivityType.AgencyId == activityModel.ActivityType.AgencyId)), Times.Once);
        }
    }
}