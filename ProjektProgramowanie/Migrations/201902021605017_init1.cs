namespace ProjektProgramowanie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ToDoItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Shop = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Notes = c.String(),
                        Date = c.DateTime(),
                        WorkerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Workers", t => t.WorkerId, cascadeDelete: true)
                .Index(t => t.WorkerId);
            
            CreateTable(
                "dbo.Workers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ToDoItems", "WorkerId", "dbo.Workers");
            DropIndex("dbo.ToDoItems", new[] { "WorkerId" });
            DropTable("dbo.Workers");
            DropTable("dbo.ToDoItems");
        }
    }
}
