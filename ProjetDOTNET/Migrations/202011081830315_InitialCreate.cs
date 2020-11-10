namespace ProjetDOTNET.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Disciplines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sections",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DisciplineID = c.Int(nullable: false),
                        Nom = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Disciplines", t => t.DisciplineID, cascadeDelete: true)
                .Index(t => t.DisciplineID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sections", "DisciplineID", "dbo.Disciplines");
            DropIndex("dbo.Sections", new[] { "DisciplineID" });
            DropTable("dbo.Sections");
            DropTable("dbo.Disciplines");
        }
    }
}
