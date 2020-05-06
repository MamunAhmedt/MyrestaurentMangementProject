using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Resturant_Management.Models
{
    public class OrderedItems
    {
        [Key]
        public int OrderItemsId { get; set; }
        public int productId { get; set; }
        public String ProductName { get; set; }
        public int Quantity { get; set; }
        public int DiscountRate { get; set; }
        


        

    }
}