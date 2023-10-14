using EngineeringServices.DataAccess.EntityFramework.Context;
using EngineeringServices.DataAccess.Interfaces;
using EngineeringServices.Model.Entities;
using Infrastructure.DataAccess.Implementations.EF;

namespace EngineeringServices.DataAccess.EntityFramework.Repositories
{
    public class PersonRepository : BaseRepository<Person, EngineeringServicesDataContext>, IPersonRepository
    {
        public async Task<Person> GetByIdAsync(int personId, params string[] includeList)
        {
            return await GetAsync(prs => prs.PersonId == personId, includeList);
        }

        public async Task<List<Person>> GetPersonUIAsync(int engineeringId, params string[] includeList)
        {
            return await GetAllAsync(eng => eng.EngineeringId == engineeringId, includeList);
        }
    }
}
