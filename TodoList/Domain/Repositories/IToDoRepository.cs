using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoList.Domain.Models;

namespace TodoList.Domain.Repositories
{
    public interface IToDoRepository
    {
        Task<IEnumerable<ToDo>> ListAsync();
        Task AddAsync(ToDo todo);
        Task<ToDo> FindByIdAsync(int id);
        void Update(ToDo todo);
        void Remove(ToDo todo);
    }
}
