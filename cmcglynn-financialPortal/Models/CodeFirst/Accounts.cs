using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cmcglynn_financialPortal.Models.CodeFirst
{
    public class Accounts
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int? HouseHoldId { get; set; }
        public decimal Balance { get; set; }
        public DateTime? Reconcialed { get; set; }
        public string TransactionsId { get; set; }
        public int? AccountTypeId { get; set; }
        public DateTime Open { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public DateTime? Closed { get; set; }
        public DateTime? Updated { get; set; }

        public virtual HouseHold HouseHold { get; set; }
        public virtual AccountType AccountType { get; set; }

        public virtual ICollection<Transactions> Transactions { get; set; }




    }
}