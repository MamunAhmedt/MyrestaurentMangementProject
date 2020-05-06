using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Resturant_Management.Models
{
    public class ServiceMan
    {
        [Display (Name = "ID")]
        public int ServiceManId { get; set; }
        [Required]
        [Display(Name = "Name")]
        public String ServiceManName { get; set; }
        [Required]
        [Display(Name = "Address")]
        public String ServiceAddress { get; set; }
        [Required]
        [Display(Name = "Phone")]
        public String ServiceManCellPhoneNo { get; set; }

        [Display(Name = "Salary")]
        public int Salary { get; set; }
        [Display(Name = "Joining-Date")]
        [Required]
        public DateTime JoiningDate { get; set; }
        [Required]
        public string Designation { get; set; }
        [Required]
        public string  Password { get; set; }

        

    }
}