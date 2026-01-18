namespace TaskTrackerCLI.Domain.Models;

public class TodoItem
{
    public int Id { get; set; }
    public string Description { get; set; }
    public TodoItemStatus Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
