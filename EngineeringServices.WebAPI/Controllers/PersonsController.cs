using EngineeringServices.Business.Interfaces;
using EngineeringServices.DataAccess.Interfaces;
using EngineeringServices.Model.Dtos.Person;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EngineeringServices.WebAPI.Controllers
{
    [Route("/api/[controller]")]
    public class PersonsController : BaseController
    {
        private readonly IPersonBs _personBs;
        private readonly IPersonalInformationRepository _personalInformationRepository;
        private readonly IWorkInformationRepository _workInformationRepository;
        public PersonsController(IPersonBs personBs, 
            IWorkInformationRepository workInformationRepository,
            IPersonalInformationRepository personalInformationRepository)
        {
            _personBs = personBs;
            _workInformationRepository = workInformationRepository;
            _personalInformationRepository = personalInformationRepository;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetPerson()
        {
            var persons = await _personBs.GetPersonAsync("Engineering", "PersonalInformation", "WorkInformation");
            return SendResponse(persons);
        }
        [HttpGet("person/{id}")]
        [Authorize]
        public async Task<IActionResult> GetById(int id)
        {
            var person = await _personBs.GetByIdAsync(id, "Engineering", "PersonalInformation", "WorkInformation");
            return SendResponse(person);
        }
        [HttpPost]
        public async Task<IActionResult> SaveNewPerson([FromBody]PersonPostDto dto)
        {
            var response = await _personBs.InsertAsync(dto);
            if (response.ErrorMessages != null && response.ErrorMessages.Count > 0)
                return SendResponse(response);
            else
                return CreatedAtAction(nameof(GetById), new { id = response.Data.PersonId }, response);
          
        }
        [HttpGet("engineering/{id}")]
        [Authorize]
        public async Task<IActionResult> GetPersonsEI(int id)
        {
            var persons = await _personBs.GetAllEngIdAsync(id, "Engineering");
            return SendResponse(persons);
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> Update([FromBody]PersonPutDto dto)
        {
            var response = await _personBs.UpdateAsync(dto);
            return SendResponse(response);
        }
        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _personBs.DeleteAsync(id);
            return SendResponse(response);
        }
    }
}
