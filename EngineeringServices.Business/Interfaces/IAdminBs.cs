using EngineeringServices.Model.Dtos.Admin;
using Infrastructure.Utilities.ApiResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineeringServices.Business.Interfaces
{
    public interface IAdminBs
    {
        Task<ApiResponse<AdminGetDto>> LogIn(string userName, string password, params string[] includeList);
    }
}
