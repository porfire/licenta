//using System;
//using System.Collections.Generic;
//using System.Data.Entity;
//using System.Linq;
//using System.Web;
//using WebAPI.DAL.Interfaces;
//using WebAPI.Model;

//namespace WebAPI.DAL
//{
//    public class PersonRepoitory : GenericRepositoy<Person>, IPersonReposiory
//    {
//        private DbContext _entity;
//        public PersonRepoitory(DbContext context) : base(context)
//        {
//        }

//        public Person Add(Person entity)
//        {
            
//            throw new NotImplementedException();
//        }

//        public override IEnumerable<Person> GetAll()
//        {
//            return _entity.Set<Person>().Include(x => x.Agent).AsEnumerable();
//        }

//        public Person GetById(int ID)
//        {
//            return _dbSet.Include(x => x.Agent).Where(x => x.Id == ID).FirstOrDefault();
//        }
//    }
//}