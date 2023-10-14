using AHL.Business.CustomExceptions;
using AutoMapper;
using EngineeringServices.Business.Interfaces;
using EngineeringServices.Business.NotificationsBs;
using EngineeringServices.DataAccess.Interfaces;
using EngineeringServices.Model.Dtos.Message;
using EngineeringServices.Model.Entities;
using Infrastructure.Log;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace EngineeringServices.Business.Implementations
{
    public class MessageBs : IMessageBs
    {   
        private readonly IMessageRepository _messageRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<MessageBs> _logger;
        public MessageBs(IMessageRepository messageRepository, IMapper mapper, ILogger<MessageBs> logger)
        {
            _messageRepository = messageRepository; 
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<ApiResponse<MessageGetDto>> GetByIdAsync(int messageId, params string[] includeList)
        {
            LogBs.Time(_logger);
            if (messageId <= 0)
                throw new BadRequestException(ErrorNotification.IdError);

            var message = await _messageRepository.GetById(messageId);

            if(message != null)
            {
                var dto = _mapper.Map<MessageGetDto>(message);

                return ApiResponse<MessageGetDto>.Success(StatusCodes.Status200OK, dto);
            }
            throw new NotFoundException(ErrorNotification.NotIdData);
        }
        public async Task<ApiResponse<List<MessageGetDto>>> GetMessageAsync(params string[] includeList)
        {
            LogBs.Time(_logger);

            var messages = await _messageRepository.GetAllAsync(predicate:null!, includeList);
        
            if(messages.Count > 0)
            {
                var returnList = _mapper.Map<List<MessageGetDto>>(messages);

                var response = ApiResponse<List<MessageGetDto>>.Success(StatusCodes.Status200OK, returnList);

                return response;
            }
            throw new NotFoundException(ErrorNotification.NotDataAll);
        }
        public async Task<ApiResponse<Message>> InsertAsync(MessagePostDto dto)
        {
            LogBs.Time(_logger);

            if (dto.Subject == null)
                throw new ArgumentNullException(ErrorNotification.ThisBlankError);
            
            if (dto.Email == null)
                throw new ArgumentNullException(ErrorNotification.ThisBlankError);


            var message = _mapper.Map<Message>(dto);
            message.IsActive = true;

            var insertedMessage = await _messageRepository.InsertAsync(message);
            return ApiResponse<Message>.Success(StatusCodes.Status200OK, insertedMessage);
        }
        public async Task<ApiResponse<NoData>> DeleteAsync(int messageId)
        {
            LogBs.Time(_logger);

            if (messageId <= 0)
                throw new BadRequestException(ErrorNotification.IdError);

            var message = await _messageRepository.GetById(messageId);

            if(message != null)
                message.IsActive = false;

            await _messageRepository.UpdateAsync(message);

            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }
    }
}
