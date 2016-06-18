using System.Collections.Generic;
using DataModel;


namespace BusinessEntities.Entities
{
    public class LocalitateEntity
    {

        public int localitateID { get; set; }
        public string denumire_localitate { get; set; }
        public string longitudine { get; set; }
        public string latitudine { get; set; }

        public virtual ICollection<Oferta> Ofertas { get; set; }
    }
}