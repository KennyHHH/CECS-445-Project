using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Models
{
    
    public class Adopt
    {
        [ScaffoldColumn(false)]
        public int AdoptId { get; set; }

        public string APetName { get; set; }

        public string ImagePath { get; set; }

        public string APetDescription { get; set; }
    }
}