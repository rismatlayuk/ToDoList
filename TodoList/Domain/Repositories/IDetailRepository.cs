using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoList.Domain.Models;
using TodoList.Domain.Models.Queries;

namespace TodoList.Domain.Repositories
{
    interface IDetailRepository
    {
        Task<QueryResult<Detail>> ListAsync(DetailQuery query);
        Task AddAsync(Detail detail);
        Task<Detail> FindByIdAsync(int id);
        void Update(Detail detail);
        void Remove(Detail detail);
    }
}
