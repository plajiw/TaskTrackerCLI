using TaskTrackerCLI.Cli;
using TaskTrackerCLI.Cli.Commands;
using TaskTrackerCLI.Cli.Parsing;
using TaskTrackerCLI.Infrastructure.Persistence;
using TaskTrackerCLI.Infrastructure.Persistence.Json;

namespace TaskTrackerCLI;

public static class Program
{
    private static void Main()
    {
        var jsonContext = new JsonContext();
        var repository = new JsonTaskItemRepository(jsonContext);
        var parser = new Parser();
        var dispatcher = new CommandDispatcher(repository);

        var app = new CliApplication(dispatcher, parser);

        app.Run();
    }
}