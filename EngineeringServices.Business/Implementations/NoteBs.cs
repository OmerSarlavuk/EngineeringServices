using AHL.Business.CustomExceptions;
using AutoMapper;
using Castle.Core.Logging;
using EngineeringServices.Business.Interfaces;
using EngineeringServices.Business.NotificationsBs;
using EngineeringServices.DataAccess.Interfaces;
using EngineeringServices.Model.Dtos.Note;
using EngineeringServices.Model.Entities;
using Infrastructure.Log;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace EngineeringServices.Business.Implementations
{
    public class NoteBs : INoteBs
    {
        private readonly INoteRepository _noteRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<NoteBs> _logger;
        public NoteBs(INoteRepository noteRepository, IMapper mapper, ILogger<NoteBs> logger)
        {
            _noteRepository = noteRepository;
            _mapper = mapper;
            _logger = logger;
        }


        public async Task<ApiResponse<NoteGetDto>> GetByIdAsync(int noteId, params string[] includeList)
        {
            LogBs.Time(_logger);

            if (noteId <= 0)
                throw new BadRequestException(ErrorNotification.IdError);

            var note = await _noteRepository.GetByIdAsync(noteId, includeList);

            if(note != null)
            {
                var dto = _mapper.Map<NoteGetDto>(note);

                return ApiResponse<NoteGetDto>.Success(StatusCodes.Status200OK, dto);
            }
            throw new NotFoundException(ErrorNotification.NotIdData);
        }

        public async Task<ApiResponse<List<NoteGetDto>>> GetNoteAsync(params string[] includeList)
        {
            LogBs.Time(_logger);
            var notes = await _noteRepository.GetAllAsync(predicate: null!, includeList);
            
            if(notes.Count > 0)
            {
                var returnList = _mapper.Map<List<NoteGetDto>>(notes);

                var response = ApiResponse<List<NoteGetDto>>.Success(StatusCodes.Status200OK, returnList);

                return response;
            }
            throw new NotFoundException(ErrorNotification.NotDataAll);
        }

        public async Task<ApiResponse<Note>> InsertAsync(NotePostDto dto)
        {
            LogBs.Time(_logger);
            if (dto.Subject == null)
                throw new ArgumentNullException(ErrorNotification.ThisBlankError);

            var note = _mapper.Map<Note>(dto);
            note.IsActive = true;
            var insertedNote = await _noteRepository.InsertAsync(note);

            return ApiResponse<Note>.Success(StatusCodes.Status200OK, insertedNote);
        }
        
        public async Task<ApiResponse<NoData>> UpdateAsync(NotePutDto dto)
        {
            LogBs.Time(_logger);
            if (dto.Id <= 0)
                throw new BadRequestException(ErrorNotification.IdError);

            var note = _mapper.Map<Note>(dto);
            note.IsActive = true;
            await _noteRepository.UpdateAsync(note);

            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);

        }

        public async Task<ApiResponse<NoData>> DeleteAsync(int noteId)
        {
            LogBs.Time(_logger);
            if (noteId <= 0)
                throw new BadRequestException(ErrorNotification.IdError);
        
            var note = await _noteRepository.GetByIdAsync(noteId);

            await _noteRepository.DeleteAsync(note);

            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }
    }
}
