using AJAX1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AJAX1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult GetCustomersByCity (string city)
        {
            NorthwindEntities db = new NorthwindEntities();

            //LINQ version:
            /*List<Customer> list = (
                from c in db.Customers
                where c.City == city
                select c
                ).ToList();*/
            //exact same thing in a Lambda expression
            /*List<Customer> list = db.Customers.Where(
                c=>c.City.Equals(city)
                ).ToList();*/
            List<Customer> list = db.Customers.Where(
               c => c.City.StartsWith(city)
                ).ToList();

            return Json(list);
        }

        [HttpPost]
        public ActionResult GetProductsByName(string pname)
        {
            NorthwindEntities db = new NorthwindEntities();
            
            List<Product> list = db.Products.Where(
               p => p.ProductName.Contains(pname)
                ).ToList();

            return Json(list);
        }
    }
}