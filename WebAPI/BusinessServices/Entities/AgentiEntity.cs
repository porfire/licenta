using System.Collections.Generic;
using DataModel;

namespace BusinessEntities.Entities
{
    public class AgentiEntity
    {
        public int agentID { get; set; }
        public int orasID { get; set; }
        public int departamentID { get; set; }
        public int persoanaID { get; set; }
        public int functieID { get; set; }
        public int agentieID { get; set; }
        public string nume_agent { get; set; }
        public string telefon_agent { get; set; }
        public string telefon_edil { get; set; }
        public string email_agent { get; set; }
        public string descriere_agent { get; set; }
        public string link_facebook { get; set; }

        public virtual Agentie Agentie { get; set; }
        public virtual Person Person { get; set; }
        public virtual ICollection<Oferta> Ofertas { get; set; }
    }
}
