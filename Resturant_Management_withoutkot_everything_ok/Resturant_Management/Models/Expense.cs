using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Resturant_Management.Models
{
    public class Expense
    {
        [Key]
        public int ExpenseId { get; set; }
        public string Category { get; set; }
        public int Amount { get; set; }
        public String Description { get; set; }
        public string Date { get; set; }    
    }
}