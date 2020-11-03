using System;
using System.Collections.Generic;

namespace Northwind.NorthwindData
{
    public partial class Customercustomerdemo
    {
        public string CustomerId { get; set; }
        public string CustomerTypeId { get; set; }

        public virtual Customers Customer { get; set; }
        public virtual Customerdemographics CustomerType { get; set; }
    }
}
