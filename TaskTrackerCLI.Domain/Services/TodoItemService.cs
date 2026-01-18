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

    public void GetAllTodoItems()
    {
        var listItems = _todoItemRepository.GetAllTodoItems();

        if (!listItems.Any())
        {
            Console.Write("Empty List");
            return;
        }

        for (int i = 0; i < listItems.Count; i++)
            Console.Write($"{i + 1}. {listItems[i].ToString()}\n");
    }

    public void DeleteTodoItem(int id)
    {

    }
}
