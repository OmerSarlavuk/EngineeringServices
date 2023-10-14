using AHL.Business.CustomExceptions;
using EngineeringServices.Business.Interfaces;
using EngineeringServices.Model.Dtos.Note;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EngineeringServices.WebAPI.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class NotesController : BaseController
    {
        private readonly INoteBs _noteBs;
        public NotesController(INoteBs noteBs)
        {
            _noteBs = noteBs;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetNotes()
        {
            var notes = await _noteBs.GetNoteAsync("Admin");
            return SendResponse(notes);
        }
        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetById(int id)
        {
            var note = await _noteBs.GetByIdAsync(id, "Admin");
            return SendResponse(note);
        }
        [HttpPost]
        public async Task<IActionResult> SaveNewNote([FromBody]NotePostDto dto)
        {
            var response = await _noteBs.InsertAsync(dto);
            if (response.ErrorMessages != null && response.ErrorMessages.Count > 0)
                return SendResponse(response);
            else
                return CreatedAtAction(nameof(GetById), new { id = response.Data.Id }, response);
        }
        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _noteBs.DeleteAsync(id);
            return SendResponse(response);
        }
        [HttpPut]
        [Authorize]
        public async Task<IActionResult> Update([FromBody]NotePutDto dto)
        {
            var response = await _noteBs.UpdateAsync(dto);
            return SendResponse(response);
        }
    }
}
