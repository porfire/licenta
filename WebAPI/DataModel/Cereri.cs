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
    
    public partial class Cereri
    {
        public int id_cerere { get; set; }
        public int id_oferta { get; set; }
        public int id_client { get; set; }
        public Nullable<int> nr_camere { get; set; }
        public string zona { get; set; }
    }
}