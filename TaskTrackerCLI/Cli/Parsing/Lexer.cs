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
            if (char.IsWhiteSpace(_input[_index]))
            {
                _index++;
                continue;
            }

            if (!IsEnd() && char.IsLetter(_input[_index]))
            {
                int startPosition = _index;
                string word = String.Empty;
                
                while(!IsEnd() && char.IsLetter(_input[_index]))
                {
                    word += _input[_index].ToString();
                    _index++;
                }
                
                var wordToken = new Token(TokenType.Word,word, startPosition);
                tokens.Add(wordToken);
            }
            
            else if (!IsEnd() && char.IsDigit(_input[_index]))
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
                tokens.Add(flagToken);
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
                    throw new Exception("Unexpected end of string literal");
                
                literalString += singleOrDoubleQuote.ToString();
                _index++;

                var literalStringToken = new Token(TokenType.LiteralString, literalString, startPosition);
                tokens.Add(literalStringToken);
            }
            else
            {
                throw new Exception($"Unexpected input");
            }
        }

        return tokens;
    }

    private bool IsEnd() => _index >= _input.Length;
}