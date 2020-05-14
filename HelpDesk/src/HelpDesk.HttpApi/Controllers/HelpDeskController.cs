using HelpDesk.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace HelpDesk.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class HelpDeskController : AbpController
    {
        protected HelpDeskController()
        {
            LocalizationResource = typeof(HelpDeskResource);
        }
    }
}