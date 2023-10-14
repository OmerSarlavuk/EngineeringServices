using Infrastructure.Model;

namespace EngineeringServices.Model.Dtos.Person
{
    public class PersonGetDto : IDto
    {
        public int PersonId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PhotoPath { get; set; }
        public bool? IsActive { get; set; }
        public string? Name { get; set; } //Engineeringten gelecek

        public int Hour { get; set; }           //
        public int Day { get; set; }
        public int Wage { get; set; }
        public string? Rank { get; set; }       //

        public int Age { get; set; }
        public string? University { get; set; }
        public string? City { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? OpenAddress { get; set; }
        public string? Gender { get; set; }
    }
}
