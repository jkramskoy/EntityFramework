using System;
using System.Collections.Generic;

namespace Northwind.NorthwindData
{
    public partial class Employeeterritories
    {
        public int EmployeeId { get; set; }
        public string TerritoryId { get; set; }

        public virtual Employees Employee { get; set; }
        public virtual Territories Territory { get; set; }
    }
}
