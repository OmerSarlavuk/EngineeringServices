using Infrastructure.DataAccess.Interfaces;
using Infrastructure.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DataAccess.Implementations.Dapper
{
    public abstract class DapperBaseRepository<TEntity> : IBaseRepository<TEntity> 
        where TEntity : class, IEntity, new()
    {
        public Task DeleteAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate = null, params string[] includeList)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate, params string[] includeList)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> InsertAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
