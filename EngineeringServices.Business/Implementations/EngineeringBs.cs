using AHL.Business.CustomExceptions;
using AutoMapper;
using EngineeringServices.Business.Interfaces;
using EngineeringServices.Business.NotificationsBs;
using EngineeringServices.DataAccess.Interfaces;
using EngineeringServices.Model.Dtos.Engineering;
using Infrastructure.Log;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace EngineeringServices.Business.Implementations
{
    public class EngineeringBs : IEngineeringBs
    {
        private readonly IEngineeringRepository _engineeringRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<EngineeringBs> _logger;
        public EngineeringBs(IEngineeringRepository engineeringRepository, 
            IMapper mapper, ILogger<EngineeringBs> logger)
        {
            _engineeringRepository = engineeringRepository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<ApiResponse<EngineeringGetDto>> GetByIdAsync(int engineeringId, params string[] includeList)
        {
            LogBs.Time(_logger);

            if (engineeringId <= 0)
                throw new BadRequestException(ErrorNotification.IdError);
            
            var engineering = await _engineeringRepository.GetByIdAsync(engineeringId);

            if(engineering != null)
            {
                try
                {
                    var dto = _mapper.Map<EngineeringGetDto>(engineering);
                    return ApiResponse<EngineeringGetDto>.Success(StatusCodes.Status200OK, dto);
                }
                catch (Exception ex) 
                {
                    LogBs.Error(_logger, ex.Message);
                }
            }

            throw new NotFoundException(ErrorNotification.NotIdData);
        }

        public async Task<ApiResponse<List<EngineeringGetDto>>> GetEngineeringAsync(params string[] includeList)
        {
            LogBs.Time(_logger);

            var engineering = await _engineeringRepository.GetAllAsync(predicate: null!, includeList);

            if(engineering.Count > 0)
            {
                var returnList = _mapper.Map<List<EngineeringGetDto>>(engineering);

                var response = ApiResponse<List<EngineeringGetDto>>.Success(StatusCodes.Status200OK, returnList);

                return response;
            }
            throw new BadRequestException(ErrorNotification.NotDataAll);
        }
        public async Task<ApiResponse<NoData>> DeleteAsync(int engineeringId)
        {
            LogBs.Time(_logger);

            if (engineeringId <= 0)
                throw new BadRequestException(ErrorNotification.IdError);

            var engineerings = await _engineeringRepository.GetByIdAsync(engineeringId);

            if (engineerings == null)
                throw new NotFoundException(ErrorNotification.NotIdData);

            try
            {
                engineerings.IsActive = false;
                await _engineeringRepository.UpdateAsync(engineerings);
                return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
            }
            catch (Exception ex) 
            {
                LogBs.Error(_logger, ex.Message);
            }
            throw new BadRequestException(ErrorNotification.NotContentError);
        }
    }
}
