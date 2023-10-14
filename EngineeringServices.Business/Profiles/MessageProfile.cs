using AutoMapper;
using EngineeringServices.Model.Dtos.Message;
using EngineeringServices.Model.Entities;

namespace EngineeringServices.Business.Profiles
{
    public class MessageProfile : Profile
    {
        public MessageProfile()
        {
            CreateMap<Message, MessageGetDto>();
            CreateMap<MessagePostDto, Message>();
        }
    }
}
