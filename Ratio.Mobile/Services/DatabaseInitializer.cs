using Ratio.Infrastructure.Services;
using Ratio.Mobile.Utilities;

namespace Ratio.Mobile.Services
{
    public class DatabaseInitializer
    {
        // Injected somewhere in your constructor or as a property
        private readonly InitialInsertsService _initialInsertsService;

        public DatabaseInitializer(InitialInsertsService initialInsertsService)
        {
            _initialInsertsService = initialInsertsService;
        }

        /// <summary>
        /// Ordered list of asset paths to execute for seeding.
        /// </summary>
        private readonly List<string> _seedScripts = new()
        {
            "Sql/factions.sql",
            "Sql/killteams.sql"
        };

        /// <summary>
        /// KillTeams seeding script.
        /// </summary>
        private readonly List<string> _killTeamSeedScripts = new()
        {
            "Sql/KillTeams/1_vespidStingwing.sql",
            "Sql/KillTeams/2_nemesisClaw.sql",
            "Sql/KillTeams/3_wreckaKrew.sql",
            "Sql/KillTeams/4_imperialNavyBreachers.sql",
        };

        public async void InitDB()
        {

            // Check if the database is already initialized
            if (IsDatabaseInitialized())
            {
                return;
            }

            await _initialInsertsService.ResetDBAsync();

            // Execute the seed scripts
            foreach (var script in _seedScripts)
            {
                var sqlLines = await MauiAssetLoader.LoadAsLinesAsync(script);
                await _initialInsertsService.ExecuteSeedScriptAsync(sqlLines);
            }
            // Execute the kill team seed scripts
            foreach (var script in _killTeamSeedScripts)
            {
                var sqlLines = await MauiAssetLoader.LoadAsLinesAsync(script);
                await _initialInsertsService.ExecuteSeedScriptAsync(sqlLines);
            }

            // Mark the database as initialized
            MarkDatabaseInitialized();
        }

        /// <summary>
        /// Checks if the database is already initialized.
        /// </summary>
        /// <returns>True if the database is initialized, false otherwise.</returns>
        private bool IsDatabaseInitialized()
        {
            bool isInitialized = Preferences.Get("DbInitialized", false);
            return isInitialized;
        }

        /// <summary>
        /// Marks the database as initialized.
        /// </summary>
        private void MarkDatabaseInitialized()
        {
            Preferences.Set("DbInitialized", true);
        }
    }
}
