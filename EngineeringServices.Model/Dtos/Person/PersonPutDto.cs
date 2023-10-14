using Infrastructure.Model;

namespace EngineeringServices.Model.Dtos.Person
{
    public class PersonPutDto : IDto
    {
        public int PersonId { get; set; }
        public int EngineeringId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PhotoPath { get; set; }
        public string? Subject { get; set; }
    }
}
