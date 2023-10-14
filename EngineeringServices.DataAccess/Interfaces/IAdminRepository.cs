using EngineeringServices.Model.Entities;
using Infrastructure.DataAccess.Interfaces;


namespace EngineeringServices.DataAccess.Interfaces
{
    public interface IAdminRepository : IBaseRepository<Admin>
    {
        Task<Admin> GetByUserNameAndPasswordAsync(string userName, string password, params string[] includeList);
    }
}                                                           
