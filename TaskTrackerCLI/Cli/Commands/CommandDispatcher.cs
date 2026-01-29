namespace TaskTrackerCLI.Cli.Commands;

public class CommandDispatcher
{
    private Dictionary<string, ICommandHandler> _commands = new Dictionary<string, ICommandHandler>
    {
        { "add", new AddCommandHandler() },
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