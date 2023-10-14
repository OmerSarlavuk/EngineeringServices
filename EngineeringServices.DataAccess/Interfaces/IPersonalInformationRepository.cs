using EngineeringServices.Model.Entities;
using Infrastructure.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineeringServices.DataAccess.Interfaces
{
    public interface IPersonalInformationRepository : IBaseRepository<PersonalInformation>
    {
        Task<PersonalInformation> GetByIdAsync(int personalinformationId, params string[] includeList);
    }
}
