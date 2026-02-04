using System;
using System.Collections.Generic;

namespace dotnetapp.Models
{
    public partial class Dept
    {
        public Dept()
        {
            Employees = new HashSet<Employee>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Location { get; set; } = null!;

        public virtual ICollection<Employee> Employees { get; set; }
    }
}






using System;
using System.Collections.Generic;

namespace dotnetapp.Models
{
    public partial class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public int Deptid { get; set; }
        public DateTime Dateofbirth { get; set; }
        public int Salary { get; set; }

        public virtual Dept Dept { get; set; } = null!;
    }
}
