using WinWinCinema.Api.DTOs.Request.User;
using WinWinCinema.Api.DTOs.Response.User;
using WinWinCinema.Api.Services.Interfaces;

namespace WinWinCinema.Api.Services.Implementations
{
    public class UserService : IUserService
    {
        public Task<UserResponse> CreateUserAsync(CreateUserRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserResponse>> GetAllUsersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<UserResponse?> GetUserByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SoftDeleteUserAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateUserAsync(Guid id, UpdateUserRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
