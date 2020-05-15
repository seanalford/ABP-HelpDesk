using Acme.HelpDesk.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Acme.HelpDesk.Web.Pages
{
    public abstract class HelpDeskPageModel : AbpPageModel
    {
        protected HelpDeskPageModel()
        {
            LocalizationResourceType = typeof(HelpDeskResource);
        }
    }
}