using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvcstock1.Models.Entity;

namespace mvcstock1.Controllers
{
    public class productController : Controller
    {
        mvcstock1Entities ra = new mvcstock1Entities();

        // GET: product
        public ActionResult Index()
        {
            var values = ra.products.ToList();
            return View(values);
        }

        [HttpGet]

        public ActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]

        public ActionResult AddProduct(products s1)
        {
            ra.products.Add(s1);
            ra.SaveChanges();
            return View();
        }
        public ActionResult DELETE(int id)
        {
            var product = ra.products.Find(id);
            ra.products.Remove(product);
            ra.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult BringProduct(int id)
        {
            var product = ra.products.Find(id);
            return View("BringProduct", product);
        }
        public ActionResult Update(products p1)
        {
            var product = ra.products.Find(p1.PRODUCTID);
            product.PRODUCTID = p1.PRODUCTID;
            product.PRODUCTNAME = p1.PRODUCTNAME;
            product.CATEGORY = p1.CATEGORY;
            product.STOCK = p1.STOCK;
            return RedirectToAction("Index");
        }

    }
}