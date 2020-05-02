using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoList.Domain.Models
{
    public class Detail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Check { get; set; }


        public int ToDoId { get; set; }
        public ToDo ToDo { get; set; }
    }
}
