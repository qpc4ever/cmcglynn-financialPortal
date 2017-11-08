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
using System.Net.Mail;
using static cmcglynn_financialPortal.EmailService;

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
                

                db.HouseHold.Add(household);
                db.SaveChanges();
                user.HouseHoldId = household.Id;
                db.SaveChanges();

                await HttpContext.RefreshAuthentication(db.Users.Find(User.Identity.GetUserId()));   //needs to be in leave and join post action
                return RedirectToAction("Index", "HouseHolds");
            }

            return View(household);
        }

        // GET: HouseHolds/Join
        public ActionResult Join(int id)
        {
            HouseHold household = db.HouseHold.Find(id);
            if (household == null)
            {
                return HttpNotFound();
            }
            return View(household);
        }

        // Post: HouseHolds/Join
        [HttpPost]
        public async Task<ActionResult> Join(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HouseHold household = db.HouseHold.Find(id);
            if (household == null)
            {
                return HttpNotFound();
            }
            var user = db.Users.Find(User.Identity.GetUserId());
            user.HouseHoldId = household.Id;
            db.SaveChanges();

            await HttpContext.RefreshAuthentication(db.Users.Find(User.Identity.GetUserId()));   //needs to be in leave and join post action
            return RedirectToAction("Index");
        }
        // GET: HouseHolds/Invite
        public ActionResult Invite()
        {
            return View();
        }

        //Post: HouseHolds?Invite
        [AuthorizeHouseHoldRequired]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Invite(EmailModel model)
        {
            var me = db.Users.Find(User.Identity.GetUserId());
            model.HouseHoldId = me.HouseHoldId.Value;
            if (ModelState.IsValid)
            {
                try
                {
                    var invitee = db.Users.FirstOrDefault(u => u.Email == model.EmailTo);
                    if (invitee != null && invitee.HouseHoldId == model.HouseHoldId)
                    {
                        return RedirectToAction("UserAlreadyAssignedToHouseHold");
                    }
                    var callbackUrl = "";
                    if (invitee != null)
                    {
                        callbackUrl = Url.Action("Join", "HouseHolds", new { id = model.HouseHoldId }, protocol: Request.Url.Scheme);
                    }
                    else
                    {
                        callbackUrl = Url.Action("Register", "Account", new { id = model.HouseHoldId }, protocol: Request.Url.Scheme);
                    }
                    var body = "<p>Email From: <bold>{0}</bold></p><p>Message:</p><p>{1}</p><p>{2}</p>";
                    var from = "Quick Budgeter<"+ me.Email +">";
                    var subject = "Invite to join HouseHold";
                    var to = model.EmailTo;

                    var email = new MailMessage(from, to)
                    {
                        Subject = subject,
                        Body = string.Format(body, me.FullName, model.Body, "Please click on the link below to confirm invitation: <br /> <a href=\" " + callbackUrl + " \">Link to invitation.</a>"),
                        IsBodyHtml = true
                    };

                    var svc = new PersonalEmail();
                    await svc.SendAsync(email);
                    return RedirectToAction("InviteSent");
                }
                catch ( Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    await Task.FromResult(0);
                }
            }
            return View(model);
        }
        //[Authorize]
        //public ActionResult InvitationSent()
        //{
        //    return View();
        //}
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

        // POST: HouseHolds/Leave
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Leave([Bind(Include = "Id,Name,Created,Updated")] HouseHold houseHold)
        {
            if (ModelState.IsValid)
            {
                var user = db.Users.Find(User.Identity.GetUserId());
                user.HouseHoldId = null;
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
