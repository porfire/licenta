using System.Collections.Generic;
using DataModel;


namespace BusinessEntities.Entities
{
    public class AgentieEntity
    {
        public int agentieId { get; set; }
        public string numeAgentie { get; set; }
        public string descriere { get; set; }

       public virtual ICollection<Agenti> Agentis { get; set; }
    }
}

