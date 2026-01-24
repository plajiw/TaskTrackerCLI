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

            if (char.IsDigit(_input[_index]))
            {
                int startPosition = _index;
                string number = String.Empty;

                while (!IsEnd() && char.IsDigit(_input[_index]))
                {
                    number += _input[_index].ToString();
                    _index++;
                }

                var numberToken = new Token(TokenType.Number, number, startPosition);
                tokens.Add(numberToken);
            }
            
            else if (_input[_index] == '-' && _input[_index + 1] == '-')
            {
                _index += 2;
                int startPosition = _index;
                string flag = String.Empty;

                while (!IsEnd() && char.IsLetter(_input[_index]))
                {
                    flag += _input[_index].ToString();
                    _index++;
                }
                
                var flagToken = new Token(TokenType.Flag, flag, startPosition);
                tokens.Add(flagToken);
            }
        }

        return tokens;
    }

    private bool IsEnd() => _index >= _input.Length;
}