using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TylerDemo.Data.TylerDemo
{
    public class Employee
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string Firstname { get; set; }
        public string Fullname { get { return Firstname + " " + LastName; } }
        public int? ReportsToId { get; set; }
        public virtual List<EmployeeRole> EmployeeRoles {get;set;}

    }
}
