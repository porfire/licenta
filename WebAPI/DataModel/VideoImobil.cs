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
    
    public partial class VideoImobil
    {
        public int videoID { get; set; }
        public int ofertaID { get; set; }
        public string video_path { get; set; }
        public string videoDescription { get; set; }
    
        public virtual Oferta Oferta { get; set; }
    }
}
