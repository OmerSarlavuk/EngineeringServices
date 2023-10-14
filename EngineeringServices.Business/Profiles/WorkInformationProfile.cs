using AutoMapper;
using EngineeringServices.Model.Dtos.WorkInformation;
using EngineeringServices.Model.Entities;

namespace EngineeringServices.Business.Profiles
{
    public class WorkInformationProfile : Profile
    {
        public WorkInformationProfile()
        {
            CreateMap<WorkInformation, WorkInformationGetDto>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.Person.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.Person.LastName));
            CreateMap<WorkInformationPutDto, WorkInformation>();
        }
    }
}
