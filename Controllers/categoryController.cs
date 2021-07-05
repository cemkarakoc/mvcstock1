using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvcstock1.Models.Entity;

namespace mvcstock1.Controllers
{
    public class CategoryController : Controller
    {
        mvcstock1Entities db = new mvcstock1Entities();
        public ActionResult Index()
        {
            var values = db.categories.ToList();
            return View(values);
        }
        
        [HttpGet]

        public ActionResult NewCategory()
        {
            return View();
        }

        [HttpPost]

        public ActionResult NewCategory(categories p1)
        {
            if (!ModelState.IsValid)
            {
                return View("NewCategory");
            }

            db.categories.Add(p1);
            db.SaveChanges();
            return View();
        }

        public ActionResult DELETE(int id)
        {
            var category = db.categories.Find(id);
            db.categories.Remove(category);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult BringCategory(int id)
        {
            var ctgr = db.categories.Find(id);
            return View("BringCategory", ctgr);
        }

        public ActionResult Update(categories p1)
        {
            var ctgr = db.categories.Find(p1.CATEGORYID);
            ctgr.CATEGORYNAME = p1.CATEGORYNAME;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}