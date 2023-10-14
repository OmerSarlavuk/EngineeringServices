using EngineeringServices.Business.Interfaces;
using EngineeringServices.Model.Dtos.WorkInformation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EngineeringServices.WebAPI.Controllers
{
    [Route("/api/[controller]")]
    public class WorkInformationsController : BaseController
    {
        private readonly IWorkInformationBs _workInformationBs;
        public WorkInformationsController(IWorkInformationBs workInformationBs)
        {
            _workInformationBs = workInformationBs;
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetWInfo()
        {
            var winfos = await _workInformationBs.GetWInfoAsync();
            return SendResponse(winfos);
        }
        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetById(int id)
        {
            var winfo = await _workInformationBs.GetByIdAsync(id);
            return SendResponse(winfo);
        }
        [HttpPut]
        [Authorize]
        public async Task<IActionResult> Update([FromBody]WorkInformationPutDto dto)
        {
            var response = await _workInformationBs.UpdateAsync(dto);
            return SendResponse(response);  
        }
    }
}
