using EngineeringServices.Model.Entities;
using Infrastructure.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineeringServices.DataAccess.Interfaces
{
    public interface IPersonRepository : IBaseRepository<Person>
    {
        Task<Person> GetByIdAsync(int personId, params string[] includeList);
        Task<List<Person>> GetPersonUIAsync(int engineeringId, params string[] includeList);
    }
}
