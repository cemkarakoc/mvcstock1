using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvcstock1.Models.Entity;

namespace mvcstock1.Controllers
{
    public class CustomerController : Controller
    {
        // GET: customer
        mvcstock1Entities db = new mvcstock1Entities();
        public ActionResult Index()
        {
            var values = db.customers.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult NewCustomer()
        {
            return View();
        }
        [HttpPost]

        public ActionResult NewCustomer(customers p1)
        {
            if(!ModelState.IsValid)
            {
                return View("NewCustomer");
            }
            db.customers.Add(p1);
            db.SaveChanges();
            return View();
        }

        public ActionResult DELETE(int id)
        {
            var customer = db.customers.Find(id);
            db.customers.Remove(customer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult BringCustomer(int id)
        {
            var cst = db.customers.Find(id);
            return View("BringCustomer", cst);
        }

        public ActionResult Update(customers p1)
        {
            var customer = db.customers.Find(p1.CUSTOMERID);
            customer.CUSTOMERNAME = p1.CUSTOMERNAME;
            customer.CUSTOMERSURNAME = p1.CUSTOMERSURNAME;
            db.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}