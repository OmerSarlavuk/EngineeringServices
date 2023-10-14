using Infrastructure.Model;

namespace EngineeringServices.Model.Dtos.Engineering
{
    public class EngineeringGetDto : IDto
    {
        public int EngineeringId { get; set; }
        public string? Name { get; set; }
    }
}
