
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using WinWinCinema.ApiClient;
using WinWinCinema.UI.Models;

namespace WinWinCinema.UI.ViewModels
{
    public partial class MainPageViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<User> _users = new();

        private readonly ApiClientService _apiClientService;
        public MainPageViewModel(ApiClientService apiClientService)
        {
            _apiClientService = apiClientService;
        }

        public async void LoadUsers()
        {
            var users = await _apiClientService.GetUsersAsync();

            Users = new ObservableCollection<User>(
            users.Select(apiUser => new User
            {
                Id = apiUser.Id,
                Fname = apiUser.Fname,
                Lname = apiUser.Lname,
                Email = apiUser.Email,
                Mobile = apiUser.Mobile,
                Password = apiUser.Password,
                Birthdate = apiUser.BirthDate
            })
        );
        }
    }
}
