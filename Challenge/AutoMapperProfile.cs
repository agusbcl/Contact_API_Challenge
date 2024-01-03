using Challenge.Dtos.CityDtos;
using Challenge.Dtos.CompanyDtos;
using Challenge.Dtos.ContactDtos;
using Challenge.Dtos.RegionDto;

namespace Challenge
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<AddContactDto, Contact>();
            CreateMap<UpdateContactDto, Contact>();
            CreateMap<Contact, GetContactDto>();
            CreateMap<City, CityDto>();
            CreateMap<Company, CompanyDto>();
            CreateMap<Region, RegionDto>();
        }
    }
}
