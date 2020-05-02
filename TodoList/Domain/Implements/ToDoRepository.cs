using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoList.Contexts;
using TodoList.Domain.Models;
using TodoList.Domain.Repositories;

namespace TodoList.Domain.Implements
{
    public class ToDoRepository : BaseRepository, IToDoRepository
    {
        public ToDoRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<ToDo>> ListAsync()
        {
            return await _context.Todos
                                 .AsNoTracking()
                                 .ToListAsync();

            // AsNoTracking tells EF Core it doesn't need to track changes on listed entities. Disabling entity
            // tracking makes the code a little faster
        }

        public void Remove(ToDo todo)
        {
            _context.Todos.Remove(todo);
        }

        public async Task AddAsync(ToDo todo)
        {
            await _context.Todos.AddAsync(todo);
        }

        public async Task<ToDo> FindByIdAsync(int id)
        {
            return await _context.Todos.FindAsync(id);
        }

        public void Update(ToDo todo)
        {
            _context.Todos.Update(todo);
        }

    }

 
}
