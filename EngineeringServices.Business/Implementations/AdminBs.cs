using AHL.Business.CustomExceptions;
using AutoMapper;
using EngineeringServices.Business.Interfaces;
using EngineeringServices.Business.NotificationsBs;
using EngineeringServices.DataAccess.Interfaces;
using EngineeringServices.Model.Dtos.Admin;
using Infrastructure.Log;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace EngineeringServices.Business.Implementations
{
    public class AdminBs : IAdminBs
    {
        private readonly IAdminRepository _adminRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<AdminBs> _logger;
        public AdminBs(IAdminRepository adminRepository, IMapper mapper, ILogger<AdminBs> logger)
        {
            _adminRepository = adminRepository;
            _mapper = mapper;   
            _logger = logger;
        }
        public async Task<ApiResponse<AdminGetDto>> LogIn(string userName, string password, params string[] includeList)
        {
            LogBs.Time(_logger);
            LogBs.Info(userName, _logger);
            userName = userName.Trim();
            if (string.IsNullOrEmpty(userName))
            {
                throw new BadRequestException(ErrorNotification.UserNameError);
            }

            if (userName.Length <= 2)
            {
                throw new BadRequestException(ErrorNotification.UserNameLengthError);
            }

            password = password.Trim();
            if (string.IsNullOrEmpty(password))
            {
                throw new BadRequestException(ErrorNotification.ThisBlankError);
            }

            var adminUser = await _adminRepository.GetByUserNameAndPasswordAsync(userName, password, includeList);

            if (adminUser != null)
            {
                try
                {
                    var dto = _mapper.Map<AdminGetDto>(adminUser);
                    return ApiResponse<AdminGetDto>.Success(StatusCodes.Status200OK, dto);
                }
                catch (Exception ex) 
                {
                    LogBs.Error(_logger, ex.Message);
                }
            }
            throw new NotFoundException(ErrorNotification.NotContentError);
        }
    }
}
