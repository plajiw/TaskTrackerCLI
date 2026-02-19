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

    public LexerResult Tokenizer()
    {
        var result = new LexerResult();

        while (!IsEnd())
        {
            if (char.IsWhiteSpace(_input[_index]))
            {
                _index++;
                continue;
            }

            if (!IsEnd() && char.IsLetter(_input[_index]))
            {
                int startPosition = _index;
                string word = string.Empty;

                while (!IsEnd() && char.IsLetter(_input[_index]))
                {
                    word += _input[_index].ToString();
                    _index++;
                }

                var wordToken = new Token(TokenType.Word, word, startPosition);
                result.Tokens.Add(wordToken);
            }

            else if (!IsEnd() && char.IsDigit(_input[_index]))
            {
                int startPosition = _index;
                string number = string.Empty;

                while (!IsEnd() && char.IsDigit(_input[_index]))
                {
                    number += _input[_index].ToString();
                    _index++;
                }

                var numberToken = new Token(TokenType.Number, number, startPosition);
                result.Tokens.Add(numberToken);
            }

            else if (!IsEnd() && _input[_index] == '-' && _index + 1 < _input.Length && _input[_index + 1] == '-')
            {
                int startPosition = _index;
                _index += 2;
                string flag = "--";

                while (!IsEnd() && (char.IsLetter(_input[_index]) || _input[_index] == '-'))
                {
                    flag += _input[_index].ToString();
                    _index++;
                }

                var flagToken = new Token(TokenType.Flag, flag, startPosition);
                result.Tokens.Add(flagToken);
            }

            else if (!IsEnd() && (_input[_index] == '"' || _input[_index] == '\''))
            {
                char singleOrDoubleQuote = _input[_index];
                int startPosition = _index;
                _index++;
                string literalString = singleOrDoubleQuote.ToString();

                while (!IsEnd() && _input[_index] != singleOrDoubleQuote)
                {
                    literalString += _input[_index].ToString();
                    _index++;
                }

                if (IsEnd())
                {
                    result.Errors.Add($"Error at position {_index}: Unexpected end of string literal.");
                    break;
                }

                literalString += singleOrDoubleQuote.ToString();

                if (literalString.Length <= 2)
                    throw new Exception("");

                _index++;

                var literalStringToken = new Token(TokenType.LiteralString, literalString, startPosition);
                result.Tokens.Add(literalStringToken);
            }
            else
            {
                result.Errors.Add($"Error at position {_index}: Unexpected input.");
                break;
            }
        }

        return result;
    }

    private bool IsEnd() => _index >= _input.Length;

    public class LexerResult
    {
        public List<Token> Tokens { get; set; } = [];
        public List<string> Errors { get; set; } = [];
        public bool Success => Errors.Count == 0;
    }
}