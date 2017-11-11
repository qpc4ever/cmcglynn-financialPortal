using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace cmcglynn_financialPortal.Models.CodeFirst
{
    public class Transactions
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string AuthorId { get; set; }
        public int CategoryId { get; set; }
        public int AccountsId { get; set; }
        public decimal Amount { get; set; }
        public bool ReconciledStatus { get; set; }
        public decimal ReconciledAmount { get; set; }
        [Display(Name = "Transaction Date")]
        public DateTime TransactionDate { get; set; }
        [Display(Name = "Reconciled")]
        public DateTime? ReconciliationDate { get; set; }

        public int TransactionTypeId { get; set; }
        [Display(Name = "Posted Date")]
        public DateTime PostedDate { get; set; }
        public bool Void { get; set; }

        public virtual TransactionType TransactionType { get; set; }
        public virtual ApplicationUser Author { get; set; }
        public virtual Category Category { get; set; }
        public virtual Accounts Accounts { get; set; }
    }

}

