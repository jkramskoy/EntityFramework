using System;
using System.Collections.Generic;

namespace EntityFramework.EntityFramework
{
    public partial class Employees
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? Salary { get; set; }
        public int? DepartmentId { get; set; }

        public virtual Departments Department { get; set; }
    }
}
