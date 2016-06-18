//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;

//namespace WebAPI.Model.DTOs
//{

//    [Table("DetaliiImobil")]
//    public class DetaliiImobilDto : AuditableEntity<long>
//    {
//        [Required]
//        [MaxLength(200)]
//        public string Detalii_suplimentare_ro { get; set; }

//        [Required]
//        [MaxLength(200)]
//        public string Detalii_suplimentare_en { get; set; }
        
//        [Required]
//        [MaxLength(200)]
//        public string Detalii_suplimentare_fr { get; set; }
        
//        [Required]
//        [MaxLength(200)]
//        public string Detalii_finale_ro { get; set; }
        
//        [Required]
//        [MaxLength(200)]
//        public string Detalii_finale_en { get; set; }

//        [Required]
//        [MaxLength(200)]
//        public string Detalii_finale_fr { get; set; }

//        [Required]
//        [MaxLength(50)]
//        public string Publica { get; set; }

//        public virtual OfertaDto Oferta { get; set; }
//    }
//}
