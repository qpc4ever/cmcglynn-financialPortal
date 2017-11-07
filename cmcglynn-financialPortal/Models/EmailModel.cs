using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace cmcglynn_financialPortal.Models
{
    public class EmailModel
    {
        [Required]
        public string Body { get; set; }
        [Required, Display(Name = "Email"), EmailAddress]
        public string EmailTo { get; set; }
        public int HouseHoldId { get; set; }
        public string FromName { get; set; }
        public string FromEmail { get; set; }
        public int Id { get; set; }
    }
}
