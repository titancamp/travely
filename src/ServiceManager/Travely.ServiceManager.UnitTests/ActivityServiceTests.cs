using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using Travely.ServiceManager.Grpc;
using Travely.ServiceManager.Service;
using Xunit;

namespace Travely.ServiceManager.UnitTests
{
    public class ActivityServiceTests
    {
        private readonly Mock<IActivityManager> _activityManagerMock = new Mock<IActivityManager>(MockBehavior.Strict);

        [Fact]
        public void Ctor_NullArgumentPassed_ShouldThrowArgumentNullException()
        {
            // Act, Assert
            Assert.Throws<ArgumentNullException>(() => new ActivityService(null));
        }

        [Fact]
        public void Ctor_OnValidArgsPassed_ShouldNotThrow()
        {
            // Act, Assert
            var _ = new ActivityService(_activityManagerMock.Object);
        }

        [Fact]
        public async Task CreateActivity_OnValidArgsPassed_ShouldNotThrow()
        {
            // Arrange
            _activityManagerMock.Setup(am => am.CreateActivityAsync(It.Is<Activity>(a => a != null))).ReturnsAsync(Mocks.Activity);

            var activityService = new ActivityService(_activityManagerMock.Object);

            // Act, Assert
            var _ = await activityService.CreateActivity(Mocks.Activity, null);
        }

        [Fact]
        public async Task CreateActivity_OnValidArgsPassed_ShouldPassValidObjectToManager()
        {
            // Arrange
            var activityService = new ActivityService(_activityManagerMock.Object);

            _activityManagerMock.Setup(am => am.CreateActivityAsync(It.IsAny<Activity>())).ReturnsAsync(Mocks.Activity);

            // Act
            var result = await activityService.CreateActivity(Mocks.Activity, null);

            // Assert
            _activityManagerMock.Verify(am => am.CreateActivityAsync(It.IsAny<Activity>()), Times.Once);
            _activityManagerMock.Verify(am => am.CreateActivityAsync(Mocks.Activity), Times.Once);
        }

        [Fact]
        public async Task CreateActivity_OnValidArgsPassed_ShouldReturnValidObject()
        {
            // Arrange
            var activityService = new ActivityService(_activityManagerMock.Object);

            _activityManagerMock.Setup(am => am.CreateActivityAsync(It.IsAny<Activity>())).ReturnsAsync(Mocks.Activity);

            // Act
            var result = await activityService.CreateActivity(Mocks.Activity, null);

            // Assert
            Assert.Equal(ResponseStatus.Success, result.Status);
        }

        [Fact]
        public async Task GetActivities_OnValidArgsPassed_ShouldNotThrow()
        {
            // Arrange
            var activityService = new ActivityService(_activityManagerMock.Object);

            _activityManagerMock.Setup(am => am.GetActivitiesAsync(It.IsAny<int>())).ReturnsAsync(new List<Activity> { Mocks.Activity });

            // Act, Assert
            var _ = await activityService.GetActivities(new GetActivitiesRequest
            {
                AgencyId = 1,
            }, null);
        }

        [Fact]
        public async Task GetActivities_OnValidArgsPassed_ShouldPassValidArgumentsToManager()
        {
            // Arrange
            var activityService = new ActivityService(_activityManagerMock.Object);
            var request = new GetActivitiesRequest
            {
                AgencyId = 12,
            };

            _activityManagerMock.Setup(am => am.GetActivitiesAsync(It.IsAny<long>())).ReturnsAsync(new List<Activity> { Mocks.Activity });

            // Act
            await activityService.GetActivities(request, null);

            // Assert
            _activityManagerMock.Verify(am => am.GetActivitiesAsync(It.IsAny<long>()), Times.Once);
            _activityManagerMock.Verify(am => am.GetActivitiesAsync(request.AgencyId), Times.Once);
        }

        [Fact]
        public async Task GetActivities_OnValidArgsPassed_ShouldReturnValidActivities()
        {
            // Arrange
            var activityService = new ActivityService(_activityManagerMock.Object);
            var request = new GetActivitiesRequest
            {
                AgencyId = 12,
            };
            var activities = new List<Activity> { Mocks.Activity };

            _activityManagerMock.Setup(am => am.GetActivitiesAsync(It.IsAny<long>())).ReturnsAsync(activities);

            // Act
            var result = await activityService.GetActivities(request, null);
            var expectedResult = new Activities();
            expectedResult.Activities_.AddRange(activities);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task DeleteActivity_OnValidArgsPassed_ShouldReturnValidResult()
        {
            // Arrange
            var activityService = new ActivityService(_activityManagerMock.Object);

            _activityManagerMock.Setup(am => am.DeleteActivityAsync(It.IsAny<long>())).Returns(Task.CompletedTask);

            // Act
            var result = await activityService.DeleteActivity(new DeleteActivityRequest { ActivityId = 1 }, null);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(ResponseStatus.Success, result.Status);
        }

        [Fact]
        public async Task DeleteActivity_OnValidArgsPassed_ShouldDeleteValidActivity()
        {
            // Arrange
            var activityId = 1L;
            var activityService = new ActivityService(_activityManagerMock.Object);
            var response = new ActivityResponse
            {
                Status = ResponseStatus.Success,
            };

            _activityManagerMock.Setup(am => am.DeleteActivityAsync(It.IsAny<long>())).Returns(Task.CompletedTask);

            // Act
            var result = await activityService.DeleteActivity(new DeleteActivityRequest { ActivityId = activityId }, null);

            // Assert
            _activityManagerMock.Verify(am => am.DeleteActivityAsync(activityId), Times.Once);
            _activityManagerMock.Verify(am => am.DeleteActivityAsync(It.IsAny<long>()), Times.Once);
        }

        [Fact]
        public async Task EditActivity_OnValidArgsPassed_ShouldReturnValidResult()
        {
            // Arrange
            var activityService = new ActivityService(_activityManagerMock.Object);

            _activityManagerMock.Setup(am => am.EditActivityAsync(It.IsAny<Activity>())).ReturnsAsync(Mocks.Activity);

            // Act
            var result = await activityService.EditActivity(Mocks.Activity, null);

            // Assert
            Assert.Equal(ResponseStatus.Success, result.Status);
        }

        [Fact]
        public async Task EditActivity_OnValidArgsPassed_ShouldEditValidActivity()
        {
            // Arrange
            var activityService = new ActivityService(_activityManagerMock.Object);

            _activityManagerMock.Setup(am => am.EditActivityAsync(It.IsAny<Activity>())).ReturnsAsync(Mocks.Activity);

            // Act
            var result = await activityService.EditActivity(Mocks.Activity, null);

            // Assert
            _activityManagerMock.Verify(am => am.EditActivityAsync(Mocks.Activity), Times.Once);
            _activityManagerMock.Verify(am => am.EditActivityAsync(It.IsAny<Activity>()), Times.Once);
        }
    }
}