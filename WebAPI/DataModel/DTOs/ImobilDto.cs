//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;

//namespace WebAPI.Model.DTOs
//{

//    [Table("Imobil")]
//    public class ImobilDto : AuditableEntity<long>
//   {
//        [Required]
//        [MaxLength(50)]
//        public string Denumire_imobil { get; set; }

//        [Required]
//        [MaxLength(200)]
//        public string Comentariu { get; set; }

//        [Display(Name = "Oferta")]
//        public int OfertaId { get; set; }

//        [ForeignKey("OfertaId")]
//        public virtual OfertaDto Oferta { get; set; }
//    }
//}
