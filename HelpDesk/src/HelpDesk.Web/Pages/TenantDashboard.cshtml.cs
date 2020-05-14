using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HelpDesk.Web.Pages
{
    public class TenantDashboardModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public DateTime? StartDate { get; set; }

        [BindProperty(SupportsGet = true)]
        public DateTime? EndDate { get; set; }

        public void OnGet()
        {
            if (StartDate == null)
            {
                StartDate = DateTime.Now.AddMonths(-1).ClearTime();
            }

            if (EndDate == null)
            {
                EndDate = DateTime.Now.ClearTime();
            }
        }
    }
}