using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cmcglynn_financialPortal.Models
{
    public interface IParent
    {
        decimal CalculateYearlyTotal();
    }
}