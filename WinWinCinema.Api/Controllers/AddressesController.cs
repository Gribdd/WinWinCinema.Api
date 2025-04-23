using WinWinCinema.Api.UnitOfWork;

namespace WinWinCinema.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddressesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Addresses
        [HttpGet]
        public async Task<IActionResult> GetAddresses()
        {
            var addresses = await _unitOfWork.AddressRepository.GetAllAsync();
            return Ok(addresses);
        }

        // GET: api/Addresses/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAddress(Guid id)
        {
            var address = await _unitOfWork.AddressRepository.GetByIdAsync(id);
            return address == null ? NotFound() : Ok(address);
        }

        // POST: api/Addresses
        [HttpPost]
        public async Task<IActionResult> PostAddress(Address address)
        {
            await _unitOfWork.AddressRepository.AddAsync(address);
            await _unitOfWork.SaveAsync();
            return CreatedAtAction(nameof(GetAddress), new { id = address.Id }, address);
        }
    }
}
