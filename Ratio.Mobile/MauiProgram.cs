using Microsoft.Extensions.Logging;
using Ratio.Application.Mappers;
using Ratio.Application.Repositories;
using Ratio.Application.Services;
using Ratio.Application.Services.Abstraction;
using Ratio.Infrastructure.Repositories;
using Ratio.Infrastructure.Services;
using Ratio.Mobile.Services;
using SQLite;

namespace Ratio.Mobile
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

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif

            // Register the SQLite connection as a singleton
            var dbPath = Path.Combine(FileSystem.AppDataDirectory, "ratio.db");
            builder.Services.AddSingleton(new SQLiteAsyncConnection(dbPath));

            // Register the repositories
            builder.Services.AddTransient<IKillTeamRepository, KillTeamRepository>();

            // Register the services
            builder.Services.AddScoped<SimulationStateService>();

            builder.Services.AddTransient<OperativeBuilderService>();
            builder.Services.AddTransient<OperativeMapper>();

            builder.Services.AddTransient<KillTeamCombatService>();
            builder.Services.AddTransient<IKillTeamCombatService, KillTeamCombatService>();

            builder.Services.AddTransient<DatabaseInitializer>();

            builder.Services.AddTransient<InitialInsertsService>();

            builder.Services.AddScoped<ChatStateService>();
            builder.Services.AddSingleton<AppInitializationService>();

            return builder.Build();
        }


    }
}
