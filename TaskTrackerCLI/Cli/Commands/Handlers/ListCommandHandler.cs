using TaskTrackerCLI.Domain.Repositories;

namespace TaskTrackerCLI.Cli.Commands.Handlers
{
    public class ListCommandHandler : ICommandHandler
    {
        private readonly ITaskItemRepository _repository;

        public ListCommandHandler(ITaskItemRepository repository)
        {
            _repository = repository;
        }
        public void Handle(Command command)
        {
            throw new NotImplementedException();
        }
    }
}
