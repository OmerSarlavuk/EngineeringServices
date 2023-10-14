using Infrastructure.Model;

namespace EngineeringServices.Model.Dtos.Admin
{
    public class AdminGetDto : IDto
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PhotoPath { get; set; }
        public bool? IsActive { get; set; }
    }
}
