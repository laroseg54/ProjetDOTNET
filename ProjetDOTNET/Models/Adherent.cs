using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;

namespace ProjetDOTNET.Models
{
    public class Adherent 
    {
        public Adherent(int numCompte,DateTime dateNaissance, string numTel) 
        {
            
            DateNaissance = dateNaissance;
            ResteaPayer = 0;
            Creneaux = new SortedSet<Creneau>();
            CompteID = numCompte;
        }

        public int Id { get; set; }
        public int CompteID { get; set; }
        public double ResteaPayer { get; set; }
        public DateTime DateNaissance { get; set; }
        public string NumTel { get; set; }
        public virtual Compte Compte { get; set; }

        public virtual SortedSet<Creneau> Creneaux { get; set; }

    }
}