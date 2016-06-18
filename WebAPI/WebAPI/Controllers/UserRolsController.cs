using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BusinessEntities.Entities;
using BusinessServices.Interfaces;
using BusinessServices.Services;

namespace WebAPI.Controllers
{
    public class UserRolsController : ApiController
    {
        private readonly IUserRolService _userRolService;

        public UserRolsController()
        {
            _userRolService=new UserRolService();
        }
        // GET: api/userRols
        public HttpResponseMessage GetuserRols()
        {
            var userRole = _userRolService.GetAllUserRols();
            if (userRole != null)
            {
                var userRolEntities = userRole as List<UserRolEntity> ?? userRole.ToList();
                if (userRolEntities.Any())
                    return Request.CreateResponse(HttpStatusCode.OK, userRolEntities);
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "userRol not found");
        }

        //// GET: api/userRols/5
        public HttpResponseMessage GetGetuserRol(int id)
        {
            var userRol = _userRolService.GetUserRolById(id);
            if (userRol != null)
                return Request.CreateResponse(HttpStatusCode.OK, userRol);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No product found for this id");
        }

        // POST api/userRols

            /// <summary>
            /// trebuie verificata daca sa mearga si in db
            /// nu mere ca lumea 
            /// </summary>
            /// <param name="userRolEntity"></param>
            /// <returns></returns>
        public int Post([FromBody] UserRolEntity userRolEntity)
        {
            return _userRolService.CreateUserRol(userRolEntity);
        }

        // PUT api/userRols/5
        public bool Put(int id, [FromBody] UserRolEntity userRolEntity)
        {
            if (id > 0)
            {
                return _userRolService.UpdateUserRol(id, userRolEntity);
            }
            return false;
        }

        // DELETE api/People/5
        public bool Delete(int id)
        {
            if (id > 0)
                return _userRolService.DeleteUserRol(id);
            return false;
        }
    }
}
