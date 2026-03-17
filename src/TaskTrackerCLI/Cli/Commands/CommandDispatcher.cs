using TaskTrackerCLI.Cli.Commands.Handlers;
using TaskTrackerCLI.Domain.Repositories;

namespace TaskTrackerCLI.Cli.Commands;

public class CommandDispatcher(ITaskItemRepository repository)
{
    private Dictionary<string, ICommandHandler> _commands = new Dictionary<string, ICommandHandler>
    {
        { CommandNames.ADD, new AddCommandHandler(repository) },
        { CommandNames.LIST, new ListCommandHandler(repository) },
        { CommandNames.UPDATE, new UpdateCommandHandler() },
        { CommandNames.REMOVE, new RemoveCommandHandler() },
        { CommandNames.CLEAR, new ClearCommandHandler() },
        { CommandNames.HELP, new HelpCommandHandler() },
        { CommandNames.EXIT, new ExitCommandHandler() },
    };

    public void Dispatch(Command command)
    {
        _commands.TryGetValue(command.Name, out var commandHandler);

        if (commandHandler == null)
        {
            ConsoleUi.ShowHint(command.Name);
            return;
        }

        commandHandler.Handle(command);
    }
}