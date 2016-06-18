//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using DataModel;

//namespace WebAPI.Repository
//{
//    public abstract partial class OpenAccessBaseRepository<TEntity, TContext> :
//        IOpenAccessBaseRepository<TEntity, TContext>
//        where TContext : AgentieImobiliaraEntities, new()
//    {
//        protected TContext dataContext = new TContext();
//        protected FetchStrategy fetchStrategy = new FetchStrategy();

//        public virtual IQueryable<TEntity> GetAll()
//        {
//            List<TEntity> allEntities = dataContext.
//                GetAll<TEntity>().ToList();

//            List<TEntity> detachedEntities = dataContext.
//                CreateDetachedCopy<List<TEntity>>(allEntities, fetchStrategy);

//            return detachedEntities.AsQueryable();
//        }

//        public virtual TEntity GetBy(Expression<Func<TEntity, bool>> filter)
//        {
//            if (filter == null)
//                throw new ArgumentNullException("filter");

//            TEntity entity = dataContext.GetAll<TEntity>().
//                SingleOrDefault(filter);
//            if (entity == null)
//                return default(TEntity);

//            TEntity detachedEntity = dataContext.
//                CreateDetachedCopy(entity, fetchStrategy);

//            return detachedEntity;
//        }

//        public virtual TEntity AddNew(TEntity entity)
//        {
//            if (entity == null)
//                throw new ArgumentNullException("entity");

//            TEntity attachedEntity = dataContext.AttachCopy(entity);
//            dataContext.SaveChanges();
//            TEntity detachedEntity = dataContext.
//                CreateDetachedCopy(attachedEntity, fetchStrategy);

//            return detachedEntity;
//        }

//        public virtual TEntity Update(TEntity entity)
//        {
//            if (entity == null)
//                throw new ArgumentNullException("entity");

//            TEntity attachedEntity = dataContext.AttachCopy(entity);
//            dataContext.SaveChanges();
//            TEntity detachedEntity = dataContext.
//                            CreateDetachedCopy(attachedEntity, fetchStrategy);

//            return detachedEntity;
//        }

//        public virtual void Delete(TEntity entity)
//        {
//            if (entity == null)
//                throw new ArgumentNullException("entity");

//            TEntity attachedEntity = dataContext.AttachCopy(entity);
//            dataContext.Delete(attachedEntity);
//            dataContext.SaveChanges();
//        }
//    }
//}