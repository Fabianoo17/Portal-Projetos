using Core.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Business.Interfaces.Repositories
{
    public interface IRepositoryBaseWriter<TEntity> : IDisposable where TEntity : Entity
    {
        // Write
        Task<TEntity> CreateAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task<bool> DeleteAsync(object id);
    }
}
