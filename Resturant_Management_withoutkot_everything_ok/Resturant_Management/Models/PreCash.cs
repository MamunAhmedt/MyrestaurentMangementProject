using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Resturant_Management.Models
{
    public class PreCash
    {
        [Key]
        public int PreCashId { get; set; }
        public float PreCashAmount { get; set; }
        public string TimeDate { get; set; }    
    }
}