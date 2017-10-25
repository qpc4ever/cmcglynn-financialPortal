using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cmcglynn_financialPortal.Models.CodeFirst
{
    public class Budgets
    {
        public int Id { get; set; }
        public string BudgetType { get; set; }
        public string BudgetCategory { get; set; }
        public string BudgetsItem { get; set; }
        public string Frequency  { get; set; }
        public int Amount { get; set; }
        public string Description { get; set; }
        public int HouseHoldId { get; set; }
        public int Transaction { get; set; }
        public int Account { get; set; }
        public int User { get; set; }
        public decimal IncomeId { get; set; }
        public decimal ExpensesId { get; set; }

        public virtual HouseHold HouseHold { get; set; }
        public virtual Income Income { get; set; }
        public virtual Expenses Expenses { get; set; }

        public virtual ICollection<ApplicationUser> Users { get; set; }
        public virtual ICollection<ApplicationUser> Transactions { get; set; }



    }
}