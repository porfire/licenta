﻿using System.Collections.Generic;

namespace BusinessEntity.Entities
{
    public class LocalitateEntity
    {
        public int localitateID { get; set; }
        public string denumire_localitate { get; set; }
        public string longitudine { get; set; }
        public string latitudine { get; set; }

        public virtual ICollection<Oferta> Ofertas { get; set; }
    }
}