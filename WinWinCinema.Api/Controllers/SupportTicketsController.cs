using WinWinCinema.Api.Domain.SupportTickets;
using WinWinCinema.Api.UnitOfWork;

namespace WinWinCinema.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupportTicketsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public SupportTicketsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/SupportTickets
        [HttpGet]
        public async Task<IActionResult> GetSupportTickets()
        {
            var supportTickets = await _unitOfWork.SupportTicketRepository.GetAllAsync();
            return Ok(supportTickets);
        }

        // GET: api/SupportTickets/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSupportTicket(Guid id)
        {
            var supportTicket = await _unitOfWork.SupportTicketRepository.GetByIdAsync(id);
            return supportTicket == null ? NotFound() : Ok(supportTicket);
        }

        // POST: api/SupportTickets
        [HttpPost]
        public async Task<IActionResult> PostSupportTicket(SupportTicket supportTicket)
        {
            await _unitOfWork.SupportTicketRepository.AddAsync(supportTicket);
            await _unitOfWork.SaveAsync();
            return CreatedAtAction(nameof(GetSupportTicket), new { id = supportTicket.Id }, supportTicket);
        }
    }
}
