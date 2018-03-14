using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Example : DropCreateDatabaseIfModelChanges<PetEntities>
    {
        protected override void Seed(PetEntities context)
        {
            var breeds = new List<Breed>
            {
                new Breed{Name = "Husky"},
                new Breed{Name = "Golden Retriever"}
            };
        }
    }
}