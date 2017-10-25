using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cmcglynn_financialPortal.Models.CodeFirst
{
    public class HouseHold
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public DateTimeOffset Date { get; set; }
        public int Income { get; set; }
        public int Expenses { get; set; }
        public int Difference { get; set; }
        public string BudgetCategory { get; set; }


        public virtual ICollection<ApplicationUser> Users { get; set; }
        public virtual ICollection<Accounts> Accounts { get; set; }
        public virtual ICollection<Budgets> Budgets { get; set; }
    }
}