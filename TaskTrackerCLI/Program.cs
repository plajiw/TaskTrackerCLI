using TaskTrackerCLI.Domain.Constants;
using TaskTrackerCLI.Domain.interfaces;
using TaskTrackerCLI.Domain.Services;
using TaskTrackerCLI.Infrastructure;

class Program
{
    private static readonly ITodoItemRepository _repository = new JsonTodoItemRepository();
    private static readonly TodoItemService _todoItemService = new TodoItemService(_repository);
    static void Main(string[] args)
    {
        Run();
    }

    private static void Run()
    {
        InitialMessageConsole();
        bool running = true;

        while (running)
        {
            Console.Write("\n> ");
            var input = Console.ReadLine()?.Trim();

            if (string.IsNullOrEmpty(input))
                Console.WriteLine("INvalid");

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
        Console.Write("add [your task]");
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
        var payload = segments[1];



        switch (verb)
        {
            case Commands.ADD:
                _todoItemService.AddTodoItem(payload);
                break;

            // case Commands.LIST:
            //     break;
            //
            // case Commands.DELETE:
            //     break;
            //
            // case Commands.MARK_IN_PROGRESS:
            //     break;
            //
            // case Commands.MARK_DONE:
            //     break;
            //
            // case Commands.MARK_CANCELLED:
            //     break;
            //
            // case Commands.HELP:
            //     break;
            //
            // case Commands.EXIT:
            //     break;
            //
            // default:
            //     break;
        }
    }
}
