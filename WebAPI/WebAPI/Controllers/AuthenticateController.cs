using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BusinessServices.Interfaces;
using BusinessServices.Services;
using WebAPI.Filters;
//using AttributeRouting.Web.Http;

namespace WebAPI.Controllers
{
    [ApiAuthenticationFilter]
    public class AuthenticateController : ApiController
    {
        #region Private variable.

        private readonly ITokenService _tokenServices;

        #endregion

        #region Public Constructor

        /// <summary>
        /// Public constructor to initialize product service instance
        /// </summary>
        public AuthenticateController()
        {
            _tokenServices = new TokenService();
        }

        #endregion

        /// <summary>
        /// Authenticates user and returns token with expiry.
        /// </summary>
        /// <returns></returns>
        //[POST("login")]
        //[POST("authenticate")]
        //[POST("get/token")]
        public HttpResponseMessage Authenticate()
        {
            if (System.Threading.Thread.CurrentPrincipal != null && System.Threading.Thread.CurrentPrincipal.Identity.IsAuthenticated)
            {
                var basicAuthenticationIdentity = System.Threading.Thread.CurrentPrincipal.Identity as BasicAuthenticationIdentity;
                if (basicAuthenticationIdentity != null)
                {
                    var userId = basicAuthenticationIdentity.PersonId;
                    return GetAuthToken(userId);
                }
            }
            return null;
        }

        /// <summary>
        /// Returns auth token for the validated user.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>

        private HttpResponseMessage GetAuthToken(int userId)
        {
            var token = _tokenServices.GenerateToken(userId);
            var response = Request.CreateResponse(HttpStatusCode.OK, "Authorized");
            response.Headers.Add("Token",token.AuthToken);
            response.Headers.Add("TokenExpiry", ConfigurationManager.AppSettings["AuthTokenExpiry"]);
            response.Headers.Add("Access-Control-Expose-Headers","Token, TokenExpiry");
            return response;
        }
    }
}