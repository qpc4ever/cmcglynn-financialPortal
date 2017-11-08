using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cmcglynn_financialPortal.Models.CodeFirst
{
    public class Category
    {
        public Category()
        {
            Transactions = new HashSet<Transactions>();
        }
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Transactions> Transactions { get; set; }
    }
}