using System;
using System.Collections.Generic;

namespace Northwind.NorthwindData
{
    public partial class Territories
    {
        public Territories()
        {
            Employeeterritories = new HashSet<Employeeterritories>();
        }

        public string TerritoryId { get; set; }
        public string TerritoryDescription { get; set; }
        public int RegionId { get; set; }

        public virtual Region Region { get; set; }
        public virtual ICollection<Employeeterritories> Employeeterritories { get; set; }
    }
}
