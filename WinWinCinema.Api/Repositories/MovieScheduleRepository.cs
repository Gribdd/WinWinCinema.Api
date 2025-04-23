using WinWinCinema.Api.Repositories.Interfaces;

namespace WinWinCinema.Api.Repositories;

public class MovieScheduleRepository : GenericRepository<MovieSchedule>, IMovieScheduleRepository
{
    public MovieScheduleRepository(ApplicationDbContext context) : base(context)
    {
    }
}
