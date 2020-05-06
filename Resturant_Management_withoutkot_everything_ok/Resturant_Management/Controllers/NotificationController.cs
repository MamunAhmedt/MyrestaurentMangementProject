using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using Resturant_Management.Models;

namespace Resturant_Management.Controllers
{
    
    public class NotificationController : Controller
    {

        private Notification Notification;

        private ApplicationDbContext _context;
        // GET: Notification

        public void initializecommonfields()
        {
            _context=new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddNotification(string x,string y)
        {
            return View();
        }


        public JsonResult SaveNotification(string notification,string date)
        {
            Notification=new Notification();
            initializecommonfields();
            
         //   
            
            Notification.NotificationString= notification;
            Notification.ShowingDate = date;
            Notification.Status = "active";
            _context.Notifications.Add(Notification);
            _context.SaveChanges();

            return new JsonResult{Data = "",JsonRequestBehavior = JsonRequestBehavior.AllowGet};
        }
    }
}