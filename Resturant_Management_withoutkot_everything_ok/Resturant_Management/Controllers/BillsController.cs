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
    public class BillsController : Controller
    {
   private  ApplicationDbContext _context;
   private BusinessLogic businessLogic;
   public List<Item> Items;
        

        public BillsController()
        {
            _context=new ApplicationDbContext();
        }
         
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Bill
        public ActionResult Index()
        {
            var product = new Item();
            product.ItemId = 12;
            product.ItemName = "Chicken Burger";
            return View();
        }

        
        public ActionResult Product()
        {
            Items = new List<Item>();

            Items = _context.items.ToList();

            return View(Items);


        }

        public JsonResult GetPayMethods()
        { 
            var paymethods=new List<PaymentMethods>();
            paymethods = _context.PaymentMethodses.ToList();
            return new JsonResult{Data = paymethods,JsonRequestBehavior = JsonRequestBehavior.AllowGet};
        }

        public JsonResult GetProducts()
        {

            var Items = new List<Item>();

            Items = _context.items.ToList();

            return new JsonResult { Data = Items, JsonRequestBehavior = JsonRequestBehavior.AllowGet };

        }

        
        public JsonResult GetServiceBoy()
        {

            var ServiceBoy= new List<ServiceMan>();

            ServiceBoy= _context.ServiceMans.ToList();

            return new JsonResult { Data = ServiceBoy, JsonRequestBehavior = JsonRequestBehavior.AllowGet };

        }
         

        public JsonResult GetTable()
        {

            var Table = new List<Table>();

            Table = _context.Tables.ToList();

            return new JsonResult { Data = Table, JsonRequestBehavior = JsonRequestBehavior.AllowGet };

        }

        public JsonResult GetProductUnitPrice(int id)
        {
            //int ID = Convert.ToInt32(id);

            var product = _context.items.SingleOrDefault(c => c.ItemId == id);

            return new JsonResult { Data = product, JsonRequestBehavior = JsonRequestBehavior.AllowGet };

        }






        [HttpPost]
        public JsonResult save(Reciept order)
        {
         

            _context = new ApplicationDbContext();
            var FundsTobeUpdated = _context.Fundses.Single(Name => Name.FundName == order.PaymentMode);
            var Amount = Convert.ToInt32(FundsTobeUpdated.Amount )+ Convert.ToInt32(order.NetAmount);
            FundsTobeUpdated.Amount = Amount.ToString();


            _context.Reciepts.Add(order);
            
            _context.SaveChanges();

            bool status = true;

            /*
            
            DateTime dateOrg;
            var isValidDate = DateTime.TryParseExact(order.OrderDateString, "mm-dd-yyyy", null, System.Globalization.DateTimeStyles.None, out dateOrg);
            if (isValidDate)
            {
                order.OrderDate = dateOrg;
            }

            var isValidModel = TryUpdateModel(order);
            if (isValidModel)
            {
                using (MyDatabaseEntities dc = new MyDatabaseEntities())
                {
                    dc.OrderMasters.Add(order);
                    dc.SaveChanges();
                    status = true;
                }
            }
             * */
            return new JsonResult { Data = new { status = status } };
        }


        public ActionResult EditItem(int id)
        {

            var item = _context.items.SingleOrDefault(items => items.ItemId == id);
            if (item == null)
            {
             return HttpNotFound();
            }

            else
            {
                return View("AddItem", item);
            }






        }
       
        public ActionResult AddItem()
        {
            var Additem=new Item();
            return View(Additem);

        }

        [HttpPost]
        public ActionResult AddItem(Item item)
        {
            if (!ModelState.IsValid)
            {
                return View(item);
            }

            {
                
            }

            if (item.ItemId==0)
            {
                businessLogic = new BusinessLogic();
                businessLogic.AddItem(item);
            }
            else
            {
                var itemInDb = _context.items.SingleOrDefault(c => c.ItemId == item.ItemId);
                //create function on busineeslogic
                itemInDb.ItemName = item.ItemName;
                itemInDb.ItemUnitPrice = item.ItemUnitPrice;
                itemInDb.DiscountRateOnUnitPrice.DiscountOnUnitPrice = item.DiscountRateOnUnitPrice.DiscountOnUnitPrice;

            }
            _context.SaveChanges();


            

            return RedirectToAction("AddItem");
        }

        public JsonResult BillIdGenerator()
        {
            businessLogic=new BusinessLogic();
          int billId=  businessLogic.BillIdGeneRator();

          return new JsonResult{Data = billId,JsonRequestBehavior = JsonRequestBehavior.AllowGet};

        }

       

    }
}