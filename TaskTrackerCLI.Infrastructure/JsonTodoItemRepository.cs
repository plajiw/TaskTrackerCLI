using System.Text.Json;
using TaskTrackerCLI.Domain.interfaces;
using TaskTrackerCLI.Domain.Models;

namespace TaskTrackerCLI.Infrastructure;

public class JsonTodoItemRepository : ITodoItemRepository
{
    private static List<TodoItem>? _items;
    private static string _filePath = "tasks.json";

    public JsonTodoItemRepository()
    {
        InitializeLibrary();
    }

    public void Add(TodoItem todoItem)
    {
        todoItem.Id = _items.Any() ? _items.Max(t => t.Id) + 1 : 0;
        _items.Add(todoItem);
        RefreshFile();
        Console.WriteLine($"# Output: Task added successfully (ID: {todoItem.Id})");
    }

    public void Update(TodoItem todoItem)
    {
        var index = _items.FindIndex(t => t.Id == todoItem.Id);
        _items[index] = todoItem;
        RefreshFile();
    }

    public TodoItem? GetTodoItem(int id)
    {
        return _items?.FirstOrDefault(t => t.Id == id);
    }

    public List<TodoItem>? GetAllTodoItems()
    {
        return _items;
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    private void SaveChanges()
    {
        using var stream = File.OpenWrite("");
    }

    private void InitializeLibrary()
    {
        string jsonPath = _filePath;

        if (!File.Exists(jsonPath))
        {
            _items = new List<TodoItem>();
            return;
        }

        string json = File.ReadAllText(jsonPath);

        if (string.IsNullOrWhiteSpace(json))
            json = "[]";

        _items = JsonSerializer.Deserialize<List<TodoItem>>(json) ?? new List<TodoItem>();
    }

    private void RefreshFile()
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        var itemsJson = JsonSerializer.Serialize(_items, options);
        File.WriteAllText(_filePath, itemsJson);
    }
}
