namespace TaskTrackerCLI.Cli.Commands;

public class Command
{
    public string Name { get; set; }
    public List<string> Arguments { get; set; } = new List<string>();
    public List<string> Flags { get; set; } = new List<string>();
}