using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Resturant_Management.Models
{
    public class DailySummary
    {
        public int DailySummaryId { get; set; }
        public int PreCash { get; set; }
        public float SellAmount { get; set; }
        public float Expendeture { get; set; }

    }
}