using EngineeringServices.Model.Dtos.WorkInformation;
using Infrastructure.Utilities.ApiResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineeringServices.Business.Interfaces
{
    public interface IWorkInformationBs
    {
        Task<ApiResponse<WorkInformationGetDto>> GetByIdAsync(int workinformationId, params string[] includeList);
        Task<ApiResponse<List<WorkInformationGetDto>>> GetWInfoAsync(params string[] includeList);
        Task<ApiResponse<NoData>> UpdateAsync(WorkInformationPutDto dto);
    }
}
