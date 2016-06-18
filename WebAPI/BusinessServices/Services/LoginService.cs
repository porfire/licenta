using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessServices.Interfaces;
using DataModel;

namespace BusinessServices.Services
{
    public class LoginService : ILoginService
    {
        private IPersonService m_acountService;
        private IUserRolService m_userRolService;

        private readonly AgentieImobiliaraEntities m_context;

        public LoginService()
        {
            m_context =new AgentieImobiliaraEntities();
        }
        public void Dispose()
        {
            m_context.Dispose();
        }

        public bool SaveChanges()
        {
            if (m_context.SaveChanges() > 0)
                return true;

            return false;
        }

        public IPersonService Persons { get; }
        public IUserRolService UserRols { get; }
    }
}