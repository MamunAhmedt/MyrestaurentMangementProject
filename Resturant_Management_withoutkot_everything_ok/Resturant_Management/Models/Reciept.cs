using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Resturant_Management.Models
{
    public class Reciept
    {
        [Key]
        public int RecieptId { get; set; }
    
        public int RecieptNo { get; set; }
        public int ServiceBoyid { get; set; }
        public int TableNo { get; set; }
        
        public float NetAmount { get; set; }
        public string PaymentMode { get; set; }
        public List<OrderedItems> OrderedItems { get; set; }
        public string TimeDate { get; set; }

    }
}