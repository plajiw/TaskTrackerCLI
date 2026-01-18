using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskTrackerCLI.Domain.Models;

namespace TaskTrackerCLI.Domain.interfaces
{
    public interface ITodoItemService
    {
        public void AddTodoItem(string payload);
        public void UpdateTodoItem(string payload);
        public TodoItem GetTodoItem(int id);
        public void GetAllTodoItems();
        public void DeleteTodoItem(int id);
    }
}
