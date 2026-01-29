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
    
    public static void ShowHelp(string? command = null)
    {
        Console.WriteLine();

        if (!string.IsNullOrWhiteSpace(command))
        {
            Write("Unknown command: ", ConsoleColor.Red);
            WriteLine(command, ConsoleColor.DarkCyan);
            Console.WriteLine();
        }

        WriteLine("Available commands:", ConsoleColor.Cyan);
        Console.WriteLine();

        Write("  add ", ConsoleColor.DarkCyan);
        WriteLine("\"task description\"", ConsoleColor.Gray);

        Write("      ", ConsoleColor.Gray);
        WriteLine("Adds a new task to the list.", ConsoleColor.DarkGray);

        Console.WriteLine();

        WriteLine("Examples:", ConsoleColor.Cyan);
        Console.WriteLine();

        Write("  add ", ConsoleColor.DarkCyan);
        WriteLine("\"Buy milk\"", ConsoleColor.Gray);

        Write("  add ", ConsoleColor.DarkCyan);
        WriteLine("\"Study algorithms\" --done", ConsoleColor.Gray);

        Console.WriteLine();

        WriteLine("Type \"help\" to see this message again.", ConsoleColor.DarkGray);
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