using System.Text;
using TaskTrackerCLI.Domain.Models.Token;

namespace TaskTrackerCLI.Cli;

public class Lexer
{
    private readonly string _input;
    private int _index;

    public Lexer(string input)
    {
        _input = input ?? string.Empty;
        _index = 0;
    }

    public IReadOnlyList<Token> Tokenize()
    {
        var tokens = new List<Token>();

        while (!IsAtEnd())
        {
            SkipWhitespace();

            if (IsAtEnd())
                break;

            var start = _index;
            var current = Peek();

            if (current == '"')
            {
                tokens.Add(ReadString());
            }
            else if (current == '-' && PeekNext() == '-')
            {
                tokens.Add(ReadFlag());
            }
            else if (char.IsDigit(current))
            {
                tokens.Add(ReadNumber());
            }
            else
            {
                tokens.Add(ReadWord());
            }
        }

        return tokens;
    }

    private bool IsAtEnd() => _index >= _input.Length;

    private char Advance() => _input[_index++];

    private void SkipWhitespace()
    {
        while (!IsAtEnd() && char.IsWhiteSpace(_input[_index]))
        {
            Advance();
        }
    }

    private char Peek() => _input[_index];
    private char PeekNext() => _index + 1 < _input.Length ? _input[_index + 1] : '\0';

    private Token ReadString()
    {
        var start = _index;
        Advance();

        var sb = new StringBuilder();

        while (!IsAtEnd() && Peek() != '"')
        {
            sb.Append(Advance());
        }

        if (IsAtEnd())
            throw new Exception();

        Advance();

        return new Token(TokenType.String, sb.ToString(), start);
    }

    private Token ReadFlag()
    {
        var start = _index;
        Advance();
        Advance();

        var sb = new StringBuilder("--");

        while (!IsAtEnd() && !char.IsWhiteSpace(Peek()))
        {
            sb.Append(Advance());
        }

        return new Token(TokenType.Flag, sb.ToString(), start);
    }

    private Token ReadNumber()
    {
        var start = _index;
        var sb = new StringBuilder();

        while (!IsAtEnd() && char.IsDigit(Peek()))
        {
            sb.Append(Advance());
        }

        return new Token(TokenType.Number, sb.ToString(), start);
    }

    private Token ReadWord()
    {
        var start = _index;
        var sb = new StringBuilder();

        while (!IsAtEnd() && !char.IsWhiteSpace(Peek()))
        {
            sb.Append(Advance());
        }

        return new Token(TokenType.Word, sb.ToString(), start);
    }
}