using Infrastructure.Model;

namespace EngineeringServices.Model.Dtos.Note
{
    public class NotePutDto : IDto
    {
        public int Id { get; set; }
        public int AdminId { get; set; }
        public string? Subject { get; set; }
    }
}
