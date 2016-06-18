using System;
using System.Linq;
using System.Linq.Expressions;
using DataModel;

namespace WebAPI.Repository
{
    public interface IOpenAccessBaseRepository<TEntity, TContext>
       where TContext : AgentieImobiliaraEntities, new()
    {
        IQueryable<TEntity> GetAll();
        TEntity GetBy(Expression<Func<TEntity, bool>> filter);
        TEntity AddNew(TEntity entity);
        TEntity Update(TEntity entity);
        void Delete(TEntity entity);
    }
}