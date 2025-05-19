using Ratio.Mobile.Services;

namespace Ratio.Mobile
{
    public partial class App : Microsoft.Maui.Controls.Application
    {
        public App(AppInitializationService appInitializationService)
        {
            InitializeComponent();
            _ = InitializeAppAsync(appInitializationService);
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new MainPage()) { Title = "Ratio.Mobile" };
        }


        private async Task InitializeAppAsync(AppInitializationService initializer)
        {
            await initializer.InitializeAsync();
        }

    }
}
