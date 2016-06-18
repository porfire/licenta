using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices.Interfaces
{
    public interface ILoginService:IDisposable
    {
        bool SaveChanges();
        IPersonService Persons { get; }
        IUserRolService UserRols { get; }
    }
}
