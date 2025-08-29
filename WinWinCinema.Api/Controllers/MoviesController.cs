using WinWinCinema.Api.UnitOfWork;

namespace WinWinCinema.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public MoviesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Movies
        [HttpGet]
        public async Task<IActionResult> GetMovies()
        {
            var movies = await _unitOfWork.MovieRepository
                .GetAllWithIncludesAsync(m => m.Schedules);
            return Ok(movies);
        }

        // GET: api/Movies/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMovie(Guid id)
        {
            var movie = await _unitOfWork.MovieRepository.GetByIdAsync(id);
            return movie == null ? NotFound() : Ok(movie);
        }

        // POST: api/Movies
        [HttpPost]
        public async Task<IActionResult> PostMovie(Movie movie)
        {
            await _unitOfWork.MovieRepository.AddAsync(movie);
            await _unitOfWork.SaveAsync();
            return CreatedAtAction(nameof(GetMovie), new { id = movie.Id }, movie);
        }
    }
}
