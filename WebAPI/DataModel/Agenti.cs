//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class Agenti
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Agenti()
        {
            this.Ofertas = new HashSet<Oferta>();
        }
    
        public int agentID { get; set; }
        public int orasID { get; set; }
        public int departamentID { get; set; }
        public int persoanaID { get; set; }
        public int functieID { get; set; }
        public int agentieID { get; set; }
        public string nume_agent { get; set; }
        public string telefon_agent { get; set; }
        public string telefon_edil { get; set; }
        public string email_agent { get; set; }
        public string descriere_agent { get; set; }
        public string link_facebook { get; set; }
        public string data_angaj { get; set; }
        public string sex { get; set; }
        public string CNP { get; set; }
    
        public virtual Agentie Agentie { get; set; }
        public virtual Person Person { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Oferta> Ofertas { get; set; }
    }
}