using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetDOTNET.Models
{
    public class Adherent : Utilisateur
    {
        public Adherent(string nom, string prenom, string email,DateTime dateNaissance, string numTel, SortedSet<Creneau> creneaux) : base(nom, prenom, email)
        {
            
            DateNaissance = dateNaissance;
            NumTel = numTel;
            Creneaux = creneaux;
            ResteaPayer = 0;
            Creneaux = new SortedSet<Creneau>();
        }

     
        public double ResteaPayer { get; set; }
        public DateTime DateNaissance { get; set; }
        public string NumTel { get; set; }

        public virtual SortedSet<Creneau> Creneaux { get; set; }

    }
}