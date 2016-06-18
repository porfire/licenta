using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataModel.Repository
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> Get();
        TEntity GetByID(object id);
        void Insert(TEntity entity);
        void Delete(object id);
        void Delete(TEntity entityToDelete);
        void Update(TEntity entityToUpdate);
        IEnumerable<TEntity> GetMany(Func<TEntity, bool> where);
        TEntity Get(Func<TEntity, Boolean> where);
        void Delete(Func<TEntity, Boolean> where);
        IEnumerable<TEntity> GetAll();

        IQueryable<TEntity> GetWithInclude(
            System.Linq.Expressions.Expression<Func<TEntity,
                bool>> predicate, params string[] include);

        bool Exists(object primaryKey);
        TEntity GetSingle(Func<TEntity, bool> predicate);
        int Count(Expression<Func<TEntity, bool>> predicate);

        TEntity GetFirst(Func<TEntity, bool> predicate);
        ICollection<TEntity> Where(Expression<Func<TEntity, bool>> predicate);

    }
}
