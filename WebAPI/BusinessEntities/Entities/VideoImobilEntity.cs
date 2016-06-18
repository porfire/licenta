//using DataModel;

using DataModel;

namespace BusinessEntities.Entities
{
    public class VideoImobilEntity
    {
        public int videoID { get; set; }
        public int ofertaID { get; set; }
        public string VideoName { get; set; }
        public string VideoDescription { get; set; }

        public virtual Oferta Oferta { get; set; }
    }
}
