using AutoFixture;
using Microsoft.AspNetCore.Mvc;
using Moq;
using WinWinCinema.Api.Controllers;
using WinWinCinema.Api.Domain;
using WinWinCinema.Api.Repositories.Interfaces;
using WinWinCinema.Api.UnitOfWork;

namespace WinWinCinema.UnitTests
{
    public class LocationsControllerTests
    {
        [Fact]
        public void GetLocations_ShouldReturnCorrectTotal()
        {
            // Arrange 
            int expectedTotal = 10;
            var fixture = new Fixture();

            var fakeLocations = fixture
                .CreateMany<Location>(expectedTotal)
                .ToList();

            var mockUnitOfWork = new Mock<IUnitOfWork>();
            var mockLocationRepository = new Mock<ILocationRepository>();


            mockLocationRepository
                .Setup(repo => repo.GetAllAsync())
                .ReturnsAsync(fakeLocations);

            mockUnitOfWork
                .Setup(uow => uow.LocationRepository)
                .Returns(mockLocationRepository.Object);

            var controller = new LocationsController(mockUnitOfWork.Object);
           
            // Act
            var actionResult = controller.GetLocations();

            // Assert 
            var okResult = actionResult.Result as OkObjectResult;
            var returnLocations = okResult.Value as List<Location>;
            Assert.Equal(expectedTotal, returnLocations.Count);
        }
    }
}