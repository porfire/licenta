using System.Collections.Generic;
using BusinessEntities.Entities;

namespace BusinessServices.Interfaces
{
    public interface ILocalitateService
    {
        LocalitateEntity GetLocalitateById(int localitateId);
        IEnumerable< LocalitateEntity> GetAllLocalitates();
        int CreateLocalitate( LocalitateEntity  localitateEntity);
        bool UpdateLocalitate(int localitateId,  LocalitateEntity  localitateEntity);
        bool DeleteLocalitate(int localitateId);
    }
}
