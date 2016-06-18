//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Linq.Expressions;
//using WebAPI.Model;

//namespace WebAPI.DAL.Interfaces
//{
//    public interface IGenricRepository<T> where T:BaseEntity
//    {
//        IEnumerable<T> GetAll();
//        IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);

//        IEnumerable<T> Get(
//            Expression<Func<T, bool>> filter = null,
//            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
//            string includeProperties = "");

//        T GetById(object id);
//        void Insert(T entity);
//        T Add(T entity);
//        void Delete(object id);
//        void Delete(T entityToDelete);
//        void Edit(T entity);
//        void Update(T entityToUpadate);
//        void Save();
//    }
//}
