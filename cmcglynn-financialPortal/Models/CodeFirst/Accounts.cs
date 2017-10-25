using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cmcglynn_financialPortal.Models.CodeFirst
{
    public class Accounts
    {
        public int Id { get; set; }
        public string AccountName { get; set; }
        public string Type { get; set; }
        public int HouseHoldId { get; set; }
        public int AccountBalance { get; set; }
        public bool Reconcialed { get; set; }
        public string TransactionsId { get; set; }

        public virtual HouseHold HouseHold { get; set; }
        public virtual Transactions Transactions { get; set; }

        public virtual ICollection<ApplicationUser> Users { get; set; }




    }
}