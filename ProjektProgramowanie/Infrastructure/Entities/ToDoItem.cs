using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektProgramowanie.Infrastructure
{
    public class ToDoItem
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public Shop Shop { get; set; }
        public int Quantity { get; set; }
        public string Notes { get; set; }
        public DateTime? Date { get; set; }

        //[Key ]
        public int WorkerId { get; set; }
        public Entities.Worker Worker { get; set; }
    }
}
