using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.AspNetCore.Mvc.Razor.Internal;
using HelpDesk.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace HelpDesk.Web.Pages
{
    public abstract class HelpDeskPage : AbpPage
    {
        [RazorInject]
        public IHtmlLocalizer<HelpDeskResource> L { get; set; }
    }
}
