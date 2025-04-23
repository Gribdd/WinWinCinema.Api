using WinWinCinema.Api.Repositories.Interfaces;

namespace WinWinCinema.Api.Repositories;

public class CompletedOrderRepository : GenericRepository<CompletedOrder>, ICompletedOrderRepository
{
    public CompletedOrderRepository(ApplicationDbContext context) : base(context)
    {
    }
}
