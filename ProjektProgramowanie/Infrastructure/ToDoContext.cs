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
            : base(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CityInfo;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False") { }
            //: base(@"Data Source=USER-PC\SQLTODO;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False") {}
        //connection string, to apply to your local server need Enable-Migrations Add-Migration Update-Database in NuGetConsole
        public DbSet<ToDoItem> ToDoItems { get; set; }
        public DbSet<Worker> Workers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ToDoItem>()
            .HasRequired<Worker>(s => s.Worker)
            .WithMany(g => g.ToDoItems)
            .HasForeignKey<int>(s => s.WorkerId);
        }
    }
}
