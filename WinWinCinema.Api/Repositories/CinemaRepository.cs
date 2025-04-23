using WinWinCinema.Api.Repositories.Interfaces;

namespace WinWinCinema.Api.Repositories;

public class CinemaRepository : GenericRepository<Cinema>, ICinemaRepository
{
    public CinemaRepository(ApplicationDbContext context) : base(context)
    {
    }
}
