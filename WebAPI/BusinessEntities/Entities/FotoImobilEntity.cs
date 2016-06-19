

using DataModel;

namespace BusinessEntities.Entities
{
    public class FotoImobilEntity
    {
        public int fotoID { get; set; }
        public string NumeFoto { get; set; }
        public string DescriereFoto { get; set; }
        public int ofertaID { get; set; }
        public string img_path { get; set; }


        public virtual Oferta Oferta { get; set; }
   }
}

