using WinWinCinema.Api.UnitOfWork;

namespace WinWinCinema.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieSchedulesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public MovieSchedulesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/MovieSchedules
        [HttpGet]
        public async Task<IActionResult> GetMovieSchedules()
        {
            var schedules = await _unitOfWork.MovieScheduleRepository.GetAllAsync();
            return Ok(schedules);
        }

        // GET: api/MovieSchedules/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMovieSchedule(Guid id)
        {
            var schedule = await _unitOfWork.MovieScheduleRepository.GetByIdAsync(id);
            return schedule == null ? NotFound() : Ok(schedule);
        }

        // POST: api/MovieSchedules
        [HttpPost]
        public async Task<IActionResult> PostMovieSchedule(MovieSchedule movieSchedule)
        {
            await _unitOfWork.MovieScheduleRepository.AddAsync(movieSchedule);
            await _unitOfWork.SaveAsync();
            return CreatedAtAction(nameof(GetMovieSchedule), new { id = movieSchedule.Id }, movieSchedule);
        }
    }
}
