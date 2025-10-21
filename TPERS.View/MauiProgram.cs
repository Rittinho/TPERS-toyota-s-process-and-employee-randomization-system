using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using TPERS.View.Pages.Principal;
using TPERS.View.Services.Injections.Contract;
using TPERS.View.Services.Injections.Implementation;

namespace TPERS.View
{
    public static class MauiProgram
    {
        public static IServiceProvider ServiceProvider { get; private set; }

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

                    fonts.AddFont("FAR.otf", "FAR");
                    fonts.AddFont("FAS.otf", "FAS");
                    fonts.AddFont("FAB.otf", "FAB");
                });

#if DEBUG
    		builder.Logging.AddDebug();
            builder.Services.AddTransient<IVerificationServices,VerificationServices>();
            builder.Services.AddTransient<ProcessView>();

            var app = builder.Build();

            ServiceProvider = app.Services; 
#endif


            return app;
        }
    }
}
