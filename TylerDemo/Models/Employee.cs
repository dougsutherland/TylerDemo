using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TylerDemo.Models
{
    public class Employee
    {
        public int EmployeeNumber { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string FullName { get { return FirstName + " " + LastName; } }
        public Employee Manager { get; set; }
        public List<Role> Roles { get; set; }


    }
}
