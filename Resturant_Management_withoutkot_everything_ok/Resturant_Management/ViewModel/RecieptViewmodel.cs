using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Resturant_Management.Models;

namespace Resturant_Management.ViewModel
{
    public class RecieptViewmodel
    {
        public IEnumerable<Item> Item { get; set; }
        public IEnumerable<ServiceMan> ServiceMans { get; set; }
    }
}