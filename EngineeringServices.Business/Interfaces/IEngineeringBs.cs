using EngineeringServices.Model.Dtos.Engineering;
using Infrastructure.Utilities.ApiResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineeringServices.Business.Interfaces
{
    public interface IEngineeringBs
    {
        Task<ApiResponse<List<EngineeringGetDto>>> GetEngineeringAsync(params string[] includeList);
        Task<ApiResponse<EngineeringGetDto>> GetByIdAsync(int engineeringId, params string[] includeList);
        Task<ApiResponse<NoData>> DeleteAsync(int engineeringId);
    }
}
