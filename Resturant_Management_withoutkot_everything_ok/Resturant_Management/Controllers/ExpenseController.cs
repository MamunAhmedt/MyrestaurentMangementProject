using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Resturant_Management.Models;

namespace Resturant_Management.Controllers
{
    public class ExpenseController : Controller
    {

        public ApplicationDbContext _Context { get; set; }
        // GET: Expense
        public ActionResult Expense()
        {
            return View();
        }


        public JsonResult save(List<Expense>expenses)
        {
            _Context=new ApplicationDbContext();
            var status = false;

            foreach (var item in expenses)
            {
                _Context.Expenses.Add(item);
                _Context.SaveChanges();
                status = true;
            }



            return new JsonResult { Data = new {status=status}, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
    }
}