using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Resturant_Management.Models;

namespace Resturant_Management.busineeslogic
{
    public class BusinessLogic
    {
        private ApplicationDbContext _context;

        private BusinessLogic business;

        public void AddItem(Item item)
        {
            _context = new ApplicationDbContext();
            _context.items.Add(item);
            _context.SaveChanges();


        }


        public void AddServiceman(ServiceMan Servicemans)
        {
            _context = new ApplicationDbContext();
           _context.ServiceMans.Add(Servicemans);
            _context.SaveChanges();


        }


        public int BillIdGeneRator()
        {

            
          _context=new ApplicationDbContext();

          try
          {
              int recetindex = (int) _context.Holdingtable.Max(x => x.holdingReciept);
              return recetindex+1;
          }
          catch (Exception e)
          {
              int recetindex = _context.Reciepts.Max(x=>x.RecieptId);
              return recetindex + 1;
          }






        }

        public Reciept Initialize()
        {
            DateTime now=DateTime.Now;
            var reciept = new Reciept();
            reciept.RecieptNo= BillIdGeneRator();
            reciept.TimeDate = now.ToString("MM/dd/yyyy");
            return reciept;
        }
    }
}