using EngineeringServices.DataAccess.EntityFramework.Context;
using EngineeringServices.DataAccess.Interfaces;
using EngineeringServices.Model.Entities;
using Infrastructure.DataAccess.Implementations.EF;

namespace EngineeringServices.DataAccess.EntityFramework.Repositories
{
    public class EngineeringRepository : BaseRepository<Engineering, EngineeringServicesDataContext>, IEngineeringRepository
    {
        public async Task<Engineering> GetByIdAsync(int engineeringId, params string[] includeList)
        {
            return await GetAsync(eng => eng.EngineeringId == engineeringId, includeList);
        }
    }
}
