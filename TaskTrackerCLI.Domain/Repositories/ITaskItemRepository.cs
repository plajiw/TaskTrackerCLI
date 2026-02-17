using TaskTrackerCLI.Domain.Models.TaskItem;

namespace TaskTrackerCLI.Domain.Repositories
{
    // TODO: Ler sobre IDispose, Repository Pattern, Dispose Pattern e Command Pattern
    public interface ITaskItemRepository
    {
        void InsertTaskItem(TaskItem taskItem);

        void UpdateTaskItem(TaskItem taskItem);

        List<TaskItem> GetAllTaskItem();

        TaskItem GetTaskItem(int id);

    }
}
