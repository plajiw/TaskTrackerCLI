namespace TaskTrackerCLI.Cli.Commands
{
    public record CommandValidationError(CommandValidationErrorType Type, string Message);
}