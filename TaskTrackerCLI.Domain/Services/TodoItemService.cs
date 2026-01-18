using TaskTrackerCLI.Domain.interfaces;
using TaskTrackerCLI.Domain.Models;

namespace TaskTrackerCLI.Domain.Services;

public class TodoItemService : ITodoItemService
{
    readonly ITodoItemRepository _todoItemRepository;
    public TodoItemService(ITodoItemRepository todoItemRepository)
    {
        _todoItemRepository = todoItemRepository;
    }
    public void AddTodoItem(string payload)
    {
        if (string.IsNullOrWhiteSpace(payload))
        {
            return;
        }

        var todoItem = new TodoItem()
        {
            Description = payload,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };
        
        _todoItemRepository.Add(todoItem);
    }

    public void UpdateTodoItem(string payload)
    {
    }

    public TodoItem GetTodoItem(int id)
    {
        return _todoItemRepository.GetTodoItem(id);
    }

    public List<TodoItem> GetAllTodoItems()
    {
        return _todoItemRepository.GetAllTodoItems();
    }

    public void DeleteTodoItem(int id)
    {
        
    }
}
