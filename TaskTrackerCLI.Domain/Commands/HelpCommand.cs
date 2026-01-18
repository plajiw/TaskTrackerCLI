using TaskTrackerCLI.Domain.Commands.Abstractions;
using TaskTrackerCLI.Domain.Constants;

namespace TaskTrackerCLI.Domain.Commands;

public class HelpCommand : ICommandHandler
{
    public void Execute(string payload)
    {
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Available Commands:");
        Console.ResetColor();

        PrintHelpLine(Constants.Commands.ADD, "\"task description\"", "Adds a new task to your list.");
        PrintHelpLine(Constants.Commands.ADD, "--done \"task\"", "Adds a task already marked as completed.");
        PrintHelpLine(Constants.Commands.LIST, "", "Shows all tasks saved.");
        PrintHelpLine(Constants.Commands.HELP, "", "Displays this help message.");
    }

    private void PrintHelpLine(string command, string args, string description)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write($"- {command} ");
        
        if (!string.IsNullOrEmpty(args))
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write($"{args} ");
        }

        Console.ResetColor();
        Console.WriteLine($": {description}");
    }
}