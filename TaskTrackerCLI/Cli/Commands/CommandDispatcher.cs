using TaskTrackerCLI.Cli.Commands.Handlers;
using TaskTrackerCLI.Domain.Repositories;

namespace TaskTrackerCLI.Cli.Commands;

public class CommandDispatcher(ITaskItemRepository repository)
{
    private Dictionary<string, ICommandHandler> _commands = new Dictionary<string, ICommandHandler>
    {
        { CommandNames.ADD, new AddCommandHandler(repository) },
        { CommandNames.LIST, new ListCommandHandler(repository) },
    };
    
    public void Dispatch(Command command)
    {
        _commands.TryGetValue(command.Name, out var commandHandler);

        if (commandHandler == null)
        {
            ConsoleUi.ShowHelp(command.Name);
            return;
        }
        
        commandHandler.Handle(command);
    }
}