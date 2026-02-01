namespace TaskTrackerCLI.Cli.Commands
{
    public enum CommandValidationErrorType
    {
        InvalidFlag,
        DuplicateFlag,
        MissingArgument,
        TooManyArguments,
        InvalidArgumentType,
        EmptyArgument, 
        NullArgument
    }
}
