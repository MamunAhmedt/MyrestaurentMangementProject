using Resturant_Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Resturant_Management.Controllers
{
    [Authorize]
    public class RecieptAccountController : Controller
    {


        private ApplicationDbContext _context;
        
        public ActionResult Index()
        {
            _context = new ApplicationDbContext();
            var Items = _context.Reciepts.SqlQuery("select * from Reciepts ").ToList<Reciept>();
                return View(Items);
        }

        
        public ActionResult SearchSalesReport()
        {
            return View();
        }


        /*
        public ActionResult GetDailySales(string DateFrom,string DateTo)
        {
            var x = DateFrom;
            var y = DateTo;
            _context = new ApplicationDbContext();
            if (x == "0NaN/0NaN/NaN" && y == "0NaN/0NaN/NaN")
            {
                var Items = _context.Reciepts.SqlQuery("select * from Reciepts").ToList<Reciept>();
                return View("Index", Items);
            }
            return View();
            
        }
         * */
        
       // Getting Reciepts Data From Database From Javascipt Function
        public JsonResult GetDailySales(string DateFrom, string DateTo)
        {
            var Items = new List<Reciept>();
            _context = new ApplicationDbContext();
            var x = DateFrom;
            var y = DateTo;
            var Nul = "NaN/NaN/NaN/";
            
            if (x == Nul && y ==Nul)
            {
                    Items = _context.Reciepts.SqlQuery("select * from Reciepts").ToList<Reciept>();

            }
            if (x != Nul && y == Nul)

            {
                    //Items = _context.Reciepts.SqlQuery("select * from Reciepts").ToList<Reciept>();
                Items = _context.Reciepts.SqlQuery("select * from Reciepts Where TimeDate="+"'"+x+"'" ).ToList<Reciept>();



            }

            if (x == Nul && y != Nul) 
            {
               //Items = _context.Reciepts.SqlQuery("select * from Reciepts").ToList<Reciept>();
               Items = _context.Reciepts.SqlQuery("select * from Reciepts Where TimeDate=" + "'" + y + "'").ToList<Reciept>();
            }



            if (x !=Nul && y != Nul) 
            {
                
              var Item1 = _context.Reciepts.SqlQuery("select * from Reciepts Where TimeDate=" + "'" + x + "'").ToList<Reciept>();
              if (Item1.Count==0)
              {
                  return new JsonResult { Data = Items, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
              }

               
               var Item2=_context.Reciepts.SqlQuery("select * from Reciepts Where TimeDate=" + "'" + y + "'").ToList<Reciept>();


               if (Item2.Count == 0)
               {
                   return new JsonResult { Data = Items, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
               }
                

               var lastIndex = Item2.Count;

               var Start = Item1[0].RecieptId;
               var End = Item2[lastIndex-1].RecieptId;


               //Items = _context.Reciepts.Where(s => s.RecieptId >= Start && s.RecieptId <= End).ToList();

               /*
               Items = new List<Reciept>(Item1.Count + Item2.Count).ToList();
               Items.AddRange(Item1);
               Items.AddRange(Item2);
               /*
              */
               



               Items = _context.Reciepts.Where(s => s.RecieptId >= Start && s.RecieptId <= End).ToList();
              // Items=new List<Reciept>()
               //Items = Item1.Concat(Item1);


            }

          


         

            return new JsonResult { Data=Items, JsonRequestBehavior = JsonRequestBehavior.AllowGet };

        }
        
        public ActionResult DashBoard()
        {
            return View();
        }

        public JsonResult GetDailyExpenseSum(string date)
        {
            _context=new ApplicationDbContext();


            var sumOfCurrentDateExpense = _context.Reciepts.Where(s => s.TimeDate == date).Sum(i => i.NetAmount);

            return new JsonResult {Data=sumOfCurrentDateExpense,JsonRequestBehavior = JsonRequestBehavior.AllowGet};
        }
        public JsonResult GetPreCashAmount(string date)
        {
            _context = new ApplicationDbContext();


            var PreCahAmount = _context.PreCash.Where(s => s.TimeDate == date).Select(i => i.PreCashAmount).SingleOrDefault();

            return new JsonResult { Data = PreCahAmount, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public ActionResult GetCurrentDateExpense(string date)
        {
            var todayExpenseSum = 0;
            var todaySalesSum = 0.0;
            _context=new ApplicationDbContext();

            if (_context.Expenses.Where(s=>s.Date == date).Sum(i=>i.Amount)!=null)
            {
                todayExpenseSum = _context.Expenses.Where(s => s.Date == date).Sum(i => i.Amount); 
            }



            if (_context.Purchases.Where(s=>s.PurchaseDate == date).Sum(i => i.NetAmount)!=null)
            {
               todaySalesSum = _context.Purchases.Where(s=>s.PurchaseDate == date).Sum(i => i.NetAmount);
            }
         
            var totalExpense = todaySalesSum + todayExpenseSum;

            return new JsonResult{Data =totalExpense,JsonRequestBehavior = JsonRequestBehavior.AllowGet};


        }





        public JsonResult TodaysSales(string date)
        {
            _context=new ApplicationDbContext();
            var Items = new List<Reciept>();
            Items = _context.Reciepts.SqlQuery("select * from Reciepts Where TimeDate=" + "'" + date + "'").ToList<Reciept>();

            return new JsonResult {Data = Items, JsonRequestBehavior = JsonRequestBehavior.AllowGet};
        }


        public JsonResult TodaysNotification(string date)
        {

            _context = new ApplicationDbContext();
            var Items = new List<Notification>();
            Items = _context.Notifications.SqlQuery("select * from Notifications Where ShowingDate=" + "'" + date + "'").ToList<Notification>();

            return new JsonResult { Data = Items, JsonRequestBehavior = JsonRequestBehavior.AllowGet };


        }


        public JsonResult RemoveNotification(string NotificationId)
        {
            _context=new ApplicationDbContext();
             var id= Convert.ToInt32(NotificationId);
            var removeItem = _context.Notifications.SingleOrDefault(s => s.NotificationId == id);
            _context.Notifications.Remove(removeItem);
            bool status = true;
            _context.SaveChanges();

            return new JsonResult {JsonRequestBehavior = JsonRequestBehavior.AllowGet}; ;
        }



    }
}