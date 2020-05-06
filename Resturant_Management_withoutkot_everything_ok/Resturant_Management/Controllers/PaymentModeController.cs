using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using Microsoft.Ajax.Utilities;
using Resturant_Management.Models;
using Resturant_Management.ViewModel;

namespace Resturant_Management.Controllers
{
    public class PaymentModeController : Controller
    {
        
        public ApplicationDbContext _Context;

        public List<PaymentMethods> Methodses;
        // GET: PaymentMode
        public ActionResult Index()
        {
            _Context=new ApplicationDbContext();
            Methodses = new List<PaymentMethods>();
            Methodses= _Context.PaymentMethodses.ToList();
            return View(Methodses);
        }
        public ActionResult MasterPage()
        {
            return View();
        }

        public ActionResult Show()
        {

            Show x = new Show();
            List<Show> List = new List<Show>();

            _Context = new ApplicationDbContext();
            float CASCash = _Context.Reciepts.Where(s => s.PaymentMode == "Cash").Sum(s => s.NetAmount);
            x.Name = "Cash";
            x.Amount = CASCash;
            List.Add(x);
            Show y = new Show();
            float CRDCash = _Context.Reciepts.Where(s => s.PaymentMode == "Card").Sum(s => s.NetAmount);
            y.Name = "Card";
            y.Amount = CRDCash;
            List.Add(y);
            Show z = new Show();
            float BKSCash = _Context.Reciepts.Where(s => s.PaymentMode == "Bkash").Sum(s => s.NetAmount);
            z.Name = "Bkash";
            z.Amount = BKSCash;
            List.Add(z);
            Show a = new Show();
            float RKTCash = _Context.Reciepts.Where(s => s.PaymentMode == "Rocket").Sum(s => s.NetAmount);
            a.Name = "Rocket";
            a.Amount = RKTCash;
            List.Add(a);
            return View(List);
        }    

        public JsonResult Save(PaymentMethods data)
        {

            _Context=new ApplicationDbContext();

            _Context.PaymentMethodses.Add(data);

            _Context.SaveChanges();
            return new JsonResult();
        }

        public JsonResult SaveFunds(Funds NewFunds)
        {

            _Context = new ApplicationDbContext();

            _Context.Fundses.Add(NewFunds);

            _Context.SaveChanges();
            return new JsonResult();
        }

        
     
 

        public JsonResult CheckMethodExistanceInDatabase(String Name)
        {
            _Context = new ApplicationDbContext();

           var result = _Context.PaymentMethodses.SqlQuery("Select * from PaymentMethods where PaymentMode =" + "'" + Name + "'");
           var count = result.Count();
           
            
            if(count>0)
            {
                return new JsonResult{Data = "true",JsonRequestBehavior = JsonRequestBehavior.AllowGet};
            }
            else
            {
                return new JsonResult{Data = "false",JsonRequestBehavior = JsonRequestBehavior.AllowGet};
            }
            
        }


        public JsonResult Findelementanddelete(string name)

        {
            _Context = new ApplicationDbContext();
            PaymentMethods p = new PaymentMethods();
            try
            {
                var result = _Context.PaymentMethodses.First(s => s.PaymentMode == name);
                var fundstoremove = _Context.Fundses.First(s => s.FundName == name);
                _Context.Fundses.Remove(fundstoremove);
                _Context.PaymentMethodses.Remove(result);
                _Context.SaveChanges();
                return new JsonResult {Data = "true", JsonRequestBehavior = JsonRequestBehavior.AllowGet};
            }
            catch (Exception e)
            {
                return new JsonResult {Data = "false", JsonRequestBehavior = JsonRequestBehavior.AllowGet};
            }
        }

        public JsonResult getsumofEachPaymentMode()
        {
            _Context=new ApplicationDbContext();

            Dictionary<string,float>sumofvalues=new Dictionary<string, float>();
            List<PaymentMethods> count=_Context.PaymentMethodses.ToList();

            string CashSum,CardSum,BkashSum,RocketSum;

            try
            {
             var  result= _Context.Fundses.Single(x => x.FundName == "Cash");

             CashSum = result.Amount;

            }
            catch (Exception var)
            {
                CashSum = "";
            }


            try
            {
                var result = _Context.Fundses.Single(x => x.FundName == "Card");

                CardSum = result.Amount;

            }
            catch (Exception var)
            {
                CardSum = "";
            }


            try
            {
                var result = _Context.Fundses.Single(x => x.FundName == "Bkash");

                BkashSum= result.Amount;

            }
            catch (Exception var)
            {
                BkashSum= "";
            }

            try
            {
                var result = _Context.Fundses.Single(x => x.FundName == "Rocket");

                RocketSum= result.Amount;

            }
            catch (Exception var)
            {
              RocketSum = "";
            }


            var SumsList = new {Cash = CashSum, Card = CardSum, Bkash = BkashSum, Rocket = RocketSum};

            return new JsonResult{Data = SumsList,JsonRequestBehavior = JsonRequestBehavior.AllowGet};
        }

        public JsonResult Transferfunds(string from,int Amount,string to)
        {
            _Context=new ApplicationDbContext();
            bool flag = true;int FromAmount=0;int ToAmount = 0;
            
            try
            {
                var result = _Context.Fundses.Single(x => x.FundName == from);
                var result2 = _Context.Fundses.Single(x => x.FundName == to);

                  result2.Amount  = (Convert.ToInt32(result2.Amount)+Amount).ToString();
                  result.Amount = (Convert.ToInt32(result.Amount) - Amount).ToString();
                
                _Context.SaveChanges();
                return new JsonResult{Data=flag,JsonRequestBehavior = JsonRequestBehavior.AllowGet};

            }
            catch (Exception var)
            {
                flag = false;
            }
            

            return new JsonResult { Data = flag, JsonRequestBehavior = JsonRequestBehavior.AllowGet };

        }
    }
}