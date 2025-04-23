using WinWinCinema.Api.UnitOfWork;

namespace WinWinCinema.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SnackOrdersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public SnackOrdersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/SnackOrders
        [HttpGet]
        public async Task<IActionResult> GetSnackOrders()
        {
            var snackOrders = await _unitOfWork.SnackOrderRepository.GetAllAsync();
            return Ok(snackOrders);
        }

        // GET: api/SnackOrders/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSnackOrder(Guid id)
        {
            var snackOrder = await _unitOfWork.SnackOrderRepository.GetByIdAsync(id);
            return snackOrder == null ? NotFound() : Ok(snackOrder);
        }

        // POST: api/SnackOrders
        [HttpPost]
        public async Task<IActionResult> PostSnackOrder(SnackOrder snackOrder)
        {
            await _unitOfWork.SnackOrderRepository.AddAsync(snackOrder);
            await _unitOfWork.SaveAsync();
            return CreatedAtAction(nameof(GetSnackOrder), new { id = snackOrder.Id }, snackOrder);
        }
    }
}
