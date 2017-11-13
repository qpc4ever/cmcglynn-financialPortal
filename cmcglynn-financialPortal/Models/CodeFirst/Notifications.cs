using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cmcglynn_financialPortal.Models.CodeFirst
{
    public class Notifications
    {
        public int Id { get; set; }
        public int? AccountId { get; set; }
        public DateTimeOffset Created { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string NotifyUserId { get; set; }
        
        public int HouseHoldId { get; set; }

        public virtual ApplicationUser NotifyUser { get; set; }

        public virtual HouseHold HouseHold { get; set; }
       
        public virtual Transactions Account { get; set; }
    }
}