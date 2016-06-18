using System.Collections.Generic;
using BusinessEntities.Entities;

namespace BusinessServices.Interfaces
{
    public interface IAgentiService
    {
        AgentiEntity GetAgentiById(int agentId);
        IEnumerable<AgentiEntity> GetAllAgents();
        int CreateAgent(AgentiEntity agentEntity);
        bool UpdateAgent(int agentId, AgentiEntity agentEntity);
        bool DeleteAgent(int agentId);
    }
}
