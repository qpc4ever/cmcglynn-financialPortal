﻿using cmcglynn_financialPortal.Models.CodeFirst;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace cmcglynn_financialPortal.Models
{

    public class Universal : Controller
    {
        public ApplicationDbContext db = new ApplicationDbContext();

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = db.Users.Find(User.Identity.GetUserId());
                ViewBag.Transactions = user.Transactions.ToList();
                ViewBag.FirstName = user.FirstName;
                ViewBag.LastName = user.LastName;
                ViewBag.FullName = user.FullName;
                ViewBag.ProfilePic = user.ProfilePic;
                ViewBag.Notifications = user.Notifications.ToList();
                if (user.HouseHoldId != null)
                {
                    ViewBag.HouseHold = user.HouseHold.Name;
                }
                if (user.HouseHoldId == null)
                {
                    ViewBag.OverDraft = "False";
                }
                else
                {
                    List<Accounts> currentUserAccountsOverDraft = new List<Accounts>();
                    currentUserAccountsOverDraft = user.HouseHold.Accounts.Where(a => a.Balance < 0).ToList();
                    if (currentUserAccountsOverDraft.Count() == 0)
                    {
                        ViewBag.OverDraft = "False";
                    }
                    else
                    {
                        ViewBag.OverDraft = "True";
                    }
                }
            }

            base.OnActionExecuted(filterContext);
        }
    }
    
    }
