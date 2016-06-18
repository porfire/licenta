using System.Collections.Generic;

namespace BusinessEntity.Entities
{
    public class CartierEntity
    {
        public int id_cartier { get; set; }
        public string denumire_cartier { get; set; }
        public string latitudine_longitudine { get; set; }
        public string zoom { get; set; }

        public virtual ICollection<Oferta> Ofertas { get; set; }
    }
}

