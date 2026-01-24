namespace TaskTrackerCLI.Cli.Parsing;

public class Token
{
    public TokenType Type { get; }
    public string Value { get; }
    public int  Position { get; }
    
    public Token(string value)
    {
        Value = value;
    }
}