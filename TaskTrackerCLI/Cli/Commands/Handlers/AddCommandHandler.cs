using TaskTrackerCLI.Domain.Models.TaskItem;

namespace TaskTrackerCLI.Cli.Commands.Handlers;

public class AddCommandHandler : ICommandHandler
{
    public void Handle(Command command)
    {
        var task = new TaskItem();
        
        
    }
}