using EngineeringServices.Model.Entities;
using Infrastructure.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineeringServices.DataAccess.Interfaces
{
    public interface IWorkInformationRepository : IBaseRepository<WorkInformation>
    {
        Task<WorkInformation> GetByIdAsync(int workinformationId, params string[] includeList);
    }
}
