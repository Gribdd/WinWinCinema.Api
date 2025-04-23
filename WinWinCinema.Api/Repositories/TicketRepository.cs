using WinWinCinema.Api.Repositories.Interfaces;

namespace WinWinCinema.Api.Repositories;

public class TicketRepository : GenericRepository<Ticket>, ITicketRepository
{
    public TicketRepository(ApplicationDbContext context) : base(context)
    {
    }
}
