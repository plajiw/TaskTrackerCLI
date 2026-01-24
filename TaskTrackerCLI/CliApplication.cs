using TaskTrackerCLI.Domain.Models;

namespace TaskTrackerCLI;

public class CliApplication
{
    private bool _running =  true;

    public void Run()
    {
        ConsoleUi.ShowWelcome();

        while (_running)
        {
            var input = ConsoleUi.ReadPrompt();
            
            if (string.IsNullOrWhiteSpace(input))
                continue;

            if (input.Equals("quit", StringComparison.OrdinalIgnoreCase))
            {
                _running = false;
                continue;
            }
            
            ProcessInput(input);
        }
    }
    
    private void ProcessInput(string input)
    {
        var lexer = new Lexer(input);
        var tokens = lexer.Tokenize();
    }
}