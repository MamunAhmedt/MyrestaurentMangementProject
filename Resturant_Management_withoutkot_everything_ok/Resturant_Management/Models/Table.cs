using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Migrations.Model;
using System.Linq;
using System.Web;

namespace Resturant_Management.Models
{
    public class Table
    {
        public int TableId { get; set; }
        public string TableNo { get; set; }
          
    }
}