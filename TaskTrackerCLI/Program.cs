using TaskTrackerCLI.Domain.Commands;
using TaskTrackerCLI.Domain.Commands.Abstractions;
using TaskTrackerCLI.Domain.Constants;
using TaskTrackerCLI.Domain.interfaces;
using TaskTrackerCLI.Domain.Services;
using TaskTrackerCLI.Infrastructure;

class Program
{
    private static readonly ITodoItemRepository _repository = new JsonTodoItemRepository();
    private static readonly ITodoItemService _service = new TodoItemService(_repository);

    private static readonly Dictionary<string, ICommandHandler> _commands = new()
    {
        { Commands.HELP, new HelpCommand() },
        { Commands.ADD, new AddCommand(_service) },
        { Commands.LIST, new ListCommand(_service) },
        {Commands.CLEAR, new ClearCommand() },
        { Commands.EXIT, new ExitCommand() },
    };

    static void Main(string[] args)
    {
        Run();
    }

    private static void Run()
    {
        InitialMessageConsole();
        while (true)
        {
            Console.Write("\n> ");
            var input = Console.ReadLine()?.Trim();

            if (string.IsNullOrEmpty(input))
                continue;

            HandleCommand(input);
        }
    }


    private static void InitialMessageConsole()
    {
        Console.Clear();

        string welcomeMsg = "Welcome to TaskTrackerCLI!\n";
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write(welcomeMsg);
        Console.ResetColor();

        Console.Write("Insert ");
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write("add \"your task\"");
        Console.ResetColor();
        Console.Write(" in the console.\n");

        Console.Write("Write ");
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write("help");
        Console.ResetColor();
        Console.Write(" for more information.\n");
    }


    private static void HandleCommand(string input)
    {
        var segments = input.Split(' ', 2, StringSplitOptions.RemoveEmptyEntries);
        var verb = segments[0];
        var fullPayload = segments.Length > 1 ? segments[1] : string.Empty;

        if (_commands.TryGetValue(verb, out var command))
        {
            command.Execute(fullPayload);
        }
        else
        {
            Console.Write($"\nUnknown command: {verb}. Use ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("help");
            Console.ResetColor();
            Console.Write(" for more information.");
        }
    }
}