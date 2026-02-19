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
            var tasks = _jsonContext.LoadData();
            return tasks;
        }

        public TaskItem GetTaskItem(int id)
        {
            throw new NotImplementedException();
        }

        public void InsertTaskItem(TaskItem taskItem)
        {
            var tasks = _jsonContext.LoadData();
            taskItem.Id = tasks.Any() ? tasks.Max(t => t.Id) + 1 : 1;
            tasks.Add(taskItem);
            _jsonContext.SaveData(tasks);
        }

        public void UpdateTaskItem(TaskItem taskItem)
        {
            throw new NotImplementedException();
        }
    }
}
