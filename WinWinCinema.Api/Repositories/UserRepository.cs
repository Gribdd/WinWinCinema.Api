using WinWinCinema.Api.Repositories.Interfaces;

namespace WinWinCinema.Api.Repositories;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(ApplicationDbContext context) : base(context)
    {
    }
}
