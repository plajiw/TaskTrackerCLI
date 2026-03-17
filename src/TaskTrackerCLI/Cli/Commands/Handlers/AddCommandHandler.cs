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
        var description = command.ArgumentsTokens.FirstOrDefault()?.Value.ToString();
        var argumentsFlag = command.FlagsTokens;
        
        if (description is null)
            throw new ArgumentException();

        var task = new TaskItem
        {
            Description = description,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
        };

        if (argumentsFlag.Any())
        {
            var flag = argumentsFlag.FirstOrDefault().Value.ToString();

            switch (flag)
            {
                case "--done":
                    task.Status = TaskItemStatus.Done;
                    break;

                case "--in-progress":
                    task.Status = TaskItemStatus.InProgress;
                    break;
            }
        }

        _repository.InsertTaskItem(task);
        ConsoleUi.ShowSucessOperation();
    }
}