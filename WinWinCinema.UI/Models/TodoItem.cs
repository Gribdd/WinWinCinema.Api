using CommunityToolkit.Mvvm.ComponentModel;

namespace WinWinCinema.UI.Models
{
    public partial class TodoItem : ObservableObject
    {
        [ObservableProperty]
        private int _id;

        [ObservableProperty]
        private string _name;

        [ObservableProperty]
        private string _notes;
        
        [ObservableProperty]
        private bool _done;
    }
}
