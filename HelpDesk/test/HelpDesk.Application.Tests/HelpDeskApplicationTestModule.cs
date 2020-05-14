using Volo.Abp.Modularity;

namespace HelpDesk
{
    [DependsOn(
        typeof(HelpDeskApplicationModule),
        typeof(HelpDeskDomainTestModule)
        )]
    public class HelpDeskApplicationTestModule : AbpModule
    {

    }
}