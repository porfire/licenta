using System.Threading;
using System.Web.Http.Controllers;
using BusinessServices.Interfaces;

namespace WebAPI.Filters
{
    public class ApiAuthenticationFilter : GenericAuthenticationFilter
    {
        public ApiAuthenticationFilter()
        {
        }

        public ApiAuthenticationFilter(bool isActive) : base(isActive)
        {
        }

        /// <summary>
        /// Protected overriden method for authorizing user
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="actionContext"></param>
        /// <returns></returns>
        protected override bool OnAuthorizeUser(string username, string password, HttpActionContext actionContext)
        {
            var provider = actionContext.ControllerContext.Configuration
                               .DependencyResolver.GetService(typeof(IUserService)) as IUserService;
            if (provider != null)
            {
                var userId = provider.Authenticate(username, password);
                if (userId > 0)
                {
                    var basicAuthenticationIdentity = Thread.CurrentPrincipal.Identity as BasicAuthenticationIdentity;
                    if (basicAuthenticationIdentity != null)
                        basicAuthenticationIdentity.PersonId = userId;
                    return true;
                }
            }
            return false;
        }
    }
}