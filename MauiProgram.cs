using Microsoft.Extensions.Logging;

namespace CRUDMaui
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
                });

            builder.Services.AddMauiBlazorWebView();
            // Registro de HttpClient
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://controwellserver-e7egh8gjhadfe0ay.brazilsouth-01.azurewebsites.net/") });

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
