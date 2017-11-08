using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentDateTime;
namespace cmcglynn_financialPortal.Models.CodeFirst
{
    public class Budgets
    {
        public int Id { get; set; }
        public string AuthorId { get; set; }
        public int? CategoryId { get; set; }
        public int FrequencyId { get; set; }
        public string Description { get; set; }
        public int? HouseHoldId { get; set; }
        public string Item { get; set; }

        public virtual Frequency Frequency { get; set; }
        public virtual HouseHold HouseHold { get; set; }
        public virtual Category Category { get; set; }
        public virtual ApplicationUser Author { get; set; }

        public decimal? BudgetAmount
        {
            get
            {
                if (Category != null)
                {
                    if (Frequency != null && Frequency.Name == "Weekly")
                    {
                        var previousSunday = DateTime.Now.Previous(DayOfWeek.Sunday);
                        var nextMonday = DateTime.Now.Next(DayOfWeek.Monday);
                        return Category.Transactions.Where(t => t.TransactionDate > previousSunday && t.TransactionDate < nextMonday && t.Void == false).Sum(t => t.Amount);

                    }
                    else if (Frequency != null && Frequency.Name == "Monthly")
                    {

                        return Category.Transactions.Where(t => t.TransactionDate.Month == DateTime.Now.Month && t.TransactionDate.Year == DateTime.Now.Year && t.Void == false).Sum(t => t.Amount);
                    }
                    else if (Frequency != null && Frequency.Name == "Yearly")
                    {

                        return Category.Transactions.Where(t => t.TransactionDate.Year == DateTime.Now.Year && t.Void == false).Sum(t => t.Amount);
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
        }
    }
}