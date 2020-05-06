using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Resturant_Management.Models
{
    public class Notification
    {
        public int NotificationId { get; set; }
        [Display(Name = "Notification String")]
        public String NotificationString { get; set; }
        [Display(Name = "Date-Of-Show")]
        public string ShowingDate { get; set; }
        public string Status { get; set; }
    }
}