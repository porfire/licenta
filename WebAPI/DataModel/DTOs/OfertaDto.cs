//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;

//namespace WebAPI.Model.DTOs
//{
//    [Table("Oferta")]
//    public class OfertaDto : AuditableEntity<long>
//    {
//        [Required]
//        [MaxLength(50)]
//        public string Tip_contact { get; set; }

//        [Required]
//        [MaxLength(10)]
//        public int Nr_camere { get; set; }

//        [Required]
//        [MaxLength(50)]
//        public int Suprafata_utila { get; set; }

//        [Required]
//        [MaxLength(50)]
//        public int Pret { get; set; }

//        [Required]
//        [MaxLength(50)]
//        public int Moneda { get; set; }

//        [Required]
//        [MaxLength(50)]
//        public string Compartimentare { get; set; }

//        [Required]
//        [MaxLength(50)]
//        public string Confort { get; set; }

//        [Required]
//        [MaxLength(50)]
//        public string Etaj { get; set; }

//        [Required]
//        [MaxLength(50)]
//        public int Nr_bucatarii { get; set; }

//        [Required]
//        [MaxLength(50)]
//        public int Nr_bai { get; set; }

//        [Required]
//        [MaxLength(50)]
//        public int Nr_balcoane { get; set; }

//        [Required]
//        [MaxLength(50)]
//        public string An_constructie { get; set; }

//        [Required]
//        [MaxLength(50)]
//        public string Loc_parcare { get; set; }

//        [Required]
//        [MaxLength(50)]
//        public string Utilitati_gen { get; set; }

//        [Required]
//        [MaxLength(50)]
//        public string Sistem_incalzire { get; set; }

//        [Required]
//        [MaxLength(50)]
//        public string Climatizare { get; set; }

//        [Required]
//        [MaxLength(50)]
//        public string Internet { get; set; }

//        [Required]
//        [MaxLength(50)]
//        public string Stare_interior { get; set; }

//        [Required]
//        [MaxLength(50)]
//        public string Ferestre { get; set; }

//        [Required]
//        [MaxLength(50)]
//        public string Podele { get; set; }

//        [Required]
//        [MaxLength(50)]
//        public string Usa_intrare { get; set; }

//        [Required]
//        [MaxLength(50)]
//        public string Mobilat { get; set; }


//        [Display(Name = "DetaliiImobil")]
//        public int DetaliiImobilId { get; set; }

//        [ForeignKey("DetaliiImobilId")]
//        public virtual DetaliiImobilDto DetaliiImobil { get; set; }


//        [Display(Name = "FotoImobil")]
//        public int FotoImobilId { get; set; }

//        [ForeignKey("FotoImobilId")]
//        public virtual FotoImobilDto FotoImobil { get; set; }

//        [Display(Name = "VideoImobil")]
//        public int VideoImobilId { get; set; }

//        [ForeignKey("VideoImobilId")]
//        public virtual VideoImobilDto VideoImobil { get; set; }

//        public virtual Agenti Agenti { get; set; }
//        public virtual CartierDto Cartier { get; set; }

//        public virtual ImobilDto Imobil { get; set; }
//        public virtual LocalitateDto Localitate { get; set; }

//    }
//}
