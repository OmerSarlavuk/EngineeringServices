using Infrastructure.Model;

namespace EngineeringServices.Model.Dtos.WorkInformation
{
    public class WorkInformationGetDto : IDto
    {
        public int WorkInformationId { get; set; }
        public int PersonId { get; set; }
        public string? FirstName { get; set; }  // Person bilgilerinden 
        public string? LastName { get; set; }   // gelecek
        public int Hour { get; set; }
        public int Day { get; set; }
        public int Wage { get; set; }
        public string? Rank { get; set; }
        public bool? IsActive { get; set; }
    }
}
