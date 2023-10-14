using Infrastructure.Model;

namespace EngineeringServices.Model.Dtos.Note
{
    public class NoteGetDto : IDto
    {
        public int Id { get; set; }
        public int AdminId { get; set; }
        public string? Subject { get; set; }
    }
}
