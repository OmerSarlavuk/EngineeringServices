using EngineeringServices.Business.Interfaces;
using EngineeringServices.Model.Dtos.Engineering;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EngineeringServices.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EngineeringsController : BaseController
    {
        private readonly IEngineeringBs _engineeringBs;
        public EngineeringsController(IEngineeringBs engineeringBs)
        {
            _engineeringBs = engineeringBs;
        }
        [HttpGet]
        //[Authorize]
        public async Task<IActionResult> GetEngineerings()
        {
            var engineerings = await _engineeringBs.GetEngineeringAsync();
          
            return SendResponse(engineerings);
        }
        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetById(int id)
        {
            var engineering = await _engineeringBs.GetByIdAsync(id);

            return SendResponse(engineering);
        }
        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            var response =  await _engineeringBs.DeleteAsync(id);
            return SendResponse(response);
        }
    }
}
