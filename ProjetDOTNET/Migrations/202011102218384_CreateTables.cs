namespace ProjetDOTNET.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Utilisateurs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                        Prenom = c.String(),
                        Email = c.String(),
                        ResteaPayer = c.Double(),
                        DateNaissance = c.DateTime(),
                        NumTel = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
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
                        UtilisateurID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CreneauAdherents",
                c => new
                    {
                        Creneau_Id = c.Int(nullable: false),
                        Adherent_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Creneau_Id, t.Adherent_Id })
                .ForeignKey("dbo.Creneaux", t => t.Creneau_Id, cascadeDelete: true)
                .ForeignKey("dbo.Utilisateurs", t => t.Adherent_Id, cascadeDelete: true)
                .Index(t => t.Creneau_Id)
                .Index(t => t.Adherent_Id);
            
            AddColumn("dbo.Sections", "Prix", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CreneauAdherents", "Adherent_Id", "dbo.Utilisateurs");
            DropForeignKey("dbo.CreneauAdherents", "Creneau_Id", "dbo.Creneaux");
            DropIndex("dbo.CreneauAdherents", new[] { "Adherent_Id" });
            DropIndex("dbo.CreneauAdherents", new[] { "Creneau_Id" });
            DropColumn("dbo.Sections", "Prix");
            DropTable("dbo.CreneauAdherents");
            DropTable("dbo.Creneaux");
            DropTable("dbo.Utilisateurs");
        }
    }
}
