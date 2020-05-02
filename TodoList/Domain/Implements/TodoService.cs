
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using TodoList.Domain.Models;
using TodoList.Domain.Repositories;
using TodoList.Domain.Services;
using TodoList.Domain.Services.Communication;
using TodoList.Infrastructure;

namespace TodoList.Domain.Implements
{
    public class TodoService : ITodoService
    {
        private readonly IToDoRepository _todoRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMemoryCache _cache;

        public TodoService(IToDoRepository todoRepository,
                           IUnitOfWork unitOfWork,
                           IMemoryCache cache)
        {
            _todoRepository = todoRepository;
            _unitOfWork = unitOfWork;
            _cache = cache;
        }

        public async Task<ToDoResponse> DeleteAsync(int id)
        {
            var existingToDo = await _todoRepository.FindByIdAsync(id);

            if (existingToDo == null)
                return new ToDoResponse("ToDo not found.");

            try
            {
                _todoRepository.Remove(existingToDo);
                await _unitOfWork.CompleteAsync();

                return new ToDoResponse(existingToDo);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new ToDoResponse($"An error occurred when deleting the ToDo: {ex.Message}");
            }
        }

        public async Task<IEnumerable<ToDo>> ListAsync()
        {
            // Here I try to get the ToDo list from the memory cache. If there is no data in cache, the anonymous method will be
            // called, setting the cache to expire one minute ahead and returning the Task that lists the categories from the repository.
            var todo = await _cache.GetOrCreateAsync(CacheKeys.ToDoList, (entry) => {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1);
                return _todoRepository.ListAsync();
            });

            return todo;
        }

        public Task<ToDoResponse> SaveAsync(ToDo toDo)
        {
            throw new System.NotImplementedException();
        }

        public Task<ToDoResponse> UpdateAsync(int id, ToDo toDo)
        {
            throw new System.NotImplementedException();
        }
    }
}
