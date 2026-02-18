using TaskTrackerCLI.Domain.Models.TaskItem;
using TaskTrackerCLI.Domain.Repositories;

namespace TaskTrackerCLI.Cli.Commands.Handlers;

public class AddCommandHandler : ICommandHandler
{
    private readonly ITaskItemRepository _repository;
    public AddCommandHandler(ITaskItemRepository repository)
    {
        _repository = repository;
    }

    public void Handle(Command command)
    {
        var description = command.ArgumentsTokens.FirstOrDefault().ToString() ?? "Teste";

        var task = new TaskItem
        {
            Description = description,
            CreatedAt = DateTime.Now
        };

        _repository.InsertTaskItem(task);

    }
}