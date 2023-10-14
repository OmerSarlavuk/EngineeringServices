using EngineeringServices.Business.Interfaces;
using EngineeringServices.Model.Dtos.PersonalInformation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EngineeringServices.WebAPI.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class PersonalInformationsController : BaseController
    {
        private readonly IPersonalInformationBs _personalInformationBs;
        public PersonalInformationsController(IPersonalInformationBs personalInformationBs)
        {
            _personalInformationBs = personalInformationBs; 
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetPinfo()
        {
            var pinfos = await _personalInformationBs.GetPInfoAsync("Person");
            return SendResponse(pinfos);
        }
        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetById(int id)
        {
            var pinfo = await _personalInformationBs.GetByIdAsync(id, "Person");
            return SendResponse(pinfo);
        }
        [HttpPut]
        [Authorize]
        public async Task<IActionResult> Update([FromBody]PersonalInformationPutDto dto)
        {
            var response = await _personalInformationBs.UpdateAsync(dto);
            return SendResponse(response);
        }
    }
}
