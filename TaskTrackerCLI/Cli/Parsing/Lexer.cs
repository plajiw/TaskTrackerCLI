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
                int startPosition = _index;
                string numbers = String.Empty;

                while (!IsEnd() && char.IsDigit(_input[_index]))
                {
                    numbers += _input[_index].ToString();
                    _index++;
                }

                var numberToken = new Token(TokenType.Number, numbers, startPosition);
                tokens.Add(numberToken);
            }
        }

        return tokens;
    }

    private bool IsEnd() => _index >= _input.Length;
}