using TaskTrackerCLI.Domain.Commands.Abstractions;
using TaskTrackerCLI.Domain.interfaces;

namespace TaskTrackerCLI.Domain.Commands;

public class UpdateCommand : ICommandHandler
{
    private readonly ITodoItemService  _todoItemService;

    public UpdateCommand(ITodoItemService todoItemService)
    {
        _todoItemService = todoItemService;
    }
    public void Execute(string payload)
    {
        _todoItemService.UpdateTodoItem(payload);
    }
}