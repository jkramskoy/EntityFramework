using System;
using System.Collections.Generic;

namespace Northwind.NorthwindData
{
    public partial class Customerdemographics
    {
        public Customerdemographics()
        {
            Customercustomerdemo = new HashSet<Customercustomerdemo>();
        }

        public string CustomerTypeId { get; set; }
        public string CustomerDesc { get; set; }

        public virtual ICollection<Customercustomerdemo> Customercustomerdemo { get; set; }
    }
}
