using System;
using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace HelpDesk.Pages
{
    public class Index_Tests : HelpDeskWebTestBase
    {
        [Fact]
        public async Task Welcome_Page()
        {
            try
            {
                var response = await GetResponseAsStringAsync("/");
                response.ShouldNotBeNull();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
