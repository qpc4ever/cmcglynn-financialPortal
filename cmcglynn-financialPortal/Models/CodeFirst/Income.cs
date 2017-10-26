using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cmcglynn_financialPortal.Models.CodeFirst
{
    public class Income /*: IParent*/
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTimeOffset Date { get; set; }
        public string Frequency { get; set; }
        public string Type { get; set; }
        public string Amount { get; set; }
        public string HouseHoldId { get; set; }

        public virtual HouseHold HouseHold { get; set; }

        //public decimal CalculateYearlyTotal()
        //{
        //    return Amount * Frequency;
        //}
    }
}