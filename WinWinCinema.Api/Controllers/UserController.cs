namespace WinWinCinema.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {
            return _context.Users;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User?>> GetById(int id)
        {
            return await _context.Users
                .Where(x => x.Id == id)
                .SingleOrDefaultAsync();
        }

        [HttpPost]
        public async Task<ActionResult> CreateUser(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateUser(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            var user = await GetById(id);
            if (user == null)
            {
                return NotFound();
            }

             _context.Users.Remove(user.Value);
            await _context.SaveChangesAsync();
            return Ok();
        }

    }
}
