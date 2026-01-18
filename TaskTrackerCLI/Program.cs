using TaskTrackerCLI.Domain;
using TaskTrackerCLI.Domain.Constants;

class Program
{
    static void Main(string[] args)
    {
        InitialMessageConsole();
        bool running = true;

        while (running)
        {
            Console.Write("\n> ");
            var input = Console.ReadLine();

            input = "add";

            if (input == Commands.EXIT)
                break;

            ProcessCommand(input);
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

    private static void ProcessCommand(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            Console.WriteLine("Invalid command.");
            return;
        }

        var command = input.Split(' ')[0];

        switch (command)
        {
            case "add":

                break;

            case "help":

                break;

            default:
                break;
        }

    }
}
