using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using TylerDemo.Data.TylerDemo;

namespace TylerDemo.Pages
{
    public class ManageEmployeesModel : PageModel
    {
        private readonly ILogger<ManageEmployeesModel> _logger;
        private readonly TylerDemoQueries _tylerDemoQueries;
        [BindProperty]
        public int selectedManager { get; set; }

        public SelectList ManagerList { get; set; }
        public List<Models.Employee> Employees { get; set; }

        public ManageEmployeesModel(ILogger<ManageEmployeesModel> logger, TylerDemoQueries tylerDemoQueries)
        {
            _logger = logger;
            _tylerDemoQueries = tylerDemoQueries;
        }
        public void OnGet()
        {
            Employees = _tylerDemoQueries.GetEmployees();
            ManagerList = _tylerDemoQueries.GetManagers();
        }
        public ActionResult OnPostAddEmployee()
        {
            return Redirect("AddEmployee");
        }
        public ActionResult OnPostSearchManager(int selectedManager)
        {
            Employees = _tylerDemoQueries.GetEmployeesForManager(selectedManager);
            ManagerList = _tylerDemoQueries.GetManagers();
            return Page();
        }
    }
}
