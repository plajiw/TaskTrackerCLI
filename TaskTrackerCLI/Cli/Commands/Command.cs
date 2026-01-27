namespace TaskTrackerCLI.Cli.Commands;

public class Command
{
    public string Name { get; set; }
    public List<string> Arguments { get; set; } = new List<string>();
    public List<CommandFlags> Flags { get; set; } = new List<CommandFlags>();

    public Command(string name)
    {
        Name = name;
    }
}