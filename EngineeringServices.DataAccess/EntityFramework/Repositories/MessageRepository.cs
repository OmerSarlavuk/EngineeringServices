using EngineeringServices.DataAccess.EntityFramework.Context;
using EngineeringServices.DataAccess.Interfaces;
using EngineeringServices.Model.Entities;
using Infrastructure.DataAccess.Implementations.EF;

namespace EngineeringServices.DataAccess.EntityFramework.Repositories
{
    public class MessageRepository : BaseRepository<Message, EngineeringServicesDataContext>, IMessageRepository
    {
        public async Task<Message> GetById(int messageId, params string[] includeList)
        {
            return await GetAsync(msg => msg.MessageId == messageId, includeList);
        }
    }
}
