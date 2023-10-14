using AutoMapper;
using EngineeringServices.Model.Dtos.Person;
using EngineeringServices.Model.Entities;

namespace EngineeringServices.Business.Profiles
{
    public class PersonProfile : Profile
    {
        public PersonProfile()
        {
            CreateMap<Person, PersonGetDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Engineering.Name))
                .ForMember(dest => dest.Hour, opt => opt.MapFrom(src => src.WorkInformation.Hour))
                .ForMember(dest => dest.Day, opt => opt.MapFrom(src => src.WorkInformation.Day))
                .ForMember(dest => dest.Wage, opt => opt.MapFrom(src => src.WorkInformation.Wage))
                .ForMember(dest => dest.Rank, opt => opt.MapFrom(src => src.WorkInformation.Rank))
                .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.PersonalInformation.Age))
                .ForMember(dest => dest.University, opt => opt.MapFrom(src => src.PersonalInformation.University))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.PersonalInformation.City))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.PersonalInformation.Email))
                .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.PersonalInformation.Phone))
                .ForMember(dest => dest.OpenAddress, opt => opt.MapFrom(src => src.PersonalInformation.OpenAddress))
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.PersonalInformation.Gender));

            CreateMap<Person, PersonUIGetDto>()
                .ForMember(dest => dest.EngineeringId, opt => opt.MapFrom(src => src.Engineering.EngineeringId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Engineering.Name));
            CreateMap<Person, PersonPostDto>().ReverseMap();
            CreateMap<Person, PersonPutDto>().ReverseMap();
        }
    }
}
