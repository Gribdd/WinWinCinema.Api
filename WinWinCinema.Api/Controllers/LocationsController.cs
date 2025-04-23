using WinWinCinema.Api.UnitOfWork;

namespace WinWinCinema.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public LocationsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Locations
        [HttpGet]
        public async Task<IActionResult> GetLocations()
        {
            var locations = await _unitOfWork.LocationRepository.GetAllAsync();
            return Ok(locations);
        }

        // GET: api/Locations/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLocation(Guid id)
        {
            var location = await _unitOfWork.LocationRepository.GetByIdAsync(id);
            return location == null ? NotFound() : Ok(location);
        }

        // POST: api/Locations
        [HttpPost]
        public async Task<IActionResult> PostLocation(Location location)
        {
            await _unitOfWork.LocationRepository.AddAsync(location);
            await _unitOfWork.SaveAsync();
            return CreatedAtAction(nameof(GetLocation), new { id = location.Id }, location);
        }
    }
}
