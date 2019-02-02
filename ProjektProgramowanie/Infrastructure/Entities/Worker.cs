using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektProgramowanie.Infrastructure.Entities
{
    public class Worker
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<ToDoItem> ToDoItems { get; set; }
    }
}
