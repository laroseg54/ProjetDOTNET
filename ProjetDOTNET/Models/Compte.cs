using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetDOTNET.Models
{
    public class Compte
    {
        public Compte(string nom, string prenom, string email)
        {
            Nom = nom;
            Prenom = prenom;
            Email = email;
        }

        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }

        public string Email { get; set; }
      
    }
}