using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Resturant_Management.Models;

namespace Resturant_Management.Controllers
{

    public class LoginController : Controller
    {
        public ServiceMan ServiceMan { get; set; }
        public ApplicationDbContext Context { get; set; }

        public ActionResult Login()
        {
            ServiceMan = new ServiceMan();

            return View(ServiceMan);
        }

        [HttpPost]
        public ActionResult Login(ServiceMan serviceMans)

        {

            var id = (serviceMans.ServiceManId);
            Context = new ApplicationDbContext();
            bool isvalid = Context.ServiceMans.Any(s => s.ServiceManId == id && s.Password == serviceMans.Password);
            if (isvalid)
            {
                var user = Context.ServiceMans.SingleOrDefault(s =>
                    s.ServiceManId == id && s.Password == serviceMans.Password);
                FormsAuthentication.SetAuthCookie(user.Designation, false);

                return RedirectToAction("Index", "Home");
            }

            ViewBag.ErrorMessage = "Id or password Doesn,t Match";
            return RedirectToAction("Login", "Login");

        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    
}
}