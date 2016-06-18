using System.Collections.Generic;

namespace BusinessEntity.Entities
{
    public class AgentieEntity
    {
        public int agentieId { get; set; }
        public string numeAgentie { get; set; }
        public string descriere { get; set; }

        public virtual ICollection<Agenti> Agentis { get; set; }
    }
}

