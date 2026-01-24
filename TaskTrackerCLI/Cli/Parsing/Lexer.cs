namespace TaskTrackerCLI.Cli.Parsing;

public class Lexer
{
    private int _index { get; set; }
    private string _input { get; set; }

    public Lexer(string input)
    {
        _input = input;
        _index = 0;
    }
    
    public List<Token> Tokenizer()
    {
        var tokens = new List<Token>();
        
        while (!IsEnd())
        {
            if (_input[_index] == ' ')
            {
                _index++;
                continue;
            }

            else if (char.IsDigit(_input[_index]))
            {
                int number = _input[_index];
            }
            else if (_input[_index] == '-' && _input[_index + 1] == '-')
            {
                var flag = string.Empty;
            }
            else if (_input[_index] == '"')
            {
                var literal = string.Empty;
            }
            else
            {
                var word = string.Empty;
            }
        }

        return tokens;
    }
    
    private bool IsEnd() => _index >= _input.Length;
}