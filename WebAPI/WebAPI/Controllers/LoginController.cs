using System.Web.Http;
using System.Web.Mvc;
using BusinessServices.Interfaces;

namespace WebAPI.Controllers
{
    public class LoginController : Controller
    {
        private readonly IPersonService _personService;
        public LoginController()
        {
            
        }

        public LoginController(IPersonService personService)
        {
            _personService = personService;
        }

        // POST api/Account/Logout
        //[System.Web.Mvc.Route("Logout")]
        //public IHttpActionResult Logout()
        //{
        //    //Authentication.SignOut(CookieAuthenticationDefaults.AuthenticationType);
        //    //return Ok();
        //}
        //Get api/person



    }
}