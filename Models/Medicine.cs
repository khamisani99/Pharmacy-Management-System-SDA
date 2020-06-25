using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class Medicine
    {
        [Display(Name = "MedicineID")]
        public int DrugID { get; set; }
 
        [Required(ErrorMessage = "Medicine name is required.")]
        public string DrugName { get; set; }
 
        [Required(ErrorMessage = "Price is required.")]	
        public int DrugPrice { get; set; }

        [Required(ErrorMessage = "Company is required.")]
        public string DrugCompany { get; set; }

        [Required(ErrorMessage = "Form is required.")]
        public string Form { get; set; }

        [Required(ErrorMessage = "Unit is required.")]
        public string Unit { get; set; }

        [Required(ErrorMessage = "Dose is required.")]
        public string Dose { get; set; }

        [Required(ErrorMessage = "EntryDate is required.")]
        public string EntryDate { get; set; }

        [Required(ErrorMessage = "ExpiryDate is required.")]
        public string ExpiryDate { get; set; }

        [Required(ErrorMessage = "Quantity is required.")]
        public int quantity { get; set; }

        [Required(ErrorMessage = "Type is required.")]
        public string type { get; set; }

    }
}