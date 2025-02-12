using CommunityToolkit.Mvvm.ComponentModel;

namespace WinWinCinema.UI.Models
{
    public partial class User : ObservableObject
    {
        [ObservableProperty]
        private int _id;

        [ObservableProperty]
        private string _fname;

        [ObservableProperty]
        private string _lname;

        [ObservableProperty]
        private string _email;

        [ObservableProperty]
        private int _mobile;

        [ObservableProperty]
        private int _password;

        [ObservableProperty]
        private DateTime _birthdate;
    }
}
