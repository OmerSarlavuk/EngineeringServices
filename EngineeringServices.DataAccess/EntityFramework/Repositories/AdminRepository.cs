using EngineeringServices.DataAccess.EntityFramework.Context;
using EngineeringServices.DataAccess.Interfaces;
using EngineeringServices.Model.Entities;
using Infrastructure.DataAccess.Implementations.EF;

namespace EngineeringServices.DataAccess.EntityFramework.Repositories
{
    public class AdminRepository : BaseRepository<Admin, EngineeringServicesDataContext>, IAdminRepository
    {
        public async Task<Admin> GetByUserNameAndPasswordAsync(string userName, string password, params string[] includeList)
        {
            return await GetAsync(adm => adm.UserName == userName && adm.Password == password &&
            adm.IsActive!.Value, includeList);
        }
    }
}
