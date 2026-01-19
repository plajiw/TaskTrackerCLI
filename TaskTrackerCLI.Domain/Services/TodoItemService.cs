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
        if (string.IsNullOrWhiteSpace(payload))
        {
            Console.WriteLine("Error: Update requires arguments [id] [description].");
            return;
        }
        
        var parts = payload.Split(' ', 2,  StringSplitOptions.RemoveEmptyEntries);
        if (parts.Length < 2)
        {
            Console.WriteLine("Error: Missing description. Use: update [id] [new description]");
            return;
        }

        if (!int.TryParse(parts[0], out int id))
        {
            Console.WriteLine($"Error: '{parts[0]}' is not a valid numeric ID.");
            return;
        }
        
        var item = GetTodoItem(id);
        if (item == null)
        {
            Console.WriteLine($"Error: Task with ID {id} not found.");
            return;
        }
        
        var updatedDescription = parts[1];
        item.Description = updatedDescription;
        item.UpdatedAt = DateTime.UtcNow;
        
        _todoItemRepository.Update(item);
        Console.WriteLine($"Task {id} updated successfully.");
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
