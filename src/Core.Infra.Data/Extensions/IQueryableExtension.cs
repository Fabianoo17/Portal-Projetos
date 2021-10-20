using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Core.Infra.Data.Extensions
{
    public static class IQueryableExtension
    {
        public static IQueryable<TEntity> AddIncludes<TEntity, TProperty>(this IQueryable<TEntity> source, List<Expression<Func<TEntity, TProperty>>> expressionIncludes) where TEntity : class
        {
            if (expressionIncludes != null)
            {
                foreach (var include in expressionIncludes)
                {
                    source = source.Include(include);
                }
            }
            return source;
        }
    }
}
