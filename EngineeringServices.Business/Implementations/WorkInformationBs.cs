using AHL.Business.CustomExceptions;
using AutoMapper;
using Castle.Core.Logging;
using EngineeringServices.Business.Interfaces;
using EngineeringServices.Business.NotificationsBs;
using EngineeringServices.DataAccess.Interfaces;
using EngineeringServices.Model.Dtos.WorkInformation;
using EngineeringServices.Model.Entities;
using Infrastructure.Log;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace EngineeringServices.Business.Implementations
{
    public class WorkInformationBs : IWorkInformationBs
    {
        private readonly IWorkInformationRepository _workInformationRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<WorkInformationBs> _logger;
        public WorkInformationBs(IWorkInformationRepository workInformationRepository, IMapper mapper, ILogger<WorkInformationBs> logger)
        {
            _workInformationRepository = workInformationRepository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<ApiResponse<WorkInformationGetDto>> GetByIdAsync(int workinformationId, params string[] includeList)
        {
            LogBs.Time(_logger);
            if (workinformationId <= 0)
                throw new BadRequestException(ErrorNotification.IdError);

            var workinformation = await _workInformationRepository.GetByIdAsync(workinformationId, includeList);

            if(workinformation != null)
            {
                var dto = _mapper.Map<WorkInformationGetDto>(workinformation);

                return ApiResponse<WorkInformationGetDto>.Success(StatusCodes.Status200OK, dto);
            }
            throw new NotFoundException(ErrorNotification.NotIdData);
        }

        public async Task<ApiResponse<List<WorkInformationGetDto>>> GetWInfoAsync(params string[] includeList)
        {
            LogBs.Time(_logger);
            var workinformations = await _workInformationRepository.GetAllAsync(predicate: null!, includeList);
            
            if(workinformations.Count > 0)
            {
                var returnList = _mapper.Map<List<WorkInformationGetDto>>(workinformations);

                var response = ApiResponse<List<WorkInformationGetDto>>.Success(StatusCodes.Status200OK, returnList);

                return response;
            }
            throw new NotFoundException(ErrorNotification.NotDataAll);
        }

        public async Task<ApiResponse<NoData>> UpdateAsync(WorkInformationPutDto dto)
        {
            LogBs.Time(_logger);
            if (dto.WorkInformationId <= 0)
                throw new BadRequestException(ErrorNotification.IdError);

            var workInformation = _mapper.Map<WorkInformation>(dto);

            workInformation.IsActive = true;

            await _workInformationRepository.UpdateAsync(workInformation);

            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }
    }
}
