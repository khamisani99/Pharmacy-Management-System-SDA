using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class Employee
    {
        [Display(Name = "ID")]
        public int ID { get; set; }
 
        [Required(ErrorMessage = "Username is required.")]
        public string UserName { get; set; }
 
        [Required(ErrorMessage = "Password is required.")]
        public string UserPassword { get; set; }

        public string UserType { get; set; }

    }
}