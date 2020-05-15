using System.ComponentModel.DataAnnotations;
using Volo.Abp.ObjectExtending;
using Volo.Abp.Threading;

namespace Acme.HelpDesk
{
    public static class HelpDeskModuleExtensionConfigurator
    {
        private static readonly OneTimeRunner OneTimeRunner = new OneTimeRunner();

        public static void Configure()
        {
            OneTimeRunner.Run(() =>
            {
                /* You can configure extra properties for the
                 * entities defined in the modules used by your application.
                 *
                 * This class can be used to define these extra properties
                 * with a high level, easy to use API.
                 *
                 * Example: Add a new property to the user entity of the identity module
                  
                   ObjectExtensionManager.Instance.Modules()
                      .ConfigureIdentity(identity =>
                      {
                          identity.ConfigureUser(user =>
                          {
                              user.AddOrUpdateProperty<string>( //property type: string
                                  "SocialSecurityNumber", //property name
                                  property =>
                                  {
                                      //validation rules
                                      property.Attributes.Add(new RequiredAttribute());
                                      property.Attributes.Add(new StringLengthAttribute(64) {MinimumLength = 4});
                  
                                      //...other configurations for this property
                                  }
                              );
                          });
                      });
                  
                 * See the documentation for more:
                 * https://docs.abp.io/en/commercial/latest/guides/module-entity-extensions
                 */
            });
        }
    }
}