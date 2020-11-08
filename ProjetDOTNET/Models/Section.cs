using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetDOTNET.Models
{
    public class Section : IComparable<Section>
    {
        public Section(int idDiscipline, string nom, string description)
        {
            DisciplineID = idDiscipline;
            Nom = nom;
            Description = description;
        }
        public Section(){}

        public int Id { get; set; }
        public int DisciplineID { get; set; }
        public string Nom { get; set; }
        public string Description { get; set; }

        public virtual Discipline Discipline { get; set; }
        public int CompareTo(Section obj)
        {
            return Nom.CompareTo(obj.Nom);
        }
    }
}