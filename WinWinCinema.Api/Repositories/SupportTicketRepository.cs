using WinWinCinema.Api.Domain.SupportTickets;
using WinWinCinema.Api.Repositories.Interfaces;

namespace WinWinCinema.Api.Repositories;

public class SupportTicketRepository : GenericRepository<SupportTicket>, ISupportTicketRepository
{
    public SupportTicketRepository(ApplicationDbContext context) : base(context)
    {
    }
}
