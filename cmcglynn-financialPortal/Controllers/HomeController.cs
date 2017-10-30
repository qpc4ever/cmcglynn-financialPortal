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

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Contact(EmailModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var body = "<p>Email From: <bold>{0}</bold>({1})</p><p>Message:</p><p>{2}</p>";
                    var from = "MyPortfolio<qpc4ever@gmail.com>";
                    model.Body = "This is a message from your Admin";

                    //var assignedUser = db.Users.Find(ticket).AssignedUserId);
                    //var emailTo = assignedUser.Email;


                    var email = new MailMessage(from,
                        ConfigurationManager.AppSettings["emailto"])
                    {
                        Subject = "Portfolio Contact Email",
                        Body = string.Format(body, model.FromName, model.FromEmail,
                        model.Body),
                        IsBodyHtml = true
                    };

                    //var svc = new PersonalEmail();
                    //await svc.SendAsync(email);

                    return RedirectToAction("Contact");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    await Task.FromResult(0);
                }
            }


            return View(model);


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
}
        public ActionResult CreateJoinHouseHold([Bind(Include = "Id,Name")] HouseHold model)
        {
            //Implementation for creating and joining household
             HouseHold household = new HouseHold();
            var user = db.Users.Find(User.Identity.GetUserId());
            if (ModelState.IsValid)
            {
                household.Users.Add(user);
                db.HouseHold.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index", "HouseHolds");
            }

            return View(household);

           
        }

    }
}
   