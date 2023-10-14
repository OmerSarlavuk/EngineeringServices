using EngineeringServices.DataAccess.EntityFramework.Context;
using EngineeringServices.DataAccess.Interfaces;
using EngineeringServices.Model.Entities;
using Infrastructure.DataAccess.Implementations.EF;

namespace EngineeringServices.DataAccess.EntityFramework.Repositories
{
    public class WorkInformationRepository : BaseRepository<WorkInformation, EngineeringServicesDataContext>, IWorkInformationRepository
    {
        public async Task<WorkInformation> GetByIdAsync(int workinformationId, params string[] includeList)
        {
            return await GetAsync(winfo => winfo.WorkInformationId == workinformationId, includeList);
        }
    }
}
