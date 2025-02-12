using WinWinCinema.UI.ViewModels;

namespace WinWinCinema.UI
{
    public partial class MainPage : ContentPage
    {
        private MainPageViewModel _vm;
        public MainPage(MainPageViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
            _vm = vm;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _vm.LoadUsers();
        }


    }

}
