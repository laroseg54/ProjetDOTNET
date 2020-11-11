namespace ProjetDOTNET.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Adherents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompteID = c.Int(nullable: false),
                        ResteaPayer = c.Double(nullable: false),
                        DateNaissance = c.DateTime(nullable: false),
                        NumTel = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Comptes", t => t.CompteID, cascadeDelete: true)
                .Index(t => t.CompteID);
            
            CreateTable(
                "dbo.Comptes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                        Prenom = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Creneaux",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SectionID = c.Int(nullable: false),
                        Jour = c.Int(nullable: false),
                        HeureDeb = c.Time(nullable: false, precision: 7),
                        HeureFin = c.Time(nullable: false, precision: 7),
                        NbrPlacesLimite = c.Int(nullable: false),
                        NbrPlaceRestantes = c.Int(nullable: false),
                        CompteID = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Comptes", t => t.CompteID)
                .ForeignKey("dbo.Sections", t => t.SectionID, cascadeDelete: true)
                .Index(t => t.SectionID)
                .Index(t => t.CompteID);
            
            CreateTable(
                "dbo.CreneauAdherents",
                c => new
                    {
                        Creneau_Id = c.Int(nullable: false),
                        Adherent_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Creneau_Id, t.Adherent_Id })
                .ForeignKey("dbo.Creneaux", t => t.Creneau_Id, cascadeDelete: true)
                .ForeignKey("dbo.Adherents", t => t.Adherent_Id, cascadeDelete: true)
                .Index(t => t.Creneau_Id)
                .Index(t => t.Adherent_Id);
            
            AddColumn("dbo.Sections", "Prix", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Creneaux", "SectionID", "dbo.Sections");
            DropForeignKey("dbo.Creneaux", "CompteID", "dbo.Comptes");
            DropForeignKey("dbo.CreneauAdherents", "Adherent_Id", "dbo.Adherents");
            DropForeignKey("dbo.CreneauAdherents", "Creneau_Id", "dbo.Creneaux");
            DropForeignKey("dbo.Adherents", "CompteID", "dbo.Comptes");
            DropIndex("dbo.CreneauAdherents", new[] { "Adherent_Id" });
            DropIndex("dbo.CreneauAdherents", new[] { "Creneau_Id" });
            DropIndex("dbo.Creneaux", new[] { "CompteID" });
            DropIndex("dbo.Creneaux", new[] { "SectionID" });
            DropIndex("dbo.Adherents", new[] { "CompteID" });
            DropColumn("dbo.Sections", "Prix");
            DropTable("dbo.CreneauAdherents");
            DropTable("dbo.Creneaux");
            DropTable("dbo.Comptes");
            DropTable("dbo.Adherents");
        }
    }
}
