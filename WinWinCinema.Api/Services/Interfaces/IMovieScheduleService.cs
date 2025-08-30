using WinWinCinema.Api.DTOs.Request.MovieSchedule;
using WinWinCinema.Api.DTOs.Response.MovieSchedule;

namespace WinWinCinema.Api.Services.Interfaces
{
    public interface IMovieScheduleService
    {
        Task<IEnumerable<MovieScheduleResponse>> GetAllMovieSchedulesAsync();
        Task<MovieScheduleResponse?> GetMovieScheduleByIdAsync(Guid id);
        Task<MovieScheduleResponse> CreateMovieScheduleAsync(CreateMovieScheduleRequest request);
        Task<bool> UpdateMovieScheduleAsync(Guid id, UpdateMovieScheduleRequest request);
        Task<bool> SoftDeleteMovieScheduleAsync(Guid id);
    }
}
