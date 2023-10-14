using EngineeringServices.Model.Dtos.Message;
using EngineeringServices.Model.Entities;
using Infrastructure.Utilities.ApiResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineeringServices.Business.Interfaces
{
    public interface IMessageBs
    {
        Task<ApiResponse<MessageGetDto>> GetByIdAsync(int messageId, params string[] includeList);
        Task<ApiResponse<List<MessageGetDto>>> GetMessageAsync(params string[] includeList);
        Task<ApiResponse<Message>> InsertAsync(MessagePostDto dto);
        Task<ApiResponse<NoData>> DeleteAsync(int messageId);
    }
}
