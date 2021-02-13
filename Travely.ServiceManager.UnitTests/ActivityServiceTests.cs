using System;
using System.Threading.Tasks;
using Moq;
using Travely.ServiceManager.Service;
using Xunit;

namespace Travely.ServiceManager.UnitTests
{
    public class ActivityServiceTests
    {
        private Mock<IActivityManager> _activityManagerMock = new Mock<IActivityManager>();

        [Fact]
        public void ShouldThrowOnInvalidConstructorParameters()
        {
            // Act, Assert
            Assert.Throws<ArgumentException>(() => new ActivityService(null));
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
            _activityManagerMock.Setup(am => am.CreateActivityAsync(It.Is<Activity>(a => a != null))).ReturnsAsync(new Activity
            {
                Name = "ActivityName"
            });

            var activityService = new ActivityService(_activityManagerMock.Object);

            // Act
            var result = await activityService.CreateActivity(new Activity(), null);

            // Assert
            _activityManagerMock.Verify(am => am.CreateActivityAsync(It.IsAny<Activity>()));
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
            _activityManagerMock.Verify(am => am.CreateActivityAsync(It.Is<Activity>(ac => ac == Mocks.Activity)), Times.Once);
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
    }
}