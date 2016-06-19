using System;
using System.Collections.Generic;
using DataModel;

//using DataModel;

namespace BusinessEntities.Entities
{
    public class OfertaEntity
    {
        //Primary key
        public int id_oferta { get; set; }
        public int id_localitate { get; set; }
        public int id_cartier { get; set; }
        public int id_agent { get; set; }
        public int id_imobil { get; set; }
        public string tip_contact { get; set; }
        public int nr_camere { get; set; }
        public int suprafata_utila { get; set; }
        public int pret { get; set; }
        public string moneda { get; set; }
        public string compartimentare { get; set; }
        public string confort { get; set; }
        public string etaj { get; set; }
        public int nr_bucatarii { get; set; }
        public int nr_bai { get; set; }
        public int nr_balcoane { get; set; }
        public string an_constructie { get; set; }
        public string loc_parcare { get; set; }
        public string utilitati_gen { get; set; }
        public string sistem_incalzire { get; set; }
        public string climatizare { get; set; }
        public string internet { get; set; }
        public string stare_interior { get; set; }
        public string ferestre { get; set; }
        public string podele { get; set; }
        public string usa_intrare { get; set; }
        public string mobilat { get; set; }
        public string tip_oferta { get; set; }
        public Nullable<double> latitudine { get; set; }
        public Nullable<double> longitudine { get; set; }
       

        public virtual Agenti Agenti { get; set; }
        public virtual Cartier Cartier { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetaliiImobil> DetaliiImobils { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FotoImobil> FotoImobils { get; set; }
        public virtual Imobil Imobil { get; set; }
        public virtual Localitate Localitate { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VideoImobil> VideoImobils { get; set; }

        //public virtual Agenti Agenti { get; set; }
        //public virtual Cartier Cartier { get; set; }
        //public virtual ICollection<DetaliiImobil> DetaliiImobils { get; set; }
        //public virtual ICollection<FotoImobil> FotoImobils { get; set; }
        //public virtual Imobil Imobil { get; set; }
        //public virtual Localitate Localitate { get; set; }
        //public virtual ICollection<VideoImobil> VideoImobils { get; set; }
    }
}

