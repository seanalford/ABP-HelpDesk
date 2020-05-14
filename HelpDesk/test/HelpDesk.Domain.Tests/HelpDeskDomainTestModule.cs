using HelpDesk.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace HelpDesk
{
    [DependsOn(
        typeof(HelpDeskEntityFrameworkCoreTestModule)
        )]
    public class HelpDeskDomainTestModule : AbpModule
    {

    }
}