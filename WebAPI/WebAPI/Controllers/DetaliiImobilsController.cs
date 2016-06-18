using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BusinessEntities.Entities;
using BusinessServices.Interfaces;

namespace WebAPI.Controllers
{
    public class DetaliiImobilsController : ApiController
    {
        private readonly IDetaliiImobilService _detaliiImobilService;

        public DetaliiImobilsController(IDetaliiImobilService detaliiImobilService)
        {
            _detaliiImobilService = detaliiImobilService;
        }
        
        // GET: api/detaliiImobils
        public HttpResponseMessage GetdetaliiImobils()
        {
            var detaliiImobile = _detaliiImobilService.GetAllDetails();
            if (detaliiImobile != null)
            {
                var detaliiImobilEntities = detaliiImobile as List<DetaliiImobilEntity> ?? detaliiImobile.ToList();
                if (detaliiImobilEntities.Any())
                    return Request.CreateResponse(HttpStatusCode.OK, detaliiImobilEntities);
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "detaliiImobil not found");
        }

        //// GET: api/detaliiImobils/5
        public HttpResponseMessage GetGetdetaliiImobil(int id)
        {
            var detaliiImobil = _detaliiImobilService.GetdetailsById(id);
            if (detaliiImobil != null)
                return Request.CreateResponse(HttpStatusCode.OK, detaliiImobil);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No product found for this id");
        }

        // POST api/detaliiImobils
        public int Post([FromBody] DetaliiImobilEntity detaliiImobilEntity)
        {
            return _detaliiImobilService.CreateDetaliiImobil(detaliiImobilEntity);
        }

        // PUT api/detaliiImobils/5
        public bool Put(int id, [FromBody] DetaliiImobilEntity detaliiImobilEntity)
        {
            if (id > 0)
            {
                return _detaliiImobilService.UpdateDetaliiImobil(id, detaliiImobilEntity);
            }
            return false;
        }

        // DELETE api/DetaliiImobil/5
        public bool Delete(int id)
        {
            if (id > 0)
                return _detaliiImobilService.DeleteDetaliiImobil(id);
            return false;
        }
    }
}
