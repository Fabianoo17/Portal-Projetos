using Core.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Business.Interfaces.Repositories
{
    public interface IRepositoryBaseReader<TEntity> : IDisposable where TEntity : Entity
    {
        // Read
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expressionSearch, List<Expression<Func<TEntity, object>>> expressionIncludes = null);
        Task<IEnumerable<TEntity>> GetManyAsync(Expression<Func<TEntity, bool>> expressionSearch, List<Expression<Func<TEntity, object>>> expressionIncludes = null);
        IEnumerable<TEntity> GetPaged(Expression<Func<TEntity, bool>> expressionSearch, List<Expression<Func<TEntity, object>>> expressionIncludes, int page, int pageSize, out int itemCount);
        Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> expression);
        Task<IEnumerable<TEntity>> GetAllAsync();
    }
}
