using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using cmcglynn_financialPortal.Models;
using cmcglynn_financialPortal.Models.CodeFirst;

namespace cmcglynn_financialPortal.Controllers
{
    [AuthorizeHouseHoldRequired]
    public class BudgetsController : Universal
    {
        //private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Budgets
        public ActionResult Index()
        {
            var budgets = db.Budgets.Include(b => b.Author).Include(b => b.Category).Include(b => b.Frequency).Include(b => b.HouseHold);
            return View(budgets.ToList());
        }

        // GET: Budgets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Budgets budgets = db.Budgets.Find(id);
            if (budgets == null)
            {
                return HttpNotFound();
            }
            return View(budgets);
        }

        // GET: Budgets/Create
        public ActionResult Create()
        {
            ViewBag.AuthorId = new SelectList(db.Users, "Id", "FirstName");
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name");
            ViewBag.FrequencyId = new SelectList(db.Frequency, "Id", "Name");
            ViewBag.HouseHoldId = new SelectList(db.HouseHold, "Id", "Name");
            return View();
        }

        // POST: Budgets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,AuthorId,CategoryId,FrequencyId,Description,HouseHoldId,Item")] Budgets budgets)
        {
            if (ModelState.IsValid)
            {
                db.Budgets.Add(budgets);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AuthorId = new SelectList(db.Users, "Id", "FirstName", budgets.AuthorId);
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", budgets.CategoryId);
            ViewBag.FrequencyId = new SelectList(db.Frequency, "Id", "Name", budgets.FrequencyId);
            ViewBag.HouseHoldId = new SelectList(db.HouseHold, "Id", "Name", budgets.HouseHoldId);
            return View(budgets);
        }

        // GET: Budgets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Budgets budgets = db.Budgets.Find(id);
            if (budgets == null)
            {
                return HttpNotFound();
            }
            ViewBag.AuthorId = new SelectList(db.Users, "Id", "FirstName", budgets.AuthorId);
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", budgets.CategoryId);
            ViewBag.FrequencyId = new SelectList(db.Frequency, "Id", "Name", budgets.FrequencyId);
            ViewBag.HouseHoldId = new SelectList(db.HouseHold, "Id", "Name", budgets.HouseHoldId);
            return View(budgets);
        }

        // POST: Budgets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AuthorId,CategoryId,FrequencyId,Description,HouseHoldId,Item")] Budgets budgets)
        {
            if (ModelState.IsValid)
            {
                db.Entry(budgets).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AuthorId = new SelectList(db.Users, "Id", "FirstName", budgets.AuthorId);
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", budgets.CategoryId);
            ViewBag.FrequencyId = new SelectList(db.Frequency, "Id", "Name", budgets.FrequencyId);
            ViewBag.HouseHoldId = new SelectList(db.HouseHold, "Id", "Name", budgets.HouseHoldId);
            return View(budgets);
        }

        // GET: Budgets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Budgets budgets = db.Budgets.Find(id);
            if (budgets == null)
            {
                return HttpNotFound();
            }
            return View(budgets);
        }

        // POST: Budgets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Budgets budgets = db.Budgets.Find(id);
            db.Budgets.Remove(budgets);
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
