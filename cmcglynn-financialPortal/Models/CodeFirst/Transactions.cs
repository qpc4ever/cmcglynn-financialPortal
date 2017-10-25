using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cmcglynn_financialPortal.Models.CodeFirst
{
    public class Transactions
    {
        public int Id { get; set; }
        public DateTimeOffset PostedDate { get; set; }
        public DateTimeOffset TransactionDate { get; set; }
        public int DateRange { get; set; }
        public String AccountType { get; set; }
        public int User { get; set; }
        public String Catagory { get; set; }
        public decimal Credit { get; set; }
        public decimal Debit { get; set; }
        public bool ReconciliationStatus { get; set; }
        public int HouseHoldId { get; set; }
        public decimal AmountRange { get; set; }
        public decimal Receipt { get; set; }
        public string BanksId { get; set; }



        public virtual HouseHold HouseHold { get; set; }
        public virtual Banks Banks { get; set; }
    }

    }

