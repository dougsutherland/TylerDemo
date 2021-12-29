using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TylerDemo.Data.TylerDemo
{
    public class EmployeeRole
    {
        public int EmployeeId { get; set; }
        public int RoleId { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Role Role { get; set; }

    }
}
