namespace TaskTrackerCLI.Cli;

public class ConsoleUi
{
    public static void ShowWelcome()
    {
        Console.Clear();
        
        WriteLine("Welcome to TaskTracker CLI!",  ConsoleColor.Cyan);
        Write("Insert ", ConsoleColor.Gray);
        Write("add \"your task\"", ConsoleColor.Blue);
        WriteLine(" to save your task.", ConsoleColor.Gray);
    }

    public static string? ReadPrompt()
    {
        Write("> ", ConsoleColor.Cyan);
        return Console.ReadLine()?.Trim();
    }

    public static void Write(string text, ConsoleColor color)
    {
        var previous = Console.ForegroundColor;
        Console.ForegroundColor = color;
        Console.Write(text);
        Console.ForegroundColor = previous;
    }
    
    public static void WriteLine(string text, ConsoleColor color)
    {
        Write(text + Environment.NewLine, color);
    }
}