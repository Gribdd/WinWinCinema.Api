using WinWinCinema.Api.Domain;
using WinWinCinema.Api.UnitOfWork;

namespace WinWinCinema.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SnacksController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public SnacksController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Snacks
        [HttpGet]
        public async Task<IActionResult> GetSnacks()
        {
            var snacks = await _unitOfWork.SnackRepository.GetAllAsync();
            return Ok(snacks);
        }

        // GET: api/Snacks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Snack>> GetSnack(Guid id)
        {
            var snack = await _unitOfWork.SnackRepository.GetByIdAsync(id);
            return snack == null ? NotFound() : Ok(snack);
        }


        // POST: api/Snacks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Snack>> PostSnack(Snack snack)
        {
            await _unitOfWork.SnackRepository.AddAsync(snack);
            await _unitOfWork.SaveAsync();
            return CreatedAtAction(nameof(GetSnack), new { id = snack.Id }, snack);
        }

    }
}
