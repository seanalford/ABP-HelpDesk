using Acme.HelpDesk.Organizations;
using Acme.HelpDesk.Users;
using AutoMapper;

namespace Acme.HelpDesk
{
    public class HelpDeskApplicationAutoMapperProfile : Profile
    {
        public HelpDeskApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */
            CreateMap<OrganizationCreateDto, Organization>();
            CreateMap<Organization, OrganizationDto>();
            CreateMap<OrganizationUpdateDto, Organization>();
            CreateMap<AppUser, AppUserDto>();
        }
    }
}