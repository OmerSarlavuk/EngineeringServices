using EngineeringServices.Model.Dtos.Person;
using EngineeringServices.Model.Entities;
using Infrastructure.Utilities.ApiResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineeringServices.Business.Interfaces
{
    public interface IPersonBs
    {
        Task<ApiResponse<List<PersonGetDto>>> GetPersonAsync(params string[] includeList);
        Task<ApiResponse<PersonGetDto>> GetByIdAsync(int personId, params string[] includeList);
        Task<ApiResponse<List<PersonUIGetDto>>> GetAllEngIdAsync(int engineeringId, params string[] includeList);
        Task<ApiResponse<NoData>> UpdateAsync(PersonPutDto dto);
        Task<ApiResponse<NoData>> DeleteAsync(int personId);
        Task<ApiResponse<Person>> InsertAsync(PersonPostDto dto);
    }
}
