using EngineeringServices.Model.Entities;
using Infrastructure.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineeringServices.DataAccess.Interfaces
{
    public interface IMessageRepository : IBaseRepository<Message>
    {
        Task<Message> GetById(int messageId, params string[] includeList);
    }
}
