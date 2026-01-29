namespace TaskTrackerCLI.Cli.Commands;

public interface ICommandHandler
{
    void Handle (Command command);
}