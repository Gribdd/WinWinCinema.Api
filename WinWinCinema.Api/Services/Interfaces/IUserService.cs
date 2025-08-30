using WinWinCinema.Api.DTOs.Request.User;
using WinWinCinema.Api.DTOs.Response.User;

namespace WinWinCinema.Api.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserResponse>> GetAllUsersAsync();
        Task<UserResponse?> GetUserByIdAsync(Guid id);
        Task<UserResponse> CreateUserAsync(CreateUserRequest request);
        Task<bool> UpdateUserAsync(Guid id, UpdateUserRequest request);
        Task<bool> SoftDeleteUserAsync(Guid id);
    }
}
