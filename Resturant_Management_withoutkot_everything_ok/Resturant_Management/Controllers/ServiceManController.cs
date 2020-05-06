using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using Resturant_Management.busineeslogic;
using Resturant_Management.Models;

namespace Resturant_Management.Controllers

{
    [Authorize]
    public class ServiceManController : Controller
    {



        private ApplicationDbContext _context = new ApplicationDbContext();

        public List<ServiceMan> ServiceMen;

        public ServiceMan ServiceMans;

        public BusinessLogic businessLogic = new BusinessLogic();

        
        // GET: ServiceMan
        public ActionResult Index()
        {
            return View();
        }



        
        public ActionResult ServiceMan()
        {

            ServiceMen = new List<ServiceMan>();

            ServiceMen = _context.ServiceMans.ToList();

            return View(ServiceMen);


        }


        public ActionResult EditServiceMan(int id)
        {

            var serviceMan = _context.ServiceMans.SingleOrDefault(items => items.ServiceManId == id);
            if (serviceMan == null)
            {
                return HttpNotFound();
            }

            else
            {
                return View("AddItemServiceMan", serviceMan);
            }






        }

        public ActionResult AddItemServiceMan()
        {
            ServiceMans = new ServiceMan();
            return View(ServiceMans);

        }

        [HttpPost]
        public ActionResult AddItemServiceMan(ServiceMan serviceMans)
        {
            if (!ModelState.IsValid)
            {
                return View(ServiceMans);
            }

            {

            }

            if (serviceMans.ServiceManId == 0)
            {
                businessLogic = new BusinessLogic();
                businessLogic.AddServiceman(serviceMans);
            }

            else
            {
                var itemInDb = _context.ServiceMans.SingleOrDefault(c => c.ServiceManId == serviceMans.ServiceManId);
                //create function on busineeslogic
                itemInDb.ServiceManName = serviceMans.ServiceManName;
                itemInDb.ServiceAddress = serviceMans.ServiceAddress;
                itemInDb.ServiceManCellPhoneNo = serviceMans.ServiceManCellPhoneNo;
                itemInDb.Salary = serviceMans.Salary;
                itemInDb.JoiningDate = serviceMans.JoiningDate;
                itemInDb.Designation = serviceMans.Designation;
                itemInDb.Password = serviceMans.Password;


            }

            _context.SaveChanges();




            return RedirectToAction("AddItemServiceMan");
        }

    
}
}

        
