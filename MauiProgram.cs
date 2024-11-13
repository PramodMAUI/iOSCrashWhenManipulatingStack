using Microsoft.Extensions.Logging;

namespace iOSNavStackRemoveCrash
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

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<FirstPage>();
            builder.Services.AddSingleton<SecondPage>();
            builder.Services.AddSingleton<ThirdPage>();
            builder.Services.AddSingleton<ViewModels.MainViewModel>();
            builder.Services.AddSingleton<ViewModels.FirstViewModel>();
            builder.Services.AddSingleton<ViewModels.SecondViewModel>();
            builder.Services.AddSingleton<ViewModels.ThirdViewModel>();

            Routing.RegisterRoute(nameof(FirstPage), typeof(FirstPage));
            Routing.RegisterRoute(nameof(SecondPage), typeof(SecondPage));
            Routing.RegisterRoute(nameof(ThirdPage), typeof(ThirdPage));

            return builder.Build();
        }
    }
}
