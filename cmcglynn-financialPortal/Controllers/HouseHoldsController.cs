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
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;

namespace cmcglynn_financialPortal.Controllers
{
    [Authorize]
    public class HouseHoldsController : Universal
    {
        //private ApplicationDbContext db = new ApplicationDbContext();

        // GET: HouseHolds
        [AuthorizeHouseHoldRequired]
        public ActionResult Index()
        {
            var user = db.Users.Find(User.Identity.GetUserId());
            return View(user.HouseHold);
        }

        // GET: HouseHolds/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HouseHold houseHold = db.HouseHold.Find(id);
            if (houseHold == null)
            {
                return HttpNotFound();
            }
            return View(houseHold);
        }

        // GET: HouseHolds/Create
        public ActionResult Create()
        {
            return View();
        }
        [Authorize]
        public ActionResult InvitationSent()
        {
            return View();
        }


        // POST: HouseHolds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,Created,Updated")] HouseHold household)
        {
            
            if (ModelState.IsValid)
            {
               
               

                var user = db.Users.Find(User.Identity.GetUserId());
                

                user.HouseHoldId = household.Id;
                db.HouseHold.Add(household);
                db.SaveChanges();

                

                await HttpContext.RefreshAuthentication(db.Users.Find(User.Identity.GetUserId()));   //needs to be in leave and join post action
                return RedirectToAction("Index", "HouseHolds");
            }

            return View(household);
        }

        // GET: HouseHolds/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HouseHold houseHold = db.HouseHold.Find(id);
            if (houseHold == null)
            {
                return HttpNotFound();
            }
            return View(houseHold);
        }

        // POST: HouseHolds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Description,Name,Date,Income,Expenses,Difference,BudgetCategory")] HouseHold houseHold)
        {
            if (ModelState.IsValid)
            {
                db.Entry(houseHold).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(houseHold);
        }

        // GET: HouseHolds/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HouseHold houseHold = db.HouseHold.Find(id);
            if (houseHold == null)
            {
                return HttpNotFound();
            }
            return View(houseHold);
        }

        // POST: HouseHolds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HouseHold houseHold = db.HouseHold.Find(id);
            db.HouseHold.Remove(houseHold);
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
