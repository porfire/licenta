using System.Data.Entity;

namespace DataModel.Validators
{
    class AccountValidator
    {
        private readonly IDbSet<Person> m_account;

        public AccountValidator(IDbSet<Person> accounts)
        {
            m_account = accounts;
        }

    }
}
