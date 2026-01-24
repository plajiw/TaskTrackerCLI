using TaskTrackerCLI;
using TaskTrackerCLI.Cli;

class Program
{
    static void Main(string[] args)
    {
        var app = new CliApplication();
        app.Run();
    }
}