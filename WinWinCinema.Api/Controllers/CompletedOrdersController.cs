using WinWinCinema.Api.UnitOfWork;

namespace WinWinCinema.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompletedOrdersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public CompletedOrdersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/CompletedOrders
        [HttpGet]
        public async Task<IActionResult> GetCompletedOrders()
        {
            var completedOrders = await _unitOfWork.CompletedOrderRepository
                .GetAllWithIncludesAsync(co => co.Schedule);
            return Ok(completedOrders);
        }

        // GET: api/CompletedOrders/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCompletedOrder(Guid id)
        {
            var completedOrder = await _unitOfWork.CompletedOrderRepository.GetByIdAsync(id);
            return completedOrder == null ? NotFound() : Ok(completedOrder);
        }

        // POST: api/CompletedOrders
        [HttpPost]
        public async Task<IActionResult> PostCompletedOrder(CompletedOrder completedOrder)
        {
            await _unitOfWork.CompletedOrderRepository.AddAsync(completedOrder);
            await _unitOfWork.SaveAsync();
            return CreatedAtAction(nameof(GetCompletedOrder), new { id = completedOrder.Id }, completedOrder);
        }
    }
}
