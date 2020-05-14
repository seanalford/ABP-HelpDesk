using Volo.Abp.Settings;

namespace HelpDesk.Settings
{
    public class HelpDeskSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            //Define your own settings here. Example:
            //context.Add(new SettingDefinition(HelpDeskSettings.MySetting1));
        }
    }
}
