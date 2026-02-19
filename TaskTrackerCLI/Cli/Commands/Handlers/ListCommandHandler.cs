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

            string columnTemplate = "{0,-5} | {1,-35} | {2,-12} | {3,-20}";
            ConsoleUi.WriteLine(new string('-', 80), ConsoleColor.Gray);
            ConsoleUi.WriteLine(string.Format(columnTemplate, "ID", "DESCRIPTION", "STATUS", "CREATED AT"), ConsoleColor.DarkCyan);
            ConsoleUi.WriteLine(new string('-', 80), ConsoleColor.Gray);

            taskList.ForEach(t =>
            {
                var displayDescription = t.Description.Length > 32 ? t.Description[..32] + "..." : t.Description;

                var row = string.Format(columnTemplate, t.Id, displayDescription, t.Status, t.CreatedAt.ToString("dd/MM/yyyy HH:mm"));
                ConsoleUi.WriteLine(row, ConsoleColor.Cyan);
            });

            ConsoleUi.WriteLine(new string('-', 80), ConsoleColor.Gray);
        }
    }
}