using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Security.Claims;

namespace cmcglynn_financialPortal.Models
{
    public static class Extensions
    {
        public static int? GetHouseHoldId(this IIdentity user)
        {
            var ClaimsIdentity = (ClaimsIdentity)user;
            var HouseHoldClaim = ClaimsIdentity.Claims.FirstOrDefault(c => c.Type == "HouseHoldId");

            if (HouseHoldClaim != null)
                return Int32.Parse(HouseHoldClaim.Value);
            else
                return null;
        }
        public static bool IsInHouseHold(this IIdentity user)
        {
            var cUser = (ClaimsIdentity)user;
            var hid = cUser.Claims.FirstOrDefault(c => c.Type == "HouseHoldId");
            return (hid != null && !string.IsNullOrWhiteSpace(hid.Value));
        }
    }
}