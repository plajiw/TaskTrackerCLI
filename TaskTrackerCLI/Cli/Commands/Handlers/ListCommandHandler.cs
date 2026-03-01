using System.Diagnostics;
using TaskTrackerCLI.Domain.Models.TaskItem;
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
            var taskList = _repository.GetAllTaskItem();

            if (!taskList.Any())
            {
                ConsoleUi.WriteLine("No tasks have been created yet.", ConsoleColor.Yellow);
                return;
            }

            ConsoleUi.PrintTable(taskList);
        }
    }
}