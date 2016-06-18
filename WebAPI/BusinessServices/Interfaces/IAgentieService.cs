using System.Collections.Generic;
using BusinessEntities.Entities;

namespace BusinessServices.Interfaces
{
   public interface IAgentieService
    {
        AgentieEntity GetAgencyById(int agencyId);
        IEnumerable<AgentieEntity> GetAllAgencies();
        int CreateAgency(AgentieEntity agencyEntity);
        bool UpdateAgency(int agencyId, AgentieEntity agencyEntity);
        bool DeleteAgency(int agencyId);
    }
}

