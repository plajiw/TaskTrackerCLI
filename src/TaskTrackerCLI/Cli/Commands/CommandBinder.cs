namespace TaskTrackerCLI.Cli.Commands;

public class CommandBinder
{
    private readonly HashSet<string> _validFlags = [FlagsNames.DONE];
    private readonly HashSet<string> _seenFlags;
    private readonly List<CommandValidationError> _errors;
    public CommandBinder(Command command)
    {
        _seenFlags = new HashSet<string>();
        _errors = new List<CommandValidationError>();

        for (int i = 0; i < command.FlagsTokens.Count; i++)
        {
            var actualValue = command.FlagsTokens[i].Value;

            if (!_validFlags.Contains(actualValue))
                _errors.Add(new CommandValidationError(CommandValidationErrorType.InvalidFlag, "invalid"));

            if (_seenFlags.Contains(actualValue))
                _errors.Add(new CommandValidationError(CommandValidationErrorType.DuplicateFlag, "duplicate"));
            else
                _seenFlags.Add(command.FlagsTokens[i].Value);
        }
    }
}
