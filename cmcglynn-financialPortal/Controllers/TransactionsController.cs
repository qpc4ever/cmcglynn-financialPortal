﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using cmcglynn_financialPortal.Models;
using cmcglynn_financialPortal.Models.CodeFirst;
using Microsoft.AspNet.Identity;

namespace cmcglynn_financialPortal.Controllers
{
    [AuthorizeHouseHoldRequired]
    public class TransactionsController : Universal
    {
        //private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Transactions
        public ActionResult Index()
        {
            var transactions = db.Transactions.Include(t => t.Accounts).Include(t => t.Author).Include(t => t.Category).Include(t => t.TransactionType);
            return View(transactions.ToList());
        }

        // GET: Transactions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transactions transactions = db.Transactions.Find(id);
            if (transactions == null)
            {
                return HttpNotFound();
            }
            return View(transactions);
        }

        // GET: Transactions/Create
        public ActionResult Create()
        {
            ViewBag.AccountsId = new SelectList(db.Accounts, "Id", "Name");
            ViewBag.AuthorId = new SelectList(db.Users, "Id", "FirstName");
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name");
            ViewBag.TransactionTypeId = new SelectList(db.TransactionType, "Id", "Type");
            return View();
        }

        // POST: Transactions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,AuthorId,CategoryId,AccountsId,Amount,ReconciledStatus,ReconciledAmount,TransactionDate,ReconciliationDate,TransactionTypeId,PostedDate,Void")] Transactions transactions)
        {
            if (ModelState.IsValid)
            {
                var user = db.Users.Find(User.Identity.GetUserId());

                transactions.AuthorId = user.Id;
                transactions.TransactionDate = DateTime.Now;
                transactions.Void = false;
                db.Transactions.Add(transactions);

                Accounts accounts = db.Accounts.Find(transactions.AccountsId);
               

                if (transactions.TransactionTypeId == 1)
                {
                    accounts.Balance -= transactions.Amount;
                }
                else if (transactions.TransactionTypeId == 2)
                {
                    accounts.Balance += transactions.Amount;
                }
                db.SaveChanges();

                if (accounts.Balance < 0)
                {
                    IdentityMessage messageforUser = new IdentityMessage();

                    var callbackUrl = Url.Action("Index", "Transactions", new { id = transactions.Id }, protocol: Request.Url.Scheme);
                    messageforUser.Subject = "Account Overdraft";
                }

                return RedirectToAction("Index");
            }

            ViewBag.AccountsId = new SelectList(db.Accounts, "Id", "Name", transactions.AccountsId);
            ViewBag.AuthorId = new SelectList(db.Users, "Id", "FirstName", transactions.AuthorId);
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", transactions.CategoryId);
            ViewBag.TransactionTypeId = new SelectList(db.TransactionType, "Id", "Type", transactions.TransactionTypeId);
            return View(transactions);
        }

        // GET: Transactions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transactions transactions = db.Transactions.Find(id);
            if (transactions == null)
            {
                return HttpNotFound();
            }
            ViewBag.AccountsId = new SelectList(db.Accounts, "Id", "Name", transactions.AccountsId);
            ViewBag.AuthorId = new SelectList(db.Users, "Id", "FirstName", transactions.AuthorId);
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", transactions.CategoryId);
            ViewBag.TransactionTypeId = new SelectList(db.TransactionType, "Id", "Type", transactions.TransactionTypeId);
            return View(transactions);
        }

        // POST: Transactions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,AuthorId,CategoryId,AccountsId,Amount,ReconciledStatus,ReconciledAmount,TransactionDate,ReconciliationDate,TransactionTypeId,PostedDate,Void")] Transactions transactions)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transactions).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AccountsId = new SelectList(db.Accounts, "Id", "Name", transactions.AccountsId);
            ViewBag.AuthorId = new SelectList(db.Users, "Id", "FirstName", transactions.AuthorId);
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", transactions.CategoryId);
            ViewBag.TransactionTypeId = new SelectList(db.TransactionType, "Id", "Type", transactions.TransactionTypeId);
            return View(transactions);
        }

        // GET: Transactions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transactions transactions = db.Transactions.Find(id);
            if (transactions == null)
            {
                return HttpNotFound();
            }
            return View(transactions);
        }

        // POST: Transactions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Transactions transactions = db.Transactions.Find(id);
            db.Transactions.Remove(transactions);
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
