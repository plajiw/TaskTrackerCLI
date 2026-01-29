using TaskTrackerCLI.Cli;

namespace TaskTrackerCLI;

public static class Program
{
    private static void Main()
    {
        var app = new CliApplication();
        app.Run();
    }
}