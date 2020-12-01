using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMVC.Models.Enums
{
    public enum SaleStatus : int
    {
        PENDING = 0,
        BILLED = 1, 
        CANCELLED = 2
    }
}
