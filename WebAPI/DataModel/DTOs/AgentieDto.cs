//using System.Collections.Generic;

//namespace WebAPI.Model.DTOs
//{
//    public class AgentieDto
//    {
//        public int agentID { get; set; }
//        public int orasID { get; set; }
//        public int departamentID { get; set; }
//        public int persoanaID { get; set; }
//        public int functieID { get; set; }
//        public int agentieID { get; set; }
//        public string nume_agent { get; set; }
//        public string telefon_agent { get; set; }
//        public string telefon_edil { get; set; }
//        public string email_agent { get; set; }
//        public string descriere_agent { get; set; }
//        public string link_facebook { get; set; }

//        public virtual Agentie Agentie { get; set; }
//        public virtual Person Person { get; set; }
//        public virtual ICollection<Oferta> Ofertas { get; set; }
//    }
//}


////[Table("Agentie")]
////public partial class AgentieDto : AuditableEntity<long>
////{
//    //    [Required]
//    //    [MaxLength(50)]
//    //    public string NumeAgentie { get; set; }

////    [Required]
////    [MaxLength(50)]
////    public string Descriere { get; set; }

////    [Display(Name = "Agent")]
////    public int AgentId { get; set; }

////    [ForeignKey("AgentId")]
////    public virtual Agenti Agent { get; set; }
////}