using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Resturant_Management.Models;
using Resturant_Management.ViewModel;

namespace Resturant_Management.Controllers
{
    public class PurchaseController : Controller
    {
        public ApplicationDbContext _Context;
        // GET: Purchase
        public ActionResult Purchase()
        {
            return View();
        }

        public JsonResult save(List<Purchase> purchase)
        {
            _Context=new ApplicationDbContext();
            var status = false;
            foreach ( var data in purchase)
            {

                _Context.Purchases.Add(data);
                _Context.SaveChanges();
                status = true;

            }

            
            return new JsonResult { Data = new { status = status },JsonRequestBehavior = JsonRequestBehavior.AllowGet};

        }

    }
}