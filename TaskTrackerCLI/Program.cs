using TaskTrackerCLI;

class Program
{
    static void Main(string[] args)
    {
        InitialMessage();
        Run();
    }

    static void InitialMessage()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Welcome to Task Tracker CLI!");
        Console.ResetColor();
        Console.Write("Insert ");
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write("add \"your task\"");
        Console.ResetColor();
        Console.Write(" to save our task.\n");
    }

    static void Run()
    {
        bool running = true;
        while (running)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("\n> ");
            Console.ResetColor();
            var input = Console.ReadLine()?.Trim();
            if (input != null)
            {
            }

            if (input == "exit")
                running = false;
        }
    }
}