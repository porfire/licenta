namespace BusinessEntities.Entities
{
    public class ImagesOfertaEntity
    {
        public string NumeFoto { get; set; }
        public string DescriereFoto { get; set; }
        public int ofertaID { get; set; }
        public byte[] img { get; set; }
    }
}
