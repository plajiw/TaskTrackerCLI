    using TaskTrackerCLI.Cli.Commands;
    using TaskTrackerCLI.Cli.Parsing;

    namespace TaskTrackerCLI.Cli;

    public class CliApplication
    {
        private readonly bool _runner = true; 
        public void Run()
        {
            var parser = new Parser();
            var dispatcher = new CommandDispatcher();
            
            ConsoleUi.ShowWelcome();
            
            while (_runner)
            {
                var input = ConsoleUi.ReadPrompt();
                if (string.IsNullOrEmpty(input))
                    continue;
                
                var lexer = new Lexer(input);
                var tokens = lexer.Tokenizer();
                var command = parser.ParseCommand(tokens);
                dispatcher.Dispatch(command);                
            }
        }
    }