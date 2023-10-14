using Infrastructure.Model;

namespace EngineeringServices.Model.Dtos.Message
{
    public class MessagePostDto : IDto
    {
        public string? FullName { get; set; }
        public string? Subject { get; set; }
        public string? Email { get; set; }
    }
}
