using System.Data.Entity.Migrations.Model;
using BusinessServices.Interfaces;
using DataModel.UnitOfWork;

namespace BusinessServices.Services
{
   public class UserService:IUserService
   {
       private readonly UnitOfWork _unitOfWork;

       public UserService(UnitOfWork unitOfWork)
       {
           _unitOfWork = unitOfWork;
       }

        
        /// <summary>
        /// Public method to authenticate user by user name and password.
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        /// 
        public int Authenticate(string userName, string password)
        {
            var user = _unitOfWork.PersonRepository.Get(u => u.userName == userName && u.password == password);
            if (user != null && user.personID > 0 )
            {
                return user.personID;
            }
            return 0;
        }
    }
}
