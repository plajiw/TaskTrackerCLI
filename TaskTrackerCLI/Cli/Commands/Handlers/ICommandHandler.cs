namespace TaskTrackerCLI.Cli.Commands.Handlers;

public interface ICommandHandler
{
    void Handle (Command command);
}