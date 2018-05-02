using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Models
{

    public class Pets
    {
        
        [ScaffoldColumn(false)]
        public int PetsId { get; set; }

    
        [DisplayName("Pet's Name")]
        [Required(ErrorMessage = "A pet name is required.")]
        [StringLength(160)]
        public string PetName { get; set; }


        [DisplayName("Pet's Age")]
        [Required(ErrorMessage = "A pet age is required.")]
        [Range(1, 20,
            ErrorMessage = "Age must be between 1 and 20")]
        public int PetAge { get; set; }

        public string ImagePath { get; set; }

        //[DisplayName("Breed")]
        //public int BreedID { get; set; }

        public string PetDescription { get; set; }

        //public virtual Breed Breed { get; set; }

        public string Address { get; set; }

        public bool Lost { get; set; }
    }
}