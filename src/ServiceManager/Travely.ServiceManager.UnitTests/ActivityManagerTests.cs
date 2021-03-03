using System;
using System.Linq;
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
            _unitOfWorkMock.Verify(uow => uow.SaveAsync(), Times.Once);
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
            _unitOfWorkMock.Verify(uow => uow.SaveAsync(), Times.Once);
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
            _unitOfWorkMock.Verify(uow => uow.SaveAsync(), Times.Never);
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
            var activityModel = _mapper.Map<ActivityDbModel>(activity);

            // Act
            await _target.CreateActivityAsync(Mocks.Activity);

            // Assert
            _unitOfWorkMock.Verify(uow => uow.SaveAsync(), Times.Once);
            _activityRepoMock.Verify(repo => repo.Create(It.IsAny<ActivityDbModel>()), Times.Once);
            _activityTypeRepoMock.Verify(repo => repo.Create(It.IsAny<ActivityTypeDbModel>()), Times.Never);

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

        [Fact]
        public async void GetActivities_ForValidArg_ShouldPassValidArg()
        {
            // Arrange
            var agencyId = 12L;
            var activityDbModel = _mapper.Map<ActivityDbModel>(Mocks.Activity);
            _activityRepoMock.Setup(repo => repo.GetAllActivitiesAsync(It.IsAny<long>()))
                .ReturnsAsync(Enumerable.Repeat(activityDbModel, 4).ToList());

            // Act
            await _target.GetActivitiesAsync(agencyId);

            // Assert
            _unitOfWorkMock.Verify(uow => uow.SaveAsync(), Times.Never);
            _activityRepoMock.Verify(repo => repo.GetAllActivitiesAsync(agencyId), Times.Once);
            _activityRepoMock.Verify(repo => repo.GetAllActivitiesAsync(It.IsAny<long>()), Times.Once);
        }

        [Fact]
        public async void DeleteActivity_ForValidArg_ShouldPassValidArg()
        {
            // Arrange
            var activityId = 12L;

            _activityRepoMock.Setup(repo => repo.DeleteAsync(It.IsAny<long>())).Returns(Task.CompletedTask);

            // Act
            await _target.DeleteActivityAsync(activityId);

            // Assert
            _unitOfWorkMock.Verify(uow => uow.SaveAsync(), Times.Once);
            _activityRepoMock.Verify(repo => repo.DeleteAsync(activityId), Times.Once);
        }

        [Fact]
        public async void EditActivity_ForValidArg_ShouldPassValidArg()
        {
            // Arrange
            var activityModel = _mapper.Map<ActivityDbModel>(Mocks.Activity);
            _activityRepoMock.Setup(repo => repo.Update(It.IsAny<ActivityDbModel>()));

            // Act
            await _target.EditActivityAsync(Mocks.Activity);

            // Assert
            _unitOfWorkMock.Verify(uow => uow.SaveAsync(), Times.Once);
            _activityRepoMock.Verify(repo => repo.Update(It.Is<ActivityDbModel>(m =>
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

        [Fact]
        public async void SearchActivityTypes_ForValidArg_ShouldPassValidArg()
        {
            // Arrange
            var agencyId = 12L;
            var activityTypeName = "type_name";

            var activityTypeDbModel = _mapper.Map<ActivityTypeDbModel>(Mocks.ActivityType);
            _activityTypeRepoMock.Setup(repo => repo.SearchActivityTypesAsync(It.IsAny<long>(), It.IsAny<string>()))
                .ReturnsAsync(Enumerable.Repeat(activityTypeDbModel, 4).ToList());

            // Act
            await _target.SearchActivityTypesAsync(agencyId, activityTypeName);

            // Assert
            _unitOfWorkMock.Verify(uow => uow.SaveAsync(), Times.Never);
            _activityTypeRepoMock.Verify(repo => repo.SearchActivityTypesAsync(agencyId, activityTypeName), Times.Once);
            _activityTypeRepoMock.Verify(repo => repo.SearchActivityTypesAsync(It.IsAny<long>(), It.IsAny<string>()), Times.Once);
        }
    }
}