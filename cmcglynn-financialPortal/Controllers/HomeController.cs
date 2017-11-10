using cmcglynn_financialPortal.Models;
using cmcglynn_financialPortal.Models.CodeFirst;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using static cmcglynn_financialPortal.EmailService;

namespace cmcglynn_financialPortal.Controllers
{
    [Authorize]
    public class HomeController : Universal
    {
        //private ApplicationDbContext db = new ApplicationDbContext();
        [AuthorizeHouseHoldRequired]
        public ActionResult Index()
        {
            //CalculationHelper helper = new CalculationHelper(new Expenses());

            //helper.CalculateYearly();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public PartialViewResult _Contact(string someTxt)                            //partialView
        {
            ViewBag.Message = someTxt;

            return PartialView();
        }
        

        public ActionResult CustomErrors()
        {
            return View();
        }

        public async Task<ActionResult> LeaveHouseHold()
        {



            //Implementation of leaving household
            var user = db.Users.Find(User.Identity.GetUserId());
            await ControllerContext.HttpContext.RefreshAuthentication(user);
            return View();

            await HttpContext.RefreshAuthentication(db.Users.Find(User.Identity.GetUserId()));
        }

        public ActionResult CreateJoinHouseHold()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> CreateJoinHouseHold([Bind(Include = "Id,Name")] HouseHold household)
        {
            //Implementation for creating and joining household
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

        [AllowAnonymous]
        public ActionResult Landing()
        {
            return View();
        }


    }

    }

   