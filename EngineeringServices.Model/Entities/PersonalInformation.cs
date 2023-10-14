using Infrastructure.Model;

namespace EngineeringServices.Model.Entities
{
    public class PersonalInformation : IEntity
    {
        public int PersonalInformationId {  get; set; }
        public int PersonId { get; set; }
        public int Age { get; set; }
        public string? University { get; set; }
        public string? City { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? OpenAddress{ get; set; }
        public string? PhotoPath { get; set; }
        public bool? IsActive { get; set; }
        public string? Gender { get; set; }

        public Person? Person { get; set; }
    }
}
