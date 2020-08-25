using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using THE_PROJECT.Models;


namespace THE_PROJECT.Controllers
{
    public class productsController : Controller
    {
        private db_newproEntities db = new db_newproEntities();

        // GET: products
        public ActionResult Index()
        {
            return View(db.products.ToList());
        }
        public PartialViewResult lastbill()
        {
            var bb = db.bills.OrderByDescending(b=>b.date.ToString()).First();
            return PartialView("_lastbill",bb);
        }
        public ActionResult search(string productname)
        {
            var products = db.products.Where(p => p.name.StartsWith(productname));
            return View("index",products.ToList());
        }
        public ContentResult addproduct(string productname1,decimal pprice)
        {
            product p = new product()
            {
                name = productname1,
                price = pprice,
                quantity=454,
                notes= "dfdfdd151",
                code="11547"
            };
            db.products.Add(p);
            db.SaveChanges();


            return Content("<li> product saved successfully-" + productname1 + "--" + pprice + "</li>");
        }
        public PartialViewResult partialsearch(string productname)
        {
            var products = db.products.Where(p => p.name.StartsWith(productname));
            return PartialView("_partialgrid", products.ToList());
        }

        // GET: products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            product product = db.products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        
       
        
        public ActionResult Create([Bind(Include = "id,name,code,price,quantity,notes,image")] product product)
        {
            if (ModelState.IsValid)
            {
                db.products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product);
        }

        // GET: products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            product product = db.products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,code,price,quantity,notes,image")] product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            product product = db.products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            product product = db.products.Find(id);
            db.products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
