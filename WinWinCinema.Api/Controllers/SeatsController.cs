using WinWinCinema.Api.UnitOfWork;

namespace WinWinCinema.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeatsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public SeatsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Seats
        [HttpGet]
        public async Task<IActionResult> GetSeats()
        {
            var seats = await _unitOfWork.SeatRepository.GetAllAsync();
            return Ok(seats);
        }

        // GET: api/Seats/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSeat(Guid id)
        {
            var seat = await _unitOfWork.SeatRepository.GetByIdAsync(id);
            return seat == null ? NotFound() : Ok(seat);
        }

        // POST: api/Seats
        [HttpPost]
        public async Task<IActionResult> PostSeat(Seat seat)
        {
            await _unitOfWork.SeatRepository.AddAsync(seat);
            await _unitOfWork.SaveAsync();
            return CreatedAtAction(nameof(GetSeat), new { id = seat.Id }, seat);
        }
    }
}
