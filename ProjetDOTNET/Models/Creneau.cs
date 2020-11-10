using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetDOTNET.Models
{
    public class Creneau
    {
        public Creneau(int sectionID, DayOfWeek jour, TimeSpan heureDeb, TimeSpan heureFin, int nbrPlacesLimite, int idEncandrant)
        {
            SectionID = sectionID;
            Jour = jour;
            HeureDeb = heureDeb;
            HeureFin = heureFin;
            NbrPlacesLimite = nbrPlacesLimite;
            NbrPlaceRestantes = nbrPlacesLimite;
            Adherents = new SortedSet<Adherent>();
            UtilisateurID = idEncandrant;
        }

        public int Id { get; set; }
        public int SectionID { get; set; }

        public DayOfWeek Jour { get; set; }
        public TimeSpan HeureDeb { get; set; }
        public TimeSpan HeureFin { get; set; }
        public int NbrPlacesLimite { get; set; }
        public int NbrPlaceRestantes { get; set; }
        public int UtilisateurID { get; set; }
        public virtual SortedSet<Adherent> Adherents{get; set;}

        
    }
}