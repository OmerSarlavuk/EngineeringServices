using Infrastructure.Model;

namespace EngineeringServices.Model.Dtos.WorkInformation
{
    public class WorkInformationPutDto : IDto
    {
        public int WorkInformationId { get; set; }
        public int PersonId { get; set; }
        public int Hour { get; set; }
        public int Day { get; set; }
        public int Wage { get; set; }
        public string? Rank { get; set; }
    }
}
