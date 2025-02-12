using Microsoft.Extensions.Logging;
using WinWinCinema.ApiClient.IoC;
using WinWinCinema.UI.ViewModels;
namespace WinWinCinema.UI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            builder.Services.AddApiClientService(x => x.ApiBaseAddress = "http://10.0.2.2:5059");
            builder.Services.AddTransient<MainPageViewModel>();
#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
