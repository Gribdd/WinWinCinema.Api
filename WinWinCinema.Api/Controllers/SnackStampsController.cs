using WinWinCinema.Api.UnitOfWork;

namespace WinWinCinema.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SnackStampsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public SnackStampsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/SnackStamps
        [HttpGet]
        public async Task<IActionResult> GetSnackStamps()
        {
            var snackStamps = await _unitOfWork.SnackStampRepository.GetAllAsync();
            return Ok(snackStamps);
        }

        // GET: api/SnackStamps/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSnackStamp(Guid id)
        {
            var snackStamp = await _unitOfWork.SnackStampRepository.GetByIdAsync(id);
            return snackStamp == null ? NotFound() : Ok(snackStamp);
        }

        // POST: api/SnackStamps
        [HttpPost]
        public async Task<IActionResult> PostSnackStamp(SnackStamp snackStamp)
        {
            await _unitOfWork.SnackStampRepository.AddAsync(snackStamp);
            await _unitOfWork.SaveAsync();
            return CreatedAtAction(nameof(GetSnackStamp), new { id = snackStamp.Id }, snackStamp);
        }
    }
}
