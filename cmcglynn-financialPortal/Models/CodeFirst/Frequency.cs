using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cmcglynn_financialPortal.Models.CodeFirst
{
    public class Frequency
    {
        public int Id { get; set; }
        public string Weekly { get; set; }
        public string Monthly { get; set; }
        public string Yearly { get; set; }
        public int? HouseHoldId { get; set; }
        public int? BudgetsId { get; set; }

        public virtual HouseHold HouseHold { get; set; }
        public virtual Budgets Budgets { get; set; }
    }
}