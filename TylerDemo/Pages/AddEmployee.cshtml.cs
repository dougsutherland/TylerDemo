using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TylerDemo.Data.TylerDemo;

namespace TylerDemo.Pages
{
    public class AddEmployeeModel : PageModel
    {
        private readonly TylerDemoQueries _tylerDemoDBQueries;
        [BindProperty]
        public int selectedManager { get; set; }
        [BindProperty]
        public List<int> SelectedRoles { get; set; }
        public SelectList RoleList{ get; set; }
        public SelectList ManagerList { get; set; }
        public AddEmployeeModel(TylerDemoQueries tylerDemoQueries)
        {
            _tylerDemoDBQueries = tylerDemoQueries;
        }

        public void OnGet()
        {
            RoleList = _tylerDemoDBQueries.GetRoles();
            ManagerList = _tylerDemoDBQueries.GetManagers();
        }

        public ActionResult OnPostAddEmployee(string firstname, string lastname, List<int> SelectedRoles, int selectedManager)
        {
            var emp = new Models.Employee
            {
                FirstName = firstname,
                LastName = lastname
            };

            if (selectedManager > 0) { 
                Models.Employee manager = new Models.Employee();
                manager.EmployeeNumber = selectedManager;
                emp.Manager = manager;
            }
            List<Models.Role> Roles = new List<Models.Role>();

            foreach(var selectedrole in SelectedRoles)
            {
                var role = new Models.Role
                {
                    RoleId = selectedrole,
                    RoleDescription = ""
                };
                Roles.Add(role);
            }

            emp.Roles = Roles;

            _tylerDemoDBQueries.AddEmployee(emp);
            RoleList = _tylerDemoDBQueries.GetRoles();
            ManagerList = _tylerDemoDBQueries.GetManagers();
            return Page();
        }
    }
}
