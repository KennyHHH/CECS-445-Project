using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class PetEntities:DbContext
    {
        public DbSet<Pets> Pet { get; set; }
        //public DbSet<Breed> Breed { get; set; }
    }
}