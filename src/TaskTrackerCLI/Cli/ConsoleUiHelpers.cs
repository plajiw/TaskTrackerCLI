namespace TaskTrackerCLI.Cli
{
    internal static class ConsoleUiHelpers
    {

        public static void Write(string text, ConsoleColor color)
        {
            var previous = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ForegroundColor = previous;
        }
    }
}