using HelpDesk.Localization;
using Volo.Abp.Application.Services;

namespace HelpDesk
{
    /* Inherit your application services from this class.
     */
    public abstract class HelpDeskAppService : ApplicationService
    {
        protected HelpDeskAppService()
        {
            LocalizationResource = typeof(HelpDeskResource);
        }
    }
}
