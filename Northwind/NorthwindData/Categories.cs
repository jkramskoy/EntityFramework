using System;
using System.Collections.Generic;

namespace Northwind.NorthwindData
{
    public partial class Categories
    {
        public Categories()
        {
            Products = new HashSet<Products>();
        }

        // these properties map to columns in the database
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public byte[] Picture { get; set; }

        // defines a navigation property for related rows 
        public virtual ICollection<Products> Products { get; set; }
    }
}
