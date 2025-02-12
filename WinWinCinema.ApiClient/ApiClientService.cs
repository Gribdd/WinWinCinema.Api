using System.   Net.Http.Json;
using WinWinCinema.ApiClient.Models;
using WinWinCinema.ApiClient.Models.ApiModels;

namespace WinWinCinema.ApiClient
{
    public class ApiClientService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUserAddress = "api/User";
        public ApiClientService(ApiClientOptions clientOptions)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new System.Uri(clientOptions.ApiBaseAddress);
        }

        public async Task<List<User>?> GetUsersAsync()  
        {
            return await _httpClient.GetFromJsonAsync<List<User>>(_baseUserAddress);
        }

        public async Task<User?> GetUserById(int id)
        {
            return await _httpClient.GetFromJsonAsync<User?>($"{_baseUserAddress}/{id}");
        }

        public async Task AddUser (User user)
        {
            await _httpClient.PostAsJsonAsync(_baseUserAddress, user);
        }

        public async Task UpdateUser(User user)
        {
            await _httpClient.PutAsJsonAsync(_baseUserAddress, user);
        }

        public async Task DeleteUser(int id)
        {
            await _httpClient.DeleteAsync($"{_baseUserAddress}/{id}");
        }
    }
}
