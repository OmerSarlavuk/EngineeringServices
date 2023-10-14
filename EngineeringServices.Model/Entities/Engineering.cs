using Infrastructure.Model;

namespace EngineeringServices.Model.Entities
{
    public class Engineering : IEntity
    {
        public int  EngineeringId { get; set; }
        public string? Name { get; set; }
        public bool? IsActive { get; set; }

        public List<Person>? Person {  get; set; }
    }
}
