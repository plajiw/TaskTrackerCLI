using TaskTrackerCLI.Cli.Commands;

namespace TaskTrackerCLI.Cli.Parsing;

public class Parser
{
    public ParserResult ParseCommand(List<Token> tokens)
    {
        var result = new ParserResult()
        {
            Command = new Command() { Name = tokens[0].Value }
        };

        if (tokens == null || !tokens.Any())
            result.Errors.Add("No tokens found");

        if (tokens[0].Type != TokenType.Word)
            result.Errors.Add("Expected word");

        for (int i = 1; i < tokens.Count; i++)
        {
            var token = tokens[i];

            switch (token.Type)
            {
                case TokenType.Flag:
                    result.Command.FlagsTokens.Add(token);
                    break;

                case TokenType.Word:
                case TokenType.Number:
                case TokenType.LiteralString:
                    result.Command.ArgumentsTokens.Add(token);
                    break;

                default:
                    result.Errors.Add($"Unexpected token '{token.Value}' at position {token.Position}");
                    break;
            }
        }

        return result;
    }

    public class ParserResult
    {
        public Command? Command { get; set; }
        public List<string> Errors { get; set; } = [];
        public bool Success => Errors.Count == 0 && Command != null;
    }
}