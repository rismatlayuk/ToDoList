using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoList.Domain.Models;
using TodoList.Domain.Services.Communication;

namespace TodoList.Domain.Services
{
    public interface ITodoService
    {
        Task<IEnumerable<ToDo>> ListAsync();
        Task<ToDoResponse> SaveAsync(ToDo toDo);
        Task<ToDoResponse> UpdateAsync(int id, ToDo toDo);
        Task<ToDoResponse> DeleteAsync(int id);
    }
}
