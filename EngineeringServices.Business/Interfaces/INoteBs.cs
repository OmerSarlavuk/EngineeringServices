using EngineeringServices.Model.Dtos.Note;
using EngineeringServices.Model.Entities;
using Infrastructure.Utilities.ApiResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineeringServices.Business.Interfaces
{
    public interface INoteBs
    {
        Task<ApiResponse<List<NoteGetDto>>> GetNoteAsync(params string[] includeList);
        Task<ApiResponse<NoteGetDto>> GetByIdAsync(int noteId, params string[] includeList);
        Task<ApiResponse<Note>> InsertAsync(NotePostDto dto);
        Task<ApiResponse<NoData>> UpdateAsync(NotePutDto dto);
        Task<ApiResponse<NoData>> DeleteAsync(int noteId);
    }
}
