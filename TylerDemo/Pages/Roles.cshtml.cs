using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TylerDemo.Data.TylerDemo;

namespace TylerDemo.Pages
{
    public class RoleModel : PageModel
    {

        private readonly TylerDemoQueries _tylerDemoQueries;
        public RoleModel(TylerDemoQueries tylerDemoQueries)
        {
            _tylerDemoQueries = tylerDemoQueries;
        }
        public void OnGet()
        {
        }
        public ActionResult OnPostAddRole(string rolename)
        {
            if (_tylerDemoQueries.AddRole(rolename))
            {
            }
            else
            {

            }

            return Page();
        }
    }
}
