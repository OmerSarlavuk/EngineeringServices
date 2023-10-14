using AHL.Business.CustomExceptions;
using AutoMapper;
using Castle.Core.Logging;
using EngineeringServices.Business.Interfaces;
using EngineeringServices.Business.NotificationsBs;
using EngineeringServices.DataAccess.Interfaces;
using EngineeringServices.Model.Dtos.Person;
using EngineeringServices.Model.Entities;
using Infrastructure.Log;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace EngineeringServices.Business.Implementations
{
    public class PersonBs : IPersonBs
    {
        private readonly IPersonRepository _personRepository;
        private readonly IPersonalInformationRepository _personalInformationRepository;
        private readonly IWorkInformationRepository _workInformationRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<PersonalInformationBs> _logger;
        public PersonBs(IPersonRepository personRepository, IMapper mapper, 
            IPersonalInformationRepository personalInformationRepository, 
            IWorkInformationRepository workInformationRepository,
            ILogger<PersonalInformationBs> logger)
        {
            _personRepository = personRepository;
            _mapper = mapper;
            _personalInformationRepository = personalInformationRepository;
            _workInformationRepository = workInformationRepository;
            _logger = logger;
        }
        public async Task<ApiResponse<NoData>> DeleteAsync(int personId)
        {
            LogBs.Time(_logger);

            if (personId <= 0)
                throw new BadRequestException(ErrorNotification.IdError);

            var person = await _personRepository.GetByIdAsync(personId);
            if(person != null)
                person.IsActive = false;
            
            var winfo = await _workInformationRepository.GetAsync(ws => ws.PersonId == personId);
            if (winfo != null)
                winfo.IsActive = false;

            var pinfo = await _personalInformationRepository.GetAsync(ps => ps.PersonId == personId);
            if(pinfo != null)
                pinfo.IsActive = false;


            await _personRepository.UpdateAsync(person!);
            await _workInformationRepository.UpdateAsync(winfo!);
            await _personalInformationRepository.UpdateAsync(pinfo!);

            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }

        public async Task<ApiResponse<PersonGetDto>> GetByIdAsync(int personId, params string[] includeList)
        {
            LogBs.Time(_logger);
            if (personId <= 0)
                throw new BadRequestException(ErrorNotification.IdError);

            var person = await _personRepository.GetByIdAsync(personId, includeList);
            if(person != null)
            {
                var dto = _mapper.Map<PersonGetDto>(person);

                return ApiResponse<PersonGetDto>.Success(StatusCodes.Status200OK, dto);
            }
            throw new NotFoundException(ErrorNotification.NotIdData);
        }

        public async Task<ApiResponse<List<PersonGetDto>>> GetPersonAsync(params string[] includeList)
        {
            LogBs.Time(_logger);
            var persons = await _personRepository.GetAllAsync(predicate: null!, includeList);

            if(persons.Count > 0)
            {
                var returnList = _mapper.Map<List<PersonGetDto>>(persons);

                var response = ApiResponse<List<PersonGetDto>>.Success(StatusCodes.Status200OK, returnList);

                return response;
            }
            throw new NotFoundException(ErrorNotification.NotDataAll);
        }

        public async Task<ApiResponse<List<PersonUIGetDto>>> GetAllEngIdAsync(int engineeringId, params string[] includeList)
        {
            LogBs.Time(_logger);
            if (engineeringId <= 0)
                throw new BadRequestException(ErrorNotification.IdError);

            var persons = await _personRepository.GetPersonUIAsync(engineeringId, includeList);
           
            if(persons.Count > 0)
            {
                var returnList = _mapper.Map<List<PersonUIGetDto>>(persons);

                var response = ApiResponse<List<PersonUIGetDto>>.Success(StatusCodes.Status200OK, returnList);

                return response;
            }

            throw new NotFoundException(ErrorNotification.NotContentError);
        }

        public async Task<ApiResponse<Person>> InsertAsync(PersonPostDto dto)
        {
            LogBs.Time(_logger);
            if (dto.FirstName == null)
                throw new ArgumentNullException(ErrorNotification.ThisBlankError);

            if (dto.LastName == null)
                throw new ArgumentNullException(ErrorNotification.ThisBlankError);

            var person = _mapper.Map<Person>(dto);
            person.IsActive = true;
            person.Subject = "New Content";
            var insertedPerson = await _personRepository.InsertAsync(person);

            await _personalInformationRepository.InsertAsync(new PersonalInformation
            {
                PersonId = insertedPerson.PersonId,
                Age = dto.Age,
                University = dto.University,
                City = dto.City,
                Email = dto.Email,
                Phone = dto.Phone,
                OpenAddress = dto.OpenAddress,
                PhotoPath = dto.PhotoPath,
                IsActive = true,
                Gender = dto.Gender
            });

            await _workInformationRepository.InsertAsync(new WorkInformation
            {
                PersonId= insertedPerson.PersonId,
                Hour = dto.Hour,
                Day = dto.Day,
                Wage = dto.Wage,
                Rank = dto.Rank,
                IsActive= true,
            });

            return ApiResponse<Person>.Success(StatusCodes.Status200OK, insertedPerson);
        }

        public async Task<ApiResponse<NoData>> UpdateAsync(PersonPutDto dto)
        {
            LogBs.Time(_logger);
            if (dto.PersonId <= 0)
                throw new BadRequestException(ErrorNotification.IdError);

            var person = _mapper.Map<Person>(dto);
            person.IsActive = true;
            await _personRepository.UpdateAsync(person);

            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }
    }
}