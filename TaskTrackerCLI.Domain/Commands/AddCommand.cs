using TaskTrackerCLI.Domain.Commands.Abstractions;
using TaskTrackerCLI.Domain.interfaces;

namespace TaskTrackerCLI.Domain.Commands;

public class AddCommand : ICommandHandler
{
    private readonly ITodoItemService _todoItemService;

    public AddCommand(ITodoItemService todoItemService)
    {
        _todoItemService = todoItemService;
    }

    public void Execute(string payload)
    {
        _todoItemService.AddTodoItem(payload);
    }
}