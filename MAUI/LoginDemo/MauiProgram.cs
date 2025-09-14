using Microsoft.Extensions.Logging;
using LoginDemo.Services;
using LoginDemo.Views;
using LoginDemo.ViewModels;
using CommunityToolkit.Maui;

namespace LoginDemo
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            // Services
            builder.Services.AddSingleton<IUserService, UserService>();


            // ViewModels
            builder.Services.AddTransientWithShellRoute<HomePageView,HomePageViewModel>("HomePage");
            return builder.Build();
        }
    }
}
