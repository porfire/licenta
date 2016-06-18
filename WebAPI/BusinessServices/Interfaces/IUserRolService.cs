using System.Collections.Generic;
using BusinessEntities.Entities;

namespace BusinessServices.Interfaces
{
    public interface IUserRolService
    {
        UserRolEntity GetUserRolById(int userRolId);
        IEnumerable<UserRolEntity> GetAllUserRols();
        int CreateUserRol(UserRolEntity userRolEntity);
        bool UpdateUserRol(int userRolId, UserRolEntity userRolEntity);
        bool DeleteUserRol(int userRolId);
    }
}
