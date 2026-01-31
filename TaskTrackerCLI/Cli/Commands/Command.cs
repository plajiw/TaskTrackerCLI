using TaskTrackerCLI.Cli.Parsing;

namespace TaskTrackerCLI.Cli.Commands;

public class Command
{
    public string Name { get; set; }
    public List<Token> ArgumentsTokens { get; set; }
    public List<Token> FlagsTokens { get; set; }
}