﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cmcglynn_financialPortal.Models.CodeFirst
{
    public class Expenses /*: IParent*/
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int? CategoryId { get; set; }
        public decimal Amount { get; set; }
        public int Frequency { get; set; }

        public virtual Category Category { get; set; }
      
    }
}