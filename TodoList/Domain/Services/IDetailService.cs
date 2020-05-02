using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoList.Domain.Models;
using TodoList.Domain.Models.Queries;
using TodoList.Domain.Services.Communication;

namespace TodoList.Domain.Services
{
    public interface IDetailService
    {
        Task<QueryResult<Detail>> ListAsync(DetailQuery query);
        Task<DetailResponse> SaveAsync(Detail detail);
        Task<DetailResponse> UpdateAsync(int id, Detail detail);
        Task<DetailResponse> DeleteAsync(int id);
    }
}
