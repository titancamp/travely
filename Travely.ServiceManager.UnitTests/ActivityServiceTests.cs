using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using Travely.ServiceManager.Service;
using Xunit;

namespace Travely.ServiceManager.UnitTests
{
    public class ActivityServiceTests
    {
        private readonly Mock<IActivityManager> _activityManagerMock = new Mock<IActivityManager>(MockBehavior.Strict);

        [Fact]
        public void ShouldThrowOnInvalidConstructorParameters()
        {
            // Act, Assert
            Assert.Throws<ArgumentNullException>(() => new ActivityService(null));
        }

        [Fact]
        public void ShouldNotThrowOnValidConstructorParameters()
        {
            // Act, Assert
            var _ = new ActivityService(_activityManagerMock.Object);
        }

        [Fact]
        public async Task CreateActivityShouldNotThrowForNormalFlow()
        {
            // Arrange
            _activityManagerMock.Setup(am => am.CreateActivityAsync(It.Is<Activity>(a => a != null))).ReturnsAsync(Mocks.Activity);

            var activityService = new ActivityService(_activityManagerMock.Object);

            // Act, Assert
            var _ = await activityService.CreateActivity(Mocks.Activity, null);
        }

        [Fact]
        public async Task CreateActivityShouldPassValidObjectToManager()
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
        public async Task CreateActivityShouldReturnValidObject()
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
        public async Task GetActivitiesShouldNotThrowOnNormalFlow()
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
        public async Task GetActivitiesShouldPassValidArgumentsToManager()
        {
            // Arrange
            var activityService = new ActivityService(_activityManagerMock.Object);
            var request = new GetActivitiesRequest
            {
                AgencyId = 12,
            };

            _activityManagerMock.Setup(am => am.GetActivitiesAsync(It.IsAny<int>())).ReturnsAsync(new List<Activity> { Mocks.Activity });

            // Act
            await activityService.GetActivities(request, null);

            // Assert
            _activityManagerMock.Verify(am => am.GetActivitiesAsync(It.IsAny<int>()), Times.Once);
            _activityManagerMock.Verify(am => am.GetActivitiesAsync(request.AgencyId), Times.Once);
        }

        [Fact]
        public async Task GetActivitiesShouldReturnValidActivities()
        {
            // Arrange
            var activityService = new ActivityService(_activityManagerMock.Object);
            var request = new GetActivitiesRequest
            {
                AgencyId = 12,
            };
            var activities = new List<Activity> { Mocks.Activity };

            _activityManagerMock.Setup(am => am.GetActivitiesAsync(It.IsAny<int>())).ReturnsAsync(activities);

            // Act
            var result = await activityService.GetActivities(request, null);
            var expectedResult = new Activities();
            expectedResult.Activities_.AddRange(activities);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task DeleteActivityShouldReturnValidResultForNormalFlow()
        {
            // Arrange
            var activityService = new ActivityService(_activityManagerMock.Object);
            var response = new ActivityResponse
            {
                Status = ResponseStatus.Success,
            };

            _activityManagerMock.Setup(am => am.DeleteActivityAsync(It.IsAny<long>())).ReturnsAsync(response);

            // Act
            var result = await activityService.DeleteActivity(new DeleteActivityRequest { ActivityId = 1 }, null);

            // Assert
            Assert.Equal(response, result);
        }

        [Fact]
        public async Task DeleteActivityShouldDeleteValidActivity()
        {
            // Arrange
            var activityId = 1L;
            var activityService = new ActivityService(_activityManagerMock.Object);
            var response = new ActivityResponse
            {
                Status = ResponseStatus.Success,
            };

            _activityManagerMock.Setup(am => am.DeleteActivityAsync(It.IsAny<long>())).ReturnsAsync(response);

            // Act
            var result = await activityService.DeleteActivity(new DeleteActivityRequest { ActivityId = activityId }, null);

            // Assert
            _activityManagerMock.Verify(am => am.DeleteActivityAsync(activityId), Times.Once);
            _activityManagerMock.Verify(am => am.DeleteActivityAsync(It.IsAny<long>()), Times.Once);
        }

        [Fact]
        public async Task EditActivityShouldReturnValidResultForNormalFlow()
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
        public async Task EditActivityShouldEditValidActivity()
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