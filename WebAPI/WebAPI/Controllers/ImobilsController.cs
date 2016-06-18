using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
//using AttributeRouting.Web.Http;
using BusinessEntities.Entities;
using BusinessServices.Interfaces;
using BusinessServices.Services;
using WebAPI.ActionFilters;
using WebAPI.ErrorHelper;

namespace WebAPI.Controllers
{

    //[AuthorizationRequired]
    [RoutePrefix("agentieimobiliara/Imobils/Imobil")]
    public class ImobilsController : ApiController
    {

        private readonly IImobilSerice _imobilService;

        public ImobilsController()
        {
            _imobilService = new ImobilService();
        }
        // GET: api/imobils
        //[GET("allimobils")]
        //[GET("all")]
        public HttpResponseMessage Getimobils()
        {
            var imobils = _imobilService.GetAllImobiles();
            if (imobils != null)
            {
                var imobilEntities = imobils as List<ImobilEntity> ?? imobils.ToList();
                if (imobilEntities.Any())
                    return Request.CreateResponse(HttpStatusCode.OK, imobilEntities);
            }
            throw new ApiDataException(1000, "imobil not found", HttpStatusCode.NotFound);
        }

        //// GET: api/imobils/5
        //[GET("imobilid/{id?}")]
        //[GET("particularimobil/{id?}")]
        // [GET("myimobil/{id:range(1, 3)}")]
        ////http://192.168.0.100:58938/agentieimobiliara/Imobils/GetGetimobil/1
        public HttpResponseMessage GetGetImobil(int id)
        {
            if (id != null)
            {
                var imobil = _imobilService.GetImobilById(id);
                if (imobil != null)
                    return Request.CreateResponse(HttpStatusCode.OK, imobil);
                throw new ApiDataException(1001, "No imobil found for this id.", HttpStatusCode.NotFound);
            }

            throw new ApiException()
            {
                ErrorCode = (int) HttpStatusCode.BadRequest,
                ErrorDescription = "Bad request .. "
            };
        }

        // POST api/imobils
        //[POST("Create")]
        //[POST("Register")]
        public int Post([FromBody] ImobilEntity imobilEntity)
        {
            return _imobilService.CreateImobil(imobilEntity);
        }

        // PUT api/imobils/5
        //[PUT("Update/imobilid/{id}")]
        //[PUT("Modify/imobiltid/{id}")]
        public bool Put(int id, [FromBody] ImobilEntity imobilEntity)
        {
            if (id > 0)
            {
                return _imobilService.UpdateImobil(id, imobilEntity);
            }
            return false;
        }

        //// DELETE api/People/5
        //[DELETE("remove/imobilid/{id}")]
        //[DELETE("clear/imobilid/{id}")]
        //[PUT("delete/imobilid/{id}")]
        public bool Delete(int id)
        {
            if (id != null && id > 0)
            {
                var isSuccess = _imobilService.DeleteImobil(id);
                if (isSuccess)
                {
                    return isSuccess;
                }
                throw new ApiDataException(1002, "Imobil is already deleted or not exist in system.", HttpStatusCode.NoContent);
            }
            throw new ApiException() { ErrorCode = (int)HttpStatusCode.BadRequest, ErrorDescription = "Bad Request..." };
        }
    }
}
