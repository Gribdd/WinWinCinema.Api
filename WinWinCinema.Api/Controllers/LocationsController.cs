using WinWinCinema.Api.DTOs.Request.Location;
using WinWinCinema.Api.Services.Interfaces;
using WinWinCinema.Api.UnitOfWork;

namespace WinWinCinema.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly ILocationService _locationService;

        public LocationsController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        // GET: api/Locations
        [HttpGet]
        public async Task<IActionResult> GetLocations()
        {
            var locations = await _locationService.GetAllLocationsAsync();
            return Ok(locations);
        }

        // GET: api/Locations/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLocation(Guid id)
        {
            var location = await _locationService.GetLocationByIdAsync(id);
            if (location == null)
            {
                return NotFound();
            }
            return Ok(location);
        }

        // POST: api/Locations
        [HttpPost]
        public async Task<IActionResult> PostLocation(CreateLocationRequest createLocationRequest)
        {
            var createdLocation = await _locationService.CreateLocationAsync(createLocationRequest);
            return CreatedAtAction(nameof(GetLocation), new { id = createdLocation.Id }, createdLocation);
        }
    }
}
