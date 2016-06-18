//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;

//namespace WebAPI.Model.DTOs
//{
//    [Table("Agenti")]
//    public class AgentiDto : AuditableEntity<long>
//    {
//        [Required]
//        [MaxLength(50)]
//        public string Nume_agent { get; set; }

//        [Required]
//        [MaxLength(20)]
//        public string Telefon_agent { get; set; }

//        [Required]
//        [MaxLength(20)]
//        public string Telefon_edil { get; set; }

//        [Required]
//        [MaxLength(20)]
//        public string Email_agent { get; set; }

//        [Required]
//        [MaxLength(100)]
//        public string Descriere_agent { get; set; }

//        [Required]
//        [MaxLength(20)]
//        public string Link_facebook { get; set; }

//        [Display(Name = "Oferta")]
//        public int OfertaId { get; set; }

//        [ForeignKey("OfertaId")]
//        public virtual OfertaDto Oferta { get; set; }

//        public virtual AgentieDto Agentie { get; set; }
//        public virtual PersonDto Person { get; set; }
//    }
//}
