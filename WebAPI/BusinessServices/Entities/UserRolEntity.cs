using System.Collections.Generic;
using DataModel;

namespace BusinessEntities.Entities
{
    public class UserRolEntity
    {
        public int RolId { get; set; }
        public string RolName { get; set; }
        public string Descriere { get; set; }

        public virtual ICollection<Person> Persons { get; set; }
    }
}

