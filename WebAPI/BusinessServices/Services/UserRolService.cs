using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BusinessEntities.Entities;
using BusinessServices.Interfaces;
using DataModel;
using DataModel.UnitOfWork;

namespace BusinessServices.Services
{
    public class UserRolService : IUserRolService
    {
        public readonly UnitOfWork _UnitOfWork;

        public UserRolService()
        {
            _UnitOfWork = new UnitOfWork();
        }

        public UserRolEntity GetUserRolById(int userRolId)
        {
            var userRol = _UnitOfWork.UserRolRepository.GetByID(userRolId);
            if (userRol != null)
            {
                Mapper.CreateMap<UserRol, UserRolEntity>();
                var userRolModel = Mapper.Map<UserRol, UserRolEntity>(userRol);
                return userRolModel;
            }
            return null;
        }

        public IEnumerable<UserRolEntity> GetAllUserRols()
        {
            var userRols = _UnitOfWork.UserRolRepository.GetAll().ToList();
            if (userRols.Any())
            {
                Mapper.CreateMap<UserRol, UserRolEntity>();
                var userRolModel = Mapper.Map<List<UserRol>, List<UserRolEntity>>(userRols);
                return userRolModel;
            }
            return null;
        }

        public int CreateUserRol(UserRolEntity userRolEntity)
        {
            var userRol = new UserRol();
            {
                userRol.Descriere = userRolEntity.Descriere;
                userRol.RolName = userRolEntity.RolName;
            }
            _UnitOfWork.UserRolRepository.Insert(userRol);
            _UnitOfWork.Save();
             return userRol.RolId;
        }

        public bool UpdateUserRol(int userRolId, UserRolEntity userRolEntity)
        {
            var success = false;
            if (userRolEntity != null)
            {
                    var userRol = _UnitOfWork.UserRolRepository.GetByID(userRolId);

                    if (userRol != null)
                    {
                        userRol.Descriere = userRolEntity.Descriere;
                        userRol.RolName = userRolEntity.RolName;
                        _UnitOfWork.UserRolRepository.Update(userRol);
                        _UnitOfWork.Save();
                        success = true;
                    }
                }
            return success;
        }

        public bool DeleteUserRol(int userRolId)
        {

            var success = false;
            if (userRolId > 0)
            {
                var userRol = _UnitOfWork.UserRolRepository.GetByID(userRolId);
                if (userRol != null)
                {
                    _UnitOfWork.UserRolRepository.Delete(userRol);
                    _UnitOfWork.Save();
                    success = true;
                }
            }
            return success;
        }
    }
}
