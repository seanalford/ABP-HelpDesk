using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.AspNetCore.Mvc.Razor.Internal;
using Acme.HelpDesk.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Acme.HelpDesk.Web.Pages
{
    public abstract class HelpDeskPage : AbpPage
    {
        [RazorInject]
        public IHtmlLocalizer<HelpDeskResource> L { get; set; }
    }
}
