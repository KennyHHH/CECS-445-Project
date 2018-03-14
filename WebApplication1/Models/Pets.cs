using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Pets
    {
       [Key]
        public int PetID { get; set; }

    
        [Required(ErrorMessage = "A pet name is required.")]
        [StringLength(160)]
        public string PetName { get; set; }

        
        [Required(ErrorMessage = "A pet age is required.")]
        [Range(1, 20,
            ErrorMessage = "Age must be between 1 and 20")]
        public int PetAge { get; set; }

        //[DisplayName("Breed")]
        //public int BreedID { get; set; }

        public string PetDescription { get; set; }

        //public virtual Breed Breed { get; set; }

    }
}