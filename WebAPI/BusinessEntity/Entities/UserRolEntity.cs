using System.Collections.Generic;

namespace BusinessEntity.Entities
{
    public class UserRolEntity
    {
        public int RolId { get; set; }
        public string RolName { get; set; }
        public string Descriere { get; set; }

        public virtual ICollection<Person> Persons { get; set; }
    }
}

