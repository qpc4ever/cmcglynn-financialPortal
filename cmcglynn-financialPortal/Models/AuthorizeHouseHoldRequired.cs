﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace cmcglynn_financialPortal.Models
{
    public class AuthorizeHouseHoldRequired : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var isAuthorized = base.AuthorizeCore(httpContext);
            if (!isAuthorized)
            {
                return false;
            }
            return httpContext.User.Identity.IsInHouseHold();
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                filterContext.Result = new RedirectToRouteResult
                    (new RouteValueDictionary
                    (new { Controller = "Home", action = "CreateJoinHouseHold" }));
            }
            else
            {
                base.HandleUnauthorizedRequest(filterContext);
                                   
            }
        }
    }

}
