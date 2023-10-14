using Infrastructure.Model;

namespace EngineeringServices.Model.Dtos.Note
{
    public class NotePostDto : IDto
    {
        public int AdminId { get; set; }
        public string? Subject { get; set; }
    }
}
