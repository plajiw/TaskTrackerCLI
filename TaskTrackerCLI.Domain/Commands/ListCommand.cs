using TaskTrackerCLI.Domain.Commands.Abstractions;
using TaskTrackerCLI.Domain.interfaces;

namespace TaskTrackerCLI.Domain.Commands;

public class ListCommand : ICommandHandler
{
    private readonly ITodoItemService _todoItemService;

    public ListCommand(ITodoItemService todoItemService)
    {
        _todoItemService = todoItemService;
    }
    public void Execute(string payload)
    {
        _todoItemService.GetAllTodoItems();
    }
}