using EngineeringServices.DataAccess.EntityFramework.Context;
using EngineeringServices.DataAccess.Interfaces;
using EngineeringServices.Model.Entities;
using Infrastructure.DataAccess.Implementations.EF;

namespace EngineeringServices.DataAccess.EntityFramework.Repositories
{
    public class PersonalInformationRepository : BaseRepository<PersonalInformation, EngineeringServicesDataContext>, IPersonalInformationRepository
    {
        public async Task<PersonalInformation> GetByIdAsync(int personalinformationId, params string[] includeList)
        {
            return await GetAsync(pinfo => pinfo.PersonalInformationId == personalinformationId, includeList);
        }
    }
}
