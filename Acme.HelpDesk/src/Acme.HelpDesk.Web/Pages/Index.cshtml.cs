using Microsoft.AspNetCore.Mvc;

namespace Acme.HelpDesk.Web.Pages
{
    public class IndexModel : HelpDeskPageModel
    {
        public ActionResult OnGet()
        {
            if (!CurrentUser.IsAuthenticated)
            {
                return Redirect("/Account/Login");
            }

            return Page();
        }
    }
}