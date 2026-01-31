using TaskTrackerCLI.Cli.Commands;

namespace TaskTrackerCLI.Cli.Parsing;

public class Parser
{
    public Command ParseCommand(List<Token> tokens)
    {
        if (tokens == null  || !tokens.Any())
            throw new ArgumentException("No tokens found");

        if (tokens[0].Type != TokenType.Word)
            throw new ArgumentException("Expected word");

        var command = new Command()
        {
            Name = tokens[0].Value,
        };

        for (int i = 1; i < tokens.Count; i++)
        {
            var token = tokens[i];

            switch (token.Type)
            {
                case TokenType.Flag:
                    command.FlagsTokens.Add(token);
                    break;
                
                case TokenType.Word:
                case TokenType.Number:
                case TokenType.LiteralString:
                    command.ArgumentsTokens.Add(token);
                    break;
                
                default:
                    throw new ArgumentException(
                        $"Unexpected token '{token.Value}' at position {token.Position}");
            }
        }
        
        return command;
    }
}