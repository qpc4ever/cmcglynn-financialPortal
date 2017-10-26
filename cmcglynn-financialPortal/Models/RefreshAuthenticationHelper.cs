using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using static cmcglynn_financialPortal.EmailService;
using Microsoft.AspNet.Identity.Owin;

namespace cmcglynn_financialPortal.Models
{
    public static class RefreshAuthenticationHelper
    {
        public static async Task RefreshAuthentication(this HttpContextBase contex, ApplicationUser user)
        {
            contex.GetOwinContext().Authentication.SignOut();
            await contex.GetOwinContext().Get<ApplicationSignInManager>()
                .SignInAsync(user, isPersistent: false, rememberBrowser: false);
        }
    }
}