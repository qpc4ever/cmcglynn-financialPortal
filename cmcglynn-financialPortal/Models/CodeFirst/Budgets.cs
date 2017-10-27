using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cmcglynn_financialPortal.Models.CodeFirst
{
    public class Budgets
    {
        public int Id { get; set; }
        public string AuthorId { get; set; }
        public int? CategoryId { get; set; }
        public int Frequency { get; set; }
        public string Description { get; set; }
        public int? HouseHoldId { get; set; }
        public string Item { get; set; }

        public virtual HouseHold HouseHold { get; set; }
        public virtual Category Category { get; set; }
        public virtual ApplicationUser Author { get; set; }
    }
}