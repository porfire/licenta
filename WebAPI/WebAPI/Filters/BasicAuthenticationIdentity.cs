using System.Security.Principal;

namespace WebAPI.Filters
{
    public class BasicAuthenticationIdentity:GenericIdentity
    {
        /// <summary>
        /// Get/Set for password
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Get/Set for username
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// Get/Set for PersonId
        /// </summary>
        public int PersonId { get; set; }

        public BasicAuthenticationIdentity(string userName, string password):base(userName,"Basic")
        {
            UserName = userName;
            Password = password;
        }
    }
}