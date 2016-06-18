using System.Collections.Generic;

namespace BusinessEntity.Entities
{
    public class ImobilEntity
    {
        public int id_imobil { get; set; }
        public string denumire_imobil { get; set; }
        public string comentariu { get; set; }

        public virtual ICollection<Oferta> Ofertas { get; set; }
    }
}

