namespace TaskTrackerCLI.Cli;

public class ConsoleUi
{
    public static void ShowWelcome()
    {
        Console.Clear();
        WriteLine("Welcome to Task Tracker CLI!!!", ConsoleColor.Cyan);
        Write("Insert ", ConsoleColor.Gray);
        Write("add \"your task\"", ConsoleColor.DarkCyan);
        WriteLine(" to save your task.", ConsoleColor.Gray);
    }
    
    public static void ShowHelp()
    {
    }

    public static string? ReadPrompt()
    {
        Write("> ", ConsoleColor.DarkCyan);
        return Console.ReadLine()?.Trim();
    }

    private static void Write(string text, ConsoleColor color)
    {
        var previous = Console.ForegroundColor;
        Console.ForegroundColor = color;
        Console.Write(text);
        Console.ForegroundColor = previous;
    }

    private static void WriteLine(string text, ConsoleColor color)
    {
        string newLine = Environment.NewLine;
        Write($"{text}{newLine}", color);
    }
}