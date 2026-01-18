using System.Windows.Input;
using TaskTrackerCLI.Domain.Commands.Abstractions;

namespace TaskTrackerCLI.Domain.Commands;

public class ExitCommand : ICommandHandler
{
    public void Execute(string payload)
    {
        Environment.Exit(0);
    }
}