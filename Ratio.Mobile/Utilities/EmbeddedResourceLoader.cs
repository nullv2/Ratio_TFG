namespace Ratio.Mobile.Utilities
{
    public static class MauiAssetLoader
    {
        /// <summary>
        /// Loads the specified MAUI asset as a single string.
        /// </summary>
        /// <param name="assetPath">Relative path inside Resources/Raw, e.g., "Sql/killteams.sql"</param>
        public static async Task<string> LoadAsStringAsync(string assetPath)
        {
            using var stream = await FileSystem.OpenAppPackageFileAsync(assetPath)
                ?? throw new FileNotFoundException($"Asset '{assetPath}' not found.");
            using var reader = new StreamReader(stream);
            return await reader.ReadToEndAsync();
        }

        /// <summary>
        /// Loads the specified MAUI asset as an array of non-empty trimmed lines.
        /// </summary>
        /// <param name="assetPath">Relative path inside Resources/Raw, e.g., "Sql/killteams.sql"</param>
        public static async Task<string[]> LoadAsLinesAsync(string assetPath)
        {
            var content = await LoadAsStringAsync(assetPath);
            return content
                .Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                .Where(line => !string.IsNullOrWhiteSpace(line) && !line.TrimStart().StartsWith("--"))
                .ToArray();
        }

    }
}
