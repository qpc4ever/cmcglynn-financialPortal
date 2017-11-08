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
        [Required, Display(Name = "Email"), EmailAddress]
        public string EmailTo { get; set; }
        public int HouseHoldId { get; set; }
        public string Body { get; set; }
    }
}
