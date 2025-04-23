using WinWinCinema.Api.UnitOfWork;

namespace WinWinCinema.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public MessagesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Messages
        [HttpGet]
        public async Task<IActionResult> GetMessages()
        {
            var messages = await _unitOfWork.MessageRepository.GetAllAsync();
            return Ok(messages);
        }

        // GET: api/Messages/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMessage(Guid id)
        {
            var message = await _unitOfWork.MessageRepository.GetByIdAsync(id);
            return message == null ? NotFound() : Ok(message);
        }

        // POST: api/Messages
        [HttpPost]
        public async Task<IActionResult> PostMessage(Message message)
        {
            await _unitOfWork.MessageRepository.AddAsync(message);
            await _unitOfWork.SaveAsync();
            return CreatedAtAction(nameof(GetMessage), new { id = message.Id }, message);
        }
    }
}
