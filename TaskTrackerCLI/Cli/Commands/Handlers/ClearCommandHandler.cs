namespace TaskTrackerCLI.Cli.Commands.Handlers
{
    public class ClearCommandHandler : ICommandHandler
    {
        public void Handle(Command _)
        {
            Console.Clear();
            return;
        }
    }
}
