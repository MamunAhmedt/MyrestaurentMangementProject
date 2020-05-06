using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Resturant_Management.busineeslogic;
using Resturant_Management.Models;

namespace Resturant_Management.Controllers
{
    [Authorize]
    public class RecieptController : Controller
    {
        public ApplicationDbContext _Context;
        BusinessLogic businessLogic=new BusinessLogic();
       

      /*  public ActionResult Index()
        {
            return View();
        }
       * */

      public ActionResult RecieptPage()
      {

      _Context=new ApplicationDbContext();
        var reciept= businessLogic.Initialize();
        return View(reciept);
        }


    

    }
}