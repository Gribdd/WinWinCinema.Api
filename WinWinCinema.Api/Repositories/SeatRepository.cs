using WinWinCinema.Api.Repositories.Interfaces;

namespace WinWinCinema.Api.Repositories;

public class SeatRepository : GenericRepository<Seat>, ISeatRepository
{
    public SeatRepository(ApplicationDbContext context) : base(context)
    {
    }
}
