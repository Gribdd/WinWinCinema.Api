using WinWinCinema.Api.UnitOfWork;

namespace WinWinCinema.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CinemasController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public CinemasController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Cinemas
        [HttpGet]
        public async Task<IActionResult> GetCinemas()
        {
            var cinemas = await _unitOfWork.CinemaRepository
                .GetAllWithIncludesAsync(c => c.Barangay, c => c.City);
            return Ok(cinemas);
        }

        // GET: api/Cinemas/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCinema(Guid id)
        {
            var cinema = await _unitOfWork.CinemaRepository.GetByIdAsync(id);
            return cinema == null ? NotFound() : Ok(cinema);
        }

        // POST: api/Cinemas
        [HttpPost]
        public async Task<IActionResult> PostCinema(Cinema cinema)
        {
            await _unitOfWork.CinemaRepository.AddAsync(cinema);
            await _unitOfWork.SaveAsync();
            return CreatedAtAction(nameof(GetCinema), new { id = cinema.Id }, cinema);
        }
    }
}
