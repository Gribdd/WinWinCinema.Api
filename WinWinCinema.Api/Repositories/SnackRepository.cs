using WinWinCinema.Api.Repositories.Interfaces;

namespace WinWinCinema.Api.Repositories;

public class SnackRepository : GenericRepository<Snack>, ISnackRepository
{
    public SnackRepository(ApplicationDbContext context) : base(context)
    {
    }
}
