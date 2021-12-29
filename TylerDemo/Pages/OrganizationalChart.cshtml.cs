using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TylerDemo.Data.TylerDemo;

namespace TylerDemo.Pages
{
    public class OrganizationalChartModel : PageModel
    {
        private readonly TylerDemoQueries _tylerDemoQueries;
        [BindProperty]
        public List<Models.OrganizationalChart> OrganizationalChart{ get; set; }
        [BindProperty]
        public Models.Employee TopEmployee { get; set; }
        [BindProperty]
        public int ToplevelEmployeeId { get; set; }
        public OrganizationalChartModel(TylerDemoQueries tylerDemoQueries)
        {
            _tylerDemoQueries = tylerDemoQueries;
        }
        public void OnGet()
        {
            TopEmployee = _tylerDemoQueries.GetEmployees().Where(x => x.Manager.EmployeeNumber == 0).FirstOrDefault();
            ToplevelEmployeeId = TopEmployee.EmployeeNumber;
            OrganizationalChart = _tylerDemoQueries.GetOrganizatonalChart(ToplevelEmployeeId);
        }
    }
}
