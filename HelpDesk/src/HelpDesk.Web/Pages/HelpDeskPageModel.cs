using HelpDesk.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace HelpDesk.Web.Pages
{
    public abstract class HelpDeskPageModel : AbpPageModel
    {
        protected HelpDeskPageModel()
        {
            LocalizationResourceType = typeof(HelpDeskResource);
        }
    }
}