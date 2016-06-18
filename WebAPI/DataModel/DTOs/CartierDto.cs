//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;

//namespace WebAPI.Model.DTOs
//{
//    [Table("Cartier")]
//    public class CartierDto : AuditableEntity<long>
//    {
//        [Required]
//        [MaxLength(50)]
//        public string Denumire_cartier { get; set; }

//        [Display(Name = "Oferta")]
//        public int OfertaId { get; set; }

//        [ForeignKey("OfertaId")]
//        public virtual OfertaDto Oferta { get; set; }
//    }
//}
