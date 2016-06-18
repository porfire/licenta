

using DataModel;

namespace BusinessEntities.Entities
{
    public class DetaliiImobilEntity
    {
        public int detaliiID { get; set; }
        public int ofertaID { get; set; }
        public string detalii_suplimentare_ro { get; set; }
        public string detalii_suplimentare_en { get; set; }
        public string detalii_suplimentare_fr { get; set; }
        public string detalii_finale_ro { get; set; }
        public string detalii_finale_en { get; set; }
        public string detalii_finale_fr { get; set; }
        public string publica { get; set; }

        public virtual Oferta Oferta { get; set; }
    }
}
