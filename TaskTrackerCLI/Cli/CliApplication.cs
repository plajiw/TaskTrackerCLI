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
            var tokens = lexer.Tokenizer();
            var command = _parser.ParseCommand(tokens);
            _dispatcher.Dispatch(command);
        }
    }
}