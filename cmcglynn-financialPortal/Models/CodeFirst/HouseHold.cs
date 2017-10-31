using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cmcglynn_financialPortal.Models.CodeFirst
{
    public class HouseHold
    {
        public HouseHold()
        {
            Users = new HashSet<ApplicationUser>();
            Accounts = new HashSet<Accounts>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
       


        public virtual ICollection<ApplicationUser> Users { get; set; }
        public virtual ICollection<Accounts> Accounts { get; set; }
        public virtual ICollection<Budgets> Budgets { get; set; }
    }
}