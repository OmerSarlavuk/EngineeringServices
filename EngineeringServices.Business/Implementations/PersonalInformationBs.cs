using AHL.Business.CustomExceptions;
using AutoMapper;
using Castle.Core.Logging;
using EngineeringServices.Business.Interfaces;
using EngineeringServices.Business.NotificationsBs;
using EngineeringServices.DataAccess.Interfaces;
using EngineeringServices.Model.Dtos.PersonalInformation;
using EngineeringServices.Model.Entities;
using Infrastructure.Log;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace EngineeringServices.Business.Implementations
{
    public class PersonalInformationBs : IPersonalInformationBs
    {
        private readonly IPersonalInformationRepository _personalInformationRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<PersonalInformationBs> _logger;
        public PersonalInformationBs(IPersonalInformationRepository personalInformationRepository,
            IMapper mapper, ILogger<PersonalInformationBs> logger)
        {
            _personalInformationRepository = personalInformationRepository;
            _mapper = mapper;   
            _logger = logger;
        }
        public async Task<ApiResponse<PersonalInformationGetDto>> GetByIdAsync(int personalinformationId, params string[] includeList)
        {
            LogBs.Time(_logger);
            if (personalinformationId <= 0)
                throw new BadRequestException(ErrorNotification.IdError);

            var personalInformation = await _personalInformationRepository.GetByIdAsync(personalinformationId, includeList);
            
            if(personalInformation != null)
            {
                var dto = _mapper.Map<PersonalInformationGetDto>(personalInformation);

                return ApiResponse<PersonalInformationGetDto>.Success(StatusCodes.Status200OK, dto);
            }
            throw new NotFoundException(ErrorNotification.NotIdData);
        }

        public async Task<ApiResponse<List<PersonalInformationGetDto>>> GetPInfoAsync(params string[] includeList)
        {
            LogBs.Time(_logger);
            var personalInformations = await _personalInformationRepository.GetAllAsync(predicate: null!, includeList);
        
            if(personalInformations.Count > 0)
            {
                var returnList = _mapper.Map<List<PersonalInformationGetDto>>(personalInformations);

                var response = ApiResponse<List<PersonalInformationGetDto>>.Success(StatusCodes.Status200OK, returnList);

                return response;
            }
            throw new NotFoundException(ErrorNotification.NotDataAll);
        }

        public async Task<ApiResponse<NoData>> UpdateAsync(PersonalInformationPutDto dto)
        {
            LogBs.Time(_logger);
            if (dto.PersonalInformationId <= 0)
                throw new BadRequestException(ErrorNotification.IdError);

            var personalInformation = _mapper.Map<PersonalInformation>(dto);
            personalInformation.IsActive = true;

            await _personalInformationRepository.UpdateAsync(personalInformation);

            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }
    }
}
