//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;

//namespace WebAPI.Model.DTOs
//{
//    [Table("UserRol")]
//    public class LocalitateDto : AuditableEntity<long>
//    {
//        [Required]
//        [MaxLength(50)]
//        public string Denumire_localitate { get; set; }

//        [Required]
//        [MaxLength(50)]
//        public string Longitudine { get; set; }

//        [Required]
//        [MaxLength(50)]
//        public string Latitudine { get; set; }

//        [Display(Name = "Oferta")]
//        public int OfertaId { get; set; }

//        [ForeignKey("OfertaId")]
//        public virtual OfertaDto Oferta { get; set; }
//    }
//}
