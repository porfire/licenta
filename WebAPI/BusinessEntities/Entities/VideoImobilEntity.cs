//using DataModel;

using DataModel;

namespace BusinessEntities.Entities
{
    public class VideoImobilEntity
    {
        public int videoID { get; set; }
        public int ofertaID { get; set; }
        public string video_path { get; set; }
        public string videoDescription { get; set; }

        public virtual Oferta Oferta { get; set; }
    }
}
