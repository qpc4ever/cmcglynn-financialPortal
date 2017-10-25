using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cmcglynn_financialPortal.Models.CodeFirst
{
    public class Banks
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Balance { get; set; }
        public string Name { get; set; }
        public string HouseHoldId { get; set; }
        public string AccountsId { get; set; }

        public virtual ICollection<ApplicationUser> Users { get; set; }


        public virtual HouseHold HouseHold { get; set; }
        public virtual Accounts Accounts { get; set; }
    }
}