using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using Resturant_Management.Models;
using Resturant_Management.ViewModel;

namespace Resturant_Management.Controllers
{
    public class ItemsController : Controller
    {
       public List<OrderedItems>orderedProduct=new List<OrderedItems>();
       public List<OrderedItems> TopSells;
 
      
        public ApplicationDbContext _Context;

        public ActionResult TopsoldItems()
        {
            var status =0;
            _Context = new ApplicationDbContext();
            TopSells=new List<OrderedItems>();

            var items = _Context.Reciepts.Include(s => s.OrderedItems).ToList();

            foreach (var item in items)
            {

                orderedProduct.AddRange(item.OrderedItems);

            }

            if (orderedProduct.Count != 0)
            {



                foreach (var x in orderedProduct)
                {
                    {

                    }
                    if (TopSells.Count == 0)
                    {
                        TopSells.Add(x);
                        
                    }

                    else
                    {
                        status = 1;
                        
                        var id = x.productId;
                        var quantity = x.Quantity;

                        foreach (var y in TopSells)
                        {
                            if (y.productId == id)
                            {
                                y.Quantity = y.Quantity + quantity;
                                status = 2;
                                break;
                               

                            }
                            
                           
                            

                        }

                       

                       

                      

                       


                    }


                    if (status == 1)
                    {
                        TopSells.Add(x);

                    }

                    

                }

                return View(TopSells);
            }


            else
            {
                
            }

            return View();
        }
       

    }


        }


        
    
