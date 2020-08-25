using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using THE_PROJECT.Models;

namespace THE_PROJECT.Controllers
{
    public class billsController : Controller
    {
        private db_newproEntities db = new db_newproEntities();

        // GET: bills
        public ActionResult Index()
        {
            var bills = db.bills.Include(b => b.customer).Include(b => b.user);
            return View(bills.ToList());
        }

        // GET: bills/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            bill bill = db.bills.Find(id);
            if (bill == null)
            {
                return HttpNotFound();
            }
            return View(bill);
        }

        // GET: bills/Create
        public ActionResult Create()
        {
            ViewBag.customers_id = new SelectList(db.customers, "id", "name");
            ViewBag.users_id = new SelectList(db.users, "id", "user_name");
            return View();
        }

        // POST: bills/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,date,notes,customers_id,total,discount,total_af_dis,users_id")] bill bill)
        {
            if (ModelState.IsValid)
            {
                db.bills.Add(bill);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.customers_id = new SelectList(db.customers, "id", "name", bill.customers_id);
            ViewBag.users_id = new SelectList(db.users, "id", "user_name", bill.users_id);
            return View(bill);
        }

        // GET: bills/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            bill bill = db.bills.Find(id);
            if (bill == null)
            {
                return HttpNotFound();
            }
            ViewBag.customers_id = new SelectList(db.customers, "id", "name", bill.customers_id);
            ViewBag.users_id = new SelectList(db.users, "id", "user_name", bill.users_id);
            return View(bill);
        }

        // POST: bills/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,date,notes,customers_id,total,discount,total_af_dis,users_id")] bill bill)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bill).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.customers_id = new SelectList(db.customers, "id", "name", bill.customers_id);
            ViewBag.users_id = new SelectList(db.users, "id", "user_name", bill.users_id);
            return View(bill);
        }

        // GET: bills/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            bill bill = db.bills.Find(id);
            if (bill == null)
            {
                return HttpNotFound();
            }
            return View(bill);
        }

        // POST: bills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            bill bill = db.bills.Find(id);
            db.bills.Remove(bill);
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
