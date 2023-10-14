using Infrastructure.Model;

namespace EngineeringServices.Model.Entities
{
    public class WorkInformation : IEntity
    {
        public int WorkInformationId { get; set; }
        public int PersonId { get; set; }
        public int Hour { get; set; }
        public int Day {  get; set; }
        public int Wage { get; set; }
        public string? Rank { get; set; }
        public bool? IsActive { get; set; }

        public Person? Person { get; set; }
    }
}
