using Acme.HelpDesk.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Acme.HelpDesk.Controllers
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