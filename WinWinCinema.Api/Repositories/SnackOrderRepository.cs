using WinWinCinema.Api.Repositories.Interfaces;

namespace WinWinCinema.Api.Repositories;

public class SnackOrderRepository : GenericRepository<SnackOrder>, ISnackOrderRepository
{
    public SnackOrderRepository(ApplicationDbContext context) : base(context)
    {
    }
}
