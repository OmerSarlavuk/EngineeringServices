using Infrastructure.Model;

namespace EngineeringServices.Model.Entities
{
    public class Note : IEntity
    {
        public int Id { get; set; }
        public int AdminId { get; set; }
        public string? Subject { get; set; }
        public bool? IsActive { get; set; }

        public Admin? Admin { get; set; }
    }
}
