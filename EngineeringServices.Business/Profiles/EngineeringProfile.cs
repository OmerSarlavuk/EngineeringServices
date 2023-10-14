using AutoMapper;
using EngineeringServices.Model.Dtos.Engineering;
using EngineeringServices.Model.Entities;

namespace EngineeringServices.Business.Profiles
{
    public class EngineeringProfile : Profile
    {
        public EngineeringProfile()
        {
            CreateMap<Engineering, EngineeringGetDto>();
        }
    }
}
