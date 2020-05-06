using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Resturant_Management.Models
{
    public class Item
    {

        public int ItemId { get; set; }

        [Required (ErrorMessage = "Item Name is Required")]
        [Display (Name = "Name")]
        public String ItemName { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Please enter a value bigger than {0}")]
        [Display(Name = "Price")]
        public int? ItemUnitPrice { get; set; }

        public DiscountRate  DiscountRateOnUnitPrice { get; set; }
        

    }
}