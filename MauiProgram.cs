using BarcodeScanner.Mobile;
using iOSDisplayAlertHiddenIssue.Interfaces;
using iOSDisplayAlertHiddenIssue.Services;
using Microsoft.Extensions.Logging;

namespace iOSDisplayAlertHiddenIssue
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureMauiHandlers(handlers =>
                {
                    // Add the handlers
                    handlers.AddBarcodeScannerHandler();
                })
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
                        


#if DEBUG
            builder.Logging.AddDebug();
#endif
            builder.Services.AddSingleton<INavigationService, NavigationService>();
            builder.Services.AddSingleton<IViewFactory, ViewFactory>();

            return builder.Build();
        }
    }
}
