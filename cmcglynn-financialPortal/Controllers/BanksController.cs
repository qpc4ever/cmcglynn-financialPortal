﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using cmcglynn_financialPortal.Models;

namespace cmcglynn_financialPortal.Models.CodeFirst
{
    public class BanksController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Banks
        public ActionResult Index()
        {
            return View(db.Banks.ToList());
        }

        // GET: Banks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Banks banks = db.Banks.Find(id);
            if (banks == null)
            {
                return HttpNotFound();
            }
            return View(banks);
        }

        // GET: Banks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Banks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Type,Balance,Name,HouseHoldId,AccountsId")] Banks banks)
        {
            if (ModelState.IsValid)
            {
                db.Banks.Add(banks);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(banks);
        }

        // GET: Banks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Banks banks = db.Banks.Find(id);
            if (banks == null)
            {
                return HttpNotFound();
            }
            return View(banks);
        }

        // POST: Banks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Type,Balance,Name,HouseHoldId,AccountsId")] Banks banks)
        {
            if (ModelState.IsValid)
            {
                db.Entry(banks).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(banks);
        }

        // GET: Banks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Banks banks = db.Banks.Find(id);
            if (banks == null)
            {
                return HttpNotFound();
            }
            return View(banks);
        }

        // POST: Banks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Banks banks = db.Banks.Find(id);
            db.Banks.Remove(banks);
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
