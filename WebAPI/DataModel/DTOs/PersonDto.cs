//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;

//namespace WebAPI.Model.DTOs
//{
//    //[Table("Persons")]
//    public class PersonDto/* : AuditableEntity<long>*/
//    {
//        [Required]
//        [MaxLength(50)]
//        public string UserName { get; set; }

//        [Required]
//        [MaxLength(20)]
//        public string Password { get; set; }

//        [Required]
//        [MaxLength(100)]
//        public string Email { get; set; }

//        [Required]
//        [MaxLength(50)]
//        public string Telefon { get; set; }

//        [Required]
//        [MaxLength(50)]
//        public string Nume { get; set; }

//        [Required]
//        [MaxLength(50)]
//        public string Prenume { get; set; }

//        [Required]
//        [MaxLength(100)]
//        public string Adresa { get; set; }

//        [Required]
//        public int Varsta { get; set; }

//        [Display(Name = "Agent")]
//        public int AgentId { get; set; }

//        [ForeignKey("AgentId")]
//        public virtual Agenti Agent { get; set; }
        
//        [Display(Name = "UserRol")]
//        public int UserRolId { get; set; }

//        [ForeignKey("UserRolId")]
//        public virtual UserRolDto UserRol { get; set; }
//    }
//}
