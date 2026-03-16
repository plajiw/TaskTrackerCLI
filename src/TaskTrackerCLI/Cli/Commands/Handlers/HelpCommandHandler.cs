namespace TaskTrackerCLI.Cli.Commands.Handlers
{
    internal class HelpCommandHandler : ICommandHandler
    {
        public void Handle(Command command)
        {
            ConsoleUi.ShowHelp();
            return;
        }
    }
}
