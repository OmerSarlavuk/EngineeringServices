using Infrastructure.Model;

namespace EngineeringServices.Model.Entities
{
    public class Admin : IEntity
    {
        public int AdminId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? PhotoPath { get; set; }
        public bool? IsActive { get; set; }

        public List<Note>? Note { get; set; }
    }
}
