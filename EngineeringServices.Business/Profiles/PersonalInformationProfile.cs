using AutoMapper;
using EngineeringServices.Model.Dtos.PersonalInformation;
using EngineeringServices.Model.Entities;

namespace EngineeringServices.Business.Profiles
{
    public class PersonalInformationProfile : Profile
    {
        public PersonalInformationProfile()
        {
            CreateMap<PersonalInformation, PersonalInformationGetDto>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.Person.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.Person.LastName));
            CreateMap<PersonalInformationPutDto, PersonalInformation>();
        }
    }
}
