using Microsoft.EntityFrameworkCore;
using Core.Business.Interfaces.Repositories;
using Core.Business.Entities;
using Core.Infra.Data.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;


namespace Core.Infra.Data.Repositories
{
    public class EFRepositoryBase<TEntity, Context> : IRepositoryBaseReader<TEntity>, IRepositoryBaseWriter<TEntity> where TEntity : Entity where Context : DbContext
    {
        protected readonly Context DbContext;
        protected readonly DbSet<TEntity> Entity;

        public EFRepositoryBase(Context applicationDbContext)
        {
            DbContext = applicationDbContext;
            Entity = DbContext.Set<TEntity>();
        }

        public virtual async Task<TEntity> CreateAsync(TEntity entity)
        {
            Entity.Add(entity);
            await DbContext.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<TEntity> UpdateAsync(TEntity entity)
        {
            Entity.Update(entity);
            await DbContext.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<bool> DeleteAsync(object id)
        {
            var item = Entity.Find(id);
            DbContext.Remove(item);
            return await DbContext.SaveChangesAsync() > 0;
        }

        public virtual async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expressionSearch, List<Expression<Func<TEntity, object>>> expressionIncludes = null)
        {
            var query = Entity as IQueryable<TEntity>;
            query = query.AddIncludes(expressionIncludes);

            return await query.FirstOrDefaultAsync(expressionSearch);
        }

        public virtual async Task<IEnumerable<TEntity>> GetManyAsync(Expression<Func<TEntity, bool>> expressionSearch, List<Expression<Func<TEntity, object>>> expressionIncludes = null)
        {
            var query = Entity as IQueryable<TEntity>;
            query = query.AddIncludes(expressionIncludes);

            return await query.Where(expressionSearch).ToListAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await Entity.ToListAsync();
        }
        public virtual IEnumerable<TEntity> GetPaged(Expression<Func<TEntity, bool>> expressionSearch, List<Expression<Func<TEntity, object>>> expressionIncludes, int page, int pageSize, out int itemCount)
        {
            var query = Entity as IQueryable<TEntity>;
            query = query.AddIncludes(expressionIncludes);

            var skip = (page - 1) * pageSize;
            itemCount = query.Count(expressionSearch);

            var result = query
                .Where(expressionSearch)
                .Skip(skip)
                .Take(pageSize)
                .ToList();

            return result;
        }

        public async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await Entity.AsNoTracking().AnyAsync(expression);
        }

        public void Dispose()
        {
            DbContext.Dispose();
        }


    }
}
