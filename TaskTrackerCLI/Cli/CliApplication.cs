using TaskTrackerCLI.Cli.Parsing;

namespace TaskTrackerCLI.Cli;

public class CliApplication
{
    private readonly bool _runner = true; 
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
            var parser = new Parser();
            var command = parser.ParseCommand(tokens);
            
            foreach (var token in tokens)
                Console.WriteLine($"Value: {token.Value} - Type: {token.Type} - Position: {token.Position}");

            Console.WriteLine($"Command: {command.Name} - Arguments: {string.Join(", ", command.Arguments)} - Flags: {string.Join(", ", command.Flags)}");
        }
    }
}