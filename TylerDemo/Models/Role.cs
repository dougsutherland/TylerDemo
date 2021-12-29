using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TylerDemo.Models
{
    public class Role
    {
        public int RoleId { get; set; }
        public string RoleDescription { get; set; }
        public virtual List<Employee> Employees {get;set;}
        public virtual List<Manager> Managers { get; set; }
    }
}
