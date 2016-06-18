using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.WebPages;
using BusinessEntities.Entities;
using BusinessServices.Interfaces;
using BusinessServices.Services;
using WebAPI.ErrorHelper;

namespace WebAPI.Controllers
{
    public class OfertasController : ApiController
    {
        private readonly IOfertaService _ofertaService;

        public OfertasController()
        {
            _ofertaService = new OfertaService();
        }
        // GET: api/ofertas
        public HttpResponseMessage GetAll()
        {
            var oferte = _ofertaService.GetAllOfertas();
            if (oferte != null)
            {
                var ofertaEntities = oferte as List<OfertaEntity> ?? oferte.ToList();
                if (ofertaEntities.Any())
                    return Request.CreateResponse(HttpStatusCode.OK, ofertaEntities);
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "oferta not found");
        }

        //// GET: api/ofertas/5
        public HttpResponseMessage Get(int id)
        {
            var oferta = _ofertaService.GetOfertaById(id);
            if (oferta != null)
                return Request.CreateResponse(HttpStatusCode.OK, oferta);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No product found for this id");
        }

        // POST api/ofertas
        [ResponseType(typeof(OfertaEntity))]
        public IHttpActionResult Post([FromBody] OfertaEntity ofertaEntity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _ofertaService.CreateOferta(ofertaEntity);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, ofertaEntity);
            response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = ofertaEntity.id_oferta }));

          
           return StatusCode(HttpStatusCode.Conflict);

        }

        // PUT api/ofertas/5
       
        public bool Put(int id, [FromBody] OfertaEntity ofertaEntity)
        {
            if (id > 0)
            {
                return _ofertaService.UpdateOferta(id, ofertaEntity);
            }
            return false;
        }

       
        // DELETE api/People/5
        public bool Delete(int id)
        {
            if (id != null && id > 0)
            {
                var isSuccess = _ofertaService.DeleteOferta(id);
                if (isSuccess)
                {
                    return isSuccess;
                }
                throw new ApiDataException(1002, "oferta already deleted or not exist in sistem ",
                    HttpStatusCode.NoContent);
            }
            throw new ApiException()
            {
                ErrorCode = (int) HttpStatusCode.BadRequest,
                ErrorDescription = "Bad request ..."
            };
        }
    }
}