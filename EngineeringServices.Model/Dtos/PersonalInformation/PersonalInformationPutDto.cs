using Infrastructure.Model;

namespace EngineeringServices.Model.Dtos.PersonalInformation
{
    public class PersonalInformationPutDto : IDto
    {
        public int PersonalInformationId { get; set; }
        public int PersonId { get; set; }
        public int Age { get; set; }
        public string? University { get; set; }
        public string? City { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? OpenAddress { get; set; }
        public string? Gender { get; set; }
        public string? PhotoPath { get; set; }
    }
}
