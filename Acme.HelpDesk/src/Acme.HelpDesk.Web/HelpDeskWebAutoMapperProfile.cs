using Acme.HelpDesk.Organizations;
using AutoMapper;

namespace Acme.HelpDesk.Web
{
    public class HelpDeskWebAutoMapperProfile : Profile
    {
        public HelpDeskWebAutoMapperProfile()
        {
            //Define your AutoMapper configuration here for the Web project.

            CreateMap<OrganizationDto, OrganizationUpdateDto>();
        }
    }
}