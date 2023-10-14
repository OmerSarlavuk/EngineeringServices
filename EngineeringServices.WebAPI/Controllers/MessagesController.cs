using EngineeringServices.Business.Interfaces;
using EngineeringServices.Model.Dtos.Message;
using Infrastructure.Log;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EngineeringServices.WebAPI.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class MessagesController : BaseController
    {
        private readonly IMessageBs _messageBs;
        public MessagesController(IMessageBs messageBs)
        {
            _messageBs = messageBs;
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetMessages()
        {
            var messages = await _messageBs.GetMessageAsync();
            return SendResponse(messages);
        }
        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetById(int id)
        {
            var message = await _messageBs.GetByIdAsync(id);
            return SendResponse(message);
        }
        [HttpPost]
        public async Task<IActionResult> SaveNewMessage([FromBody] MessagePostDto dto)
        {
            var response = await _messageBs.InsertAsync(dto);

            if (response.ErrorMessages != null && response.ErrorMessages.Count > 0)
                return SendResponse(response);
            else 
                return CreatedAtAction(nameof(GetById), new {id = response.Data!.MessageId}, response);
        }
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _messageBs.DeleteAsync(id);
            return SendResponse(response);
        }
    }
}
