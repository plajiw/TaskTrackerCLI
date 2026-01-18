using TaskTrackerCLI.Domain.Commands.Abstractions;

namespace TaskTrackerCLI.Domain.Commands;

public class ClearCommand : ICommandHandler
{
    public void Execute(string payload)
    {
        Console.Clear();
    }
}