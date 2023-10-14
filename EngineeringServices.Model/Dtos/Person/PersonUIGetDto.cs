using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineeringServices.Model.Dtos.Person
{
    public class PersonUIGetDto : IDto
    {
        public int EngineeringId { get; set; } //nav
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Name { get; set; }
        public string? PhotoPath { get; set; }
        public string? Subject { get; set; }
    }
}
