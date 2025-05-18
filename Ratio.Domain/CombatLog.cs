namespace Ratio.Domain
{
    public static class CombatLog
    {
        public static bool IsEnabled { get; set; } = true;

        public static void Write(string message)
        {
            if (IsEnabled)
                Console.WriteLine(message);
        }

        public static void WriteHeader(string header)
        {
            if (IsEnabled)
            {
                Console.WriteLine();
                Console.WriteLine($"==== {header} ====");
            }
        }
    }

}
