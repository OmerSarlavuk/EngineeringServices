using Infrastructure.Model;

namespace EngineeringServices.Model.Entities
{
    public class Person : IEntity
    {
        public int PersonId { get; set; }
        public int EngineeringId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PhotoPath { get; set; }
        public bool? IsActive { get; set; }
        public string? Subject { get; set; }

        public Engineering? Engineering { get; set; }
        public PersonalInformation? PersonalInformation { get; set; }
        public WorkInformation? WorkInformation { get; set; }
    }
}
