using ProjetDOTNET.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ProjetDOTNET.dal
{
    public class AssociationContext : DbContext
    {
        public AssociationContext() : base("AssociationBDD")
        { }
        public DbSet<Discipline> Disciplines { get; set; }
        public DbSet<Section> Sections { get; set; }


    }


}