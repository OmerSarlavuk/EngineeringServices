using Infrastructure.Model;

namespace EngineeringServices.Model.Entities
{
    public class Message : IEntity
    {
        public int MessageId { get; set; }
        public string? Subject { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public bool? IsActive { get; set; }
    }
}
