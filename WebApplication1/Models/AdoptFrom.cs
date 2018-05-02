using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class AdoptForm
    {
        [ScaffoldColumn(false)]
        public int AdoptFormId { get; set; }

     

        [DisplayName("Insert your name.")]
        public string UserName { get; set; }

        [DisplayName("Insert your home address.")]
        public string Address { get; set; }

        [DisplayName("How many members are there in you family?")]
        public int MemCount { get; set; }

     

        [DisplayName("Have you ever adopted another pet?")]
        public bool HaveAdopted { get; set; }

        [DisplayName("Have you ever had another pet? ")]
        public bool HaveOwned { get; set; }

        [DisplayName("Do you have any other pets? (List them if the answer is yes) ")]
        public string OwnedPet { get; set; }

        [DisplayName("Pet user wishes to adopt. ")]
        public string PetName { get; set; }
    }
}