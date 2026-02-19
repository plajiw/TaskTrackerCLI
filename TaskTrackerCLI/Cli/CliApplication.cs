using TaskTrackerCLI.Cli.Commands;
using TaskTrackerCLI.Cli.Parsing;

namespace TaskTrackerCLI.Cli;

public class CliApplication
{
    private readonly bool _runner = true;
    private readonly CommandDispatcher _dispatcher;
    private readonly Parser _parser;

    public CliApplication(CommandDispatcher dispatcher, Parser parser)
    {
        _dispatcher = dispatcher;
        _parser = parser;
    }

    public void Run()
    {
        ConsoleUi.ShowWelcome();

        while (_runner)
        {
            var input = ConsoleUi.ReadPrompt();
            if (string.IsNullOrEmpty(input))
                continue;

            var lexer = new Lexer(input);
            var lexerResult = lexer.Tokenizer();

            if (!lexerResult.Success)
            {
                foreach (var erro in lexerResult.Errors)
                    ShowErrors(lexerResult.Errors);
                continue;
            }

            var parserResult = _parser.ParseCommand(lexerResult.Tokens);

            if (!parserResult.Success)
            {
                foreach (var erro in lexerResult.Errors)
                    ShowErrors(lexerResult.Errors);
                continue;
            }

            _dispatcher.Dispatch(parserResult.Command!);
        }
    }
    private void ShowErrors(List<string> errors)
    {
        foreach (var erro in errors)
            ConsoleUi.WriteLine($"[Error] {erro}", ConsoleColor.Red);
    }
}