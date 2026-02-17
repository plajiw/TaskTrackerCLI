using TaskTrackerCLI.Domain.Models.TaskItem;
using TaskTrackerCLI.Domain.Repositories;

namespace TaskTrackerCLI.Infrastructure.Persistence.Json
{
    public class JsonTaskItemRepository : ITaskItemRepository
    {
        private readonly JsonContext _jsonContext;

        public JsonTaskItemRepository(JsonContext jsonContext)
        {
            _jsonContext = jsonContext;
        }

        public List<TaskItem> GetAllTaskItem()
        {
            throw new NotImplementedException();
        }

        public TaskItem GetTaskItem(int id)
        {
            throw new NotImplementedException();
        }

        public void InsertTaskItem(TaskItem taskItem)
        {
            throw new NotImplementedException();
        }

        public void UpdateTaskItem(TaskItem taskItem)
        {
            throw new NotImplementedException();
        }
    }
}
