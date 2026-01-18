namespace TaskTrackerCLI.Domain.Commands.Abstractions;

public interface ICommandHandler
{
    public void Execute(string payload);
}