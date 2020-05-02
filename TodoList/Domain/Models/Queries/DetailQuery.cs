using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoList.Domain.Models.Queries
{
    public class DetailQuery : Query
    {
        public int? ToDoId { get; set; }

        public DetailQuery(int? toDoId, int page, int itemsPerPage) : base(page, itemsPerPage)
        {
            ToDoId = toDoId;
        }
    }
}
