using TaskTrackerCLI.Cli.Commands;

namespace TaskTrackerCLI.Cli.Parsing;

public class Parser
{
    public Command ParseCommand(List<Token> tokens)
    {
        if (!tokens.Any())
            throw new Exception("No tokens found");

        if (tokens[0].Type != TokenType.Word)
            throw new Exception("Expected word");
        
        var command = new Command();
        command.Name = tokens[0].Value;

        tokens.ForEach(t =>
        {
            if (t.Type == TokenType.Flag)
                command.Flags.Add((CommandFlags)Enum.Parse(typeof(CommandFlags), t.Value));
            
            if (t.Type == TokenType.LiteralString)
                command.Arguments.Add(t.Value);
        });

        return command;
    }
}