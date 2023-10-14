using EngineeringServices.Model.Dtos.PersonalInformation;
using Infrastructure.Utilities.ApiResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineeringServices.Business.Interfaces
{
    public interface IPersonalInformationBs
    {
        Task<ApiResponse<List<PersonalInformationGetDto>>> GetPInfoAsync(params string[] includeList);
        Task<ApiResponse<PersonalInformationGetDto>> GetByIdAsync(int personalinformationId, params string[] includeList);
        Task<ApiResponse<NoData>> UpdateAsync(PersonalInformationPutDto dto);
    }
}
