using AutoMapper;
using EngineeringServices.Model.Dtos.Admin;
using EngineeringServices.Model.Entities;

namespace EngineeringServices.Business.Profiles
{
    public class AdminProfile : Profile
    {
        public AdminProfile()
        {
            CreateMap<Admin, AdminGetDto>();
        }
    }
}
