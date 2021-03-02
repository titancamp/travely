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
        private readonly IActivityManager _target;

        private readonly Mock<IUnitOfWork> _unitOfWorkMock = new Mock<IUnitOfWork>(MockBehavior.Strict);
        private readonly Mock<IActivityRepository> _activityRepoMock = new Mock<IActivityRepository>(MockBehavior.Strict);
        private readonly Mock<IActivityTypeRepository> _activityTypeRepoMock = new Mock<IActivityTypeRepository>(MockBehavior.Strict);

        public ActivityManagerTests()
        {
            var activityProfile = new ActivityProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(activityProfile));
            var mapper = new Mapper(configuration);

            _unitOfWorkMock.SetupGet(uow => uow.ActivityRepository).Returns(_activityRepoMock.Object);
            _unitOfWorkMock.SetupGet(uow => uow.ActivityTypeRepository).Returns(_activityTypeRepoMock.Object);

            _target = new ActivityManager(_unitOfWorkMock.Object, mapper);
        }

        [Fact]
        public void CreateActivity_NewActivityWithNewType_ShouldNotThrow()
        {
            // TODO
        }
    }
}