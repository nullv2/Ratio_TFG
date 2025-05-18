using System.Text.Json;

namespace Ratio.Mobile.Services
{
    public static class AppSettingsLoader
    {
        public static async Task<Dictionary<string, Dictionary<string, string>>> LoadAsync()
        {
            using var stream = await FileSystem.OpenAppPackageFileAsync("appsettings.json");
            using var reader = new StreamReader(stream);
            var json = await reader.ReadToEndAsync();

            return JsonSerializer.Deserialize<Dictionary<string, Dictionary<string, string>>>(json)
                   ?? throw new InvalidOperationException("Failed to parse appsettings.json");
        }
    }

}
