using WinWinCinema.Api.DTOs.Request.Cinema;
using WinWinCinema.Api.DTOs.Response.Cinema;

namespace WinWinCinema.Api.Services.Interfaces
{
    public interface ICinemaService
    {
        Task<IEnumerable<CinemaResponse>> GetAllCinemasAsync();
        Task<CinemaResponse?> GetCinemaByIdAsync(Guid id);
        Task<CinemaResponse> CreateCinemaAsync(CreateCinemaRequest request);
        Task<bool> UpdateCinemaAsync(Guid id, UpdateCinemaRequest request);
        Task<bool> SoftDeleteCinemaAsync(Guid id);
    }
}
