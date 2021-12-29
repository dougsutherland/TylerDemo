using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TylerDemo.Models
{
    public class Manager
    {
        public int EmployeeNumber { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public List<Employee> Employees { get; set; }
        public List<Role> Roles { get; set; }
        

    }
}
