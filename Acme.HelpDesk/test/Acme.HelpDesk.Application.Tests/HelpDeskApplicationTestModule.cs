using Volo.Abp.Modularity;

namespace Acme.HelpDesk
{
    [DependsOn(
        typeof(HelpDeskApplicationModule),
        typeof(HelpDeskDomainTestModule)
        )]
    public class HelpDeskApplicationTestModule : AbpModule
    {

    }
}