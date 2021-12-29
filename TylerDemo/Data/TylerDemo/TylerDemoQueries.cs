using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

namespace TylerDemo.Data.TylerDemo
{
    public class TylerDemoQueries
    {
        private TylerDemoDBContext _context;
        public TylerDemoQueries(TylerDemoDBContext context)
        {
            _context = context;
        }

        public SelectList GetRoles()
        {
            var options = new SelectList(_context.Role, nameof(Role.Id), nameof(Role.RoleName));
            return options;
        }
        public SelectList GetManagers()
        {
            var employeelist = _context.Employees.ToList();
            employeelist.Insert(0, new Employee { Id = 0, Firstname = "" });
            var options = new SelectList(employeelist, nameof(Employee.Id), nameof(Employee.Fullname));
            return options;
        }
        public bool AddRole(string RoleName)
        {

            _context.Role.Add(new Role
            {
                RoleName = RoleName
            });
            _context.SaveChanges();
            return true;
        }

        public bool AddEmployee(Models.Employee employee)
        {

            var emp = new Employee
            {
                Firstname = employee.FirstName,
                LastName = employee.LastName,
                ReportsToId = employee.Manager?.EmployeeNumber
            };

            _context.Employees.Add(emp);
            _context.SaveChanges();

            foreach (var role in employee.Roles)
            {
                var employeerole = new EmployeeRole
                {
                    RoleId = role.RoleId,
                    EmployeeId = emp.Id
                };
                _context.EmployeeRole.Add(employeerole);
            }

            _context.SaveChanges();

            return true;
        }
        public List<Models.Employee> GetEmployees()
        {

            var employees =
                (from e in _context.Employees
                 join m in (from e2 in _context.Employees
                            select e2)
                     on e.ReportsToId equals m.Id
                     into manager
                 from man in manager.DefaultIfEmpty()

                 select new Models.Employee
                 {
                     EmployeeNumber = e.Id,
                     FirstName = e.Firstname,
                     LastName = e.LastName,
                     Manager = new Models.Employee
                     {
                         EmployeeNumber = man.Id,
                         FirstName = man.Firstname,
                         LastName = man.LastName
                     }
                 }).ToList();


            foreach (var employee in employees)
            {

                var roles = (from er in _context.EmployeeRole
                             join r in _context.Role
                               on er.RoleId equals r.Id
                             where er.EmployeeId == employee.EmployeeNumber
                             select new Models.Role
                             {
                                 RoleId = r.Id,
                                 RoleDescription = r.RoleName
                             }).ToList();
                employee.Roles = roles;
            }
            return employees;
        }
        public List<Models.Employee> GetEmployeesForManager(int selectedManager)
        {

            var employees =
                (from e in _context.Employees
                 join m in (from e2 in _context.Employees
                            select e2)
                     on e.ReportsToId equals m.Id
                     into manager
                 from man in manager.DefaultIfEmpty()
                 where e.ReportsToId == selectedManager

                 select new Models.Employee
                 {
                     EmployeeNumber = e.Id,
                     FirstName = e.Firstname,
                     LastName = e.LastName,
                     Manager = new Models.Employee
                     {
                         EmployeeNumber = man.Id,
                         FirstName = man.Firstname,
                         LastName = man.LastName
                     }
                 }).ToList();


            foreach (var employee in employees)
            {

                var roles = (from er in _context.EmployeeRole
                             join r in _context.Role
                               on er.RoleId equals r.Id
                             select new Models.Role
                             {
                                 RoleId = r.Id,
                                 RoleDescription = r.RoleName
                             }).ToList();
                employee.Roles = roles;
            }
            return employees;
        }

        public List<Models.OrganizationalChart> GetOrganizatonalChart(int TopLevelEmployeeId)
        {
            var sql = "exec GetOrganizationalChart @TopLevelEmployeeId";

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@TopLevelEmployeeId", Value = TopLevelEmployeeId }
            };

            return _context.OrganizationalChart.FromSqlRaw<Models.OrganizationalChart>(sql, parms.ToArray()).ToList();
        }
    }
}
