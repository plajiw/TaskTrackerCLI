using TaskTrackerCLI.Cli.Commands.Handlers;

namespace TaskTrackerCLI.Cli.Commands;

public class CommandDispatcher
{
    private Dictionary<string, ICommandHandler> _commands = new Dictionary<string, ICommandHandler>
    {
        { CommandNames.ADD, new AddCommandHandler() },
        { CommandNames.LIST, new ListCommandHandler() },
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