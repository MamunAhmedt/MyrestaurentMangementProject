using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Resturant_Management.Models;

namespace Resturant_Management.Controllers
{
    public class HoldingTableController : Controller
    {
        private HoldingTable Newtable;
        private ApplicationDbContext _context;
        
        // GET: HoldingTable
        public ActionResult Index()
        {
            _context=new ApplicationDbContext();
            
            return View();
        }

        public JsonResult SaveHoldingTableReciept(string RecieptNo)
        {
            bool status = false;
            Newtable = new HoldingTable();
            _context = new ApplicationDbContext();

            var holdingReciept = Convert.ToInt64(RecieptNo);

            if (_context.Holdingtable.Any(x=>x.holdingReciept==holdingReciept))
            {
               
                return new JsonResult{Data =status,JsonRequestBehavior = JsonRequestBehavior.AllowGet};
            }
            
          

            Newtable.holdingReciept = holdingReciept;
            _context.Holdingtable.Add(Newtable);
            _context.SaveChanges();
             status = true;
            return new JsonResult { Data = status, JsonRequestBehavior = JsonRequestBehavior.AllowGet };

        }

        public JsonResult GetAllHoldingTableReciept()
        {
            _context = new ApplicationDbContext();

            var allHoldingtable = new List<HoldingTable>();
            allHoldingtable=_context.Holdingtable.ToList();

            return new JsonResult { Data = allHoldingtable, JsonRequestBehavior = JsonRequestBehavior.AllowGet};


        }
        public JsonResult GetClickedHoldingTableReciept(long RecieptNo)
        {

            _context = new ApplicationDbContext();

            var clickedtable = _context.Holdingtable.Single(x => x.holdingReciept == RecieptNo);

            return new JsonResult { Data = clickedtable, JsonRequestBehavior = JsonRequestBehavior.AllowGet};

        }

        public JsonResult DeleteAllHoldingTableReciept(long RecieptNo)
        {
            _context = new ApplicationDbContext();

            var deleteTable = _context.Holdingtable.Single(x => x.holdingReciept == RecieptNo);

            _context.Holdingtable.Remove(deleteTable);
            _context.SaveChanges();

            return new JsonResult();




        }
    }
}