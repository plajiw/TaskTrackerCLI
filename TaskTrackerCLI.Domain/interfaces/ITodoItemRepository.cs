using TaskTrackerCLI.Domain.Models;

namespace TaskTrackerCLI.Domain.interfaces
{
    public interface ITodoItemRepository
    {
        public void Add(TodoItem todoItem);
        public void Update(TodoItem todoItem);
        public TodoItem? GetTodoItem(int id);
        public List<TodoItem>? GetAllTodoItems();
        public void Delete(int id);
    }
}
