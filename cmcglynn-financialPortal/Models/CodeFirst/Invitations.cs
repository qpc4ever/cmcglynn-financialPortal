using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cmcglynn_financialPortal.Models.CodeFirst
{
    public class Invitations
    {
        public int HouseHoldId { get; set; }
        public string FromName { get; set; }
        public string FromMail { get; set; }
        public string Subject  { get; set; }
        public string body { get; set; }
    }
}