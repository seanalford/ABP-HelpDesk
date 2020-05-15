using Acme.HelpDesk.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Acme.HelpDesk
{
    [DependsOn(
        typeof(HelpDeskEntityFrameworkCoreTestModule)
        )]
    public class HelpDeskDomainTestModule : AbpModule
    {

    }
}