using AutoFixture;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using WinWinCinema.Api.Domain;
using WinWinCinema.Api.Mappings;
using WinWinCinema.Api.Services.Implementations; 
using WinWinCinema.Api.UnitOfWork;

namespace WinWinCinema.UnitTests.Services
{
    public class LocationsServicesTests
    {
        [Fact]
        public async Task GetLocations_ShouldReturnCorrectTotal()
        {
            // Arrange 
            int expectedTotal = 10;
            var fixture = new Fixture();

            var fakeLocations = fixture
                .CreateMany<Location>(expectedTotal)
                .ToList();

            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork
                .Setup(uow => uow.LocationRepository.GetAllAsync())
                .ReturnsAsync(fakeLocations);


            var mapper = new MapperConfiguration(cfg => {
                cfg.AddProfile<LocationProfile>();
            }, new LoggerFactory()).CreateMapper();


            var locationService = new LocationService(mockUnitOfWork.Object, mapper);

            // Act
            var result = await locationService.GetAllLocationsAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedTotal, result.Count());
        }
              
    }
}