using cmcglynn_financialPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace cmcglynn_financialPortal.Controllers
{
    [Authorize]
    public class HomeController : Universal
    {
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
    }
}