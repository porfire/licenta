using System.Collections.Generic;
using DataModel;

namespace BusinessEntities.Entities
{
    public class PersonEntity
    {
        public int personID { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string telefon { get; set; }
        public string nume { get; set; }
        public string prenume { get; set; }
        public string adresa { get; set; }
        public int varsta { get; set; }

        public virtual ICollection<Agenti> Agentis { get; set; }
        public virtual ICollection<UserRol> UserRols { get; set; }
    }
}