namespace Ratio.Mobile.Services
{
    public class AppInitializationService
    {
        private bool _isInitialized = false;
        private readonly DatabaseInitializer _databaseInitializer;

        public AppInitializationService(DatabaseInitializer databaseInitializer)
        {
            _databaseInitializer = databaseInitializer;
        }

        /// <summary>
        /// Initializes the application state. Runs only once.
        /// </summary>
        public async Task InitializeAsync()
        {
            if (_isInitialized)
                return;

            await _databaseInitializer.InitDBAsync();

            _isInitialized = true;
        }

    }
}
