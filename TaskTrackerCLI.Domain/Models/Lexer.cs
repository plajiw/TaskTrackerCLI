namespace TaskTrackerCLI.Domain.Models;

public class Lexer
{
    private readonly string _input;
    private int _index;
    
    public  Lexer(string input)
    {
        _input = input ?? string.Empty;
        _index = 0;
    }
    
    public IReadOnlyList<Token> Tokenize()
}