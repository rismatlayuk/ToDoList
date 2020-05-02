using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoList.Domain.Models
{
    public class ToDo
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IList<Detail> details { get; set; } = new List<Detail>();

    }
}
