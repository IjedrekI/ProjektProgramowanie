using ProjektProgramowanie.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektProgramowanie.Infrastructure
{
    class ToDoContext : DbContext
    {
        public ToDoContext() 
            : base(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CityInfo;Integrated Security=True;Pooling=False") {}
        //connection string, to aply to your local server need Enable-Migration Add-Migration Update-Database in NuGetConsole
        public DbSet<ToDoItem> ToDoItem { get; set; }
        public DbSet<Worker> Workers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ToDoItem>().ToTable("ToDo");
        }
    }
}
