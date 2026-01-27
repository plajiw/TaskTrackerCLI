using TaskTrackerCLI.Cli.Parsing;
using Xunit;

namespace TaskTrackerCLI.Test;

public class LexerTests
{
    [Fact]
    public void TokenizesSingleToken()
    {
        List<Token> token = new();
        string input = "add";
        
        var lexer = new Lexer(input);
        token = lexer.Tokenizer();
        
        Assert.Single(token);
        Assert.Equal(TokenType.Word, token.First().Type);
        Assert.Equal("add", token.First().Value);
        Assert.Equal(0, token.First().Position);
    }

    [Fact]
    public void TokenizesMultipleTokens()
    {
        List<Token> tokens = new();
        string input = "add --done \"make a coffe\"";

        var lexer = new Lexer(input);
        tokens = lexer.Tokenizer();

        Assert.Equal(3, tokens.Count);
        Assert.Equal(TokenType.Word, tokens[0].Type);
        Assert.Equal("add", tokens[0].Value);
        Assert.Equal(0, tokens[0].Position);
        
        Assert.Equal(TokenType.Flag, tokens[1].Type);
        Assert.Equal("--done", tokens[1].Value);
        Assert.Equal(4, tokens[1].Position);
        
        Assert.Equal(TokenType.LiteralString, tokens[2].Type);
        Assert.Equal("\"make a coffe\"", tokens[2].Value);
        Assert.Equal(11, tokens[2].Position);
    }
}

