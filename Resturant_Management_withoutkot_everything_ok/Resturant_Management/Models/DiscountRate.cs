using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Resturant_Management.Models
{
    public class DiscountRate
    {
        public int DiscountOnUnitPrice { get; set; }

        public int DiscountOnGrandTotal { get; set; }
    }
}