
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BusinessEntities.Entities;
using BusinessServices.Interfaces;
using BusinessServices.Services;
using WebAPI.ErrorHelper;

namespace WebAPI.Controllers
{
    public class LocalitatesController : ApiController
    {
        private readonly ILocalitateService _localitateService;

        public LocalitatesController()
        {
            _localitateService = new LocalitateService();
        }

        // GET: api/localitates
        public HttpResponseMessage GetAllLocalitati()
        {
            var localitatee = _localitateService.GetAllLocalitates();
            if (localitatee != null)
            {
                var localitateEntities = localitatee as List<LocalitateEntity> ?? localitatee.ToList();
                if (localitateEntities.Any())
                    return Request.CreateResponse(HttpStatusCode.OK, localitateEntities);
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "localitate not found");
        }

        //// GET: api/localitates/5
        public HttpResponseMessage Getlocalitate(int id)
        {
            var localitate = _localitateService.GetLocalitateById(id);
            if (localitate != null)
                return Request.CreateResponse(HttpStatusCode.OK, localitate);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No product found for this id");
        }

        // POST api/localitates
        public int Post([FromBody]  LocalitateEntity localitateEntity)
        {
            return _localitateService.CreateLocalitate(localitateEntity);
        }

        // PUT api/localitates/5
        public bool Put(int id, [FromBody] LocalitateEntity localitateEntity)
        {
            if (id > 0)
            {
                return _localitateService.UpdateLocalitate(id, localitateEntity);
            }
            return false;
        }

        // DELETE api/People/5
        public bool Delete(int id)
        {
            if (id != null && id > 0)
            {
                var isSuccess = _localitateService.DeleteLocalitate(id);
                if (isSuccess)
                {
                    return isSuccess;
                }
                throw new ApiDataException(1002, "agent already deleted or not exist in sistem ",
                    HttpStatusCode.NoContent);
            }
            throw new ApiException()
            {
                ErrorCode = (int)HttpStatusCode.BadRequest,
                ErrorDescription = "Bad request ..."
            };
        }
    }
}