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
        }
    }
}