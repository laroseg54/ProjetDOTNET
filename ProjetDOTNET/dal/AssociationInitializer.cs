using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using ProjetDOTNET.Models;
using Microsoft.Ajax.Utilities;

namespace ProjetDOTNET.dal
{
    public class AssociationInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<AssociationContext>
    {
        protected override void Seed(AssociationContext context)
        {
            var disciplines = new SortedSet<Discipline>
            {

                new Discipline("judo","sport de combat japonais, la castagne tout ça tout ça "),
                new Discipline("natation","nager dans l'eau ça fait du bien "),


            };

            disciplines.ForEach(s => context.Disciplines.Add(s));

            var sections = new  SortedSet<Section>
            {
                new Section(1,"judo compétition","le judo ou ça castagne dure pour gagner des sous blyat"),
                new Section(1,"judo loisir","le judo ou ça glande"),
                new Section(2,"natation compét","la natation ou ça nage dure pour gagner des sous blyat"),
                new Section(2,"natation loisir","la natation ou ça glande"),
            };

            sections.ForEach(s => context.Sections.Add(s));
            context.SaveChanges();
        }
    }
}