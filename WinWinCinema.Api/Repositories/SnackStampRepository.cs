using WinWinCinema.Api.Repositories.Interfaces;

namespace WinWinCinema.Api.Repositories;

public class SnackStampRepository : GenericRepository<SnackStamp>, ISnackStampRepository
{
    public SnackStampRepository(ApplicationDbContext context) : base(context)
    {
    }
}
