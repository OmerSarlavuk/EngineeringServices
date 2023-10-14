using AutoMapper;
using EngineeringServices.Model.Dtos.Note;
using EngineeringServices.Model.Entities;

namespace EngineeringServices.Business.Profiles
{
    public class NoteProfile : Profile
    {
        public NoteProfile()
        {
            CreateMap<Note, NoteGetDto>()
                .ForMember(dest => dest.AdminId, opt => opt.MapFrom(src => src.Admin.AdminId));
            CreateMap<Note, NotePostDto>().ReverseMap();
            CreateMap<NotePutDto, Note>().ReverseMap();
        }
    }
}
