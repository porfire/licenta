using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using BusinessEntities.Entities;
using BusinessServices.Interfaces;
using BusinessServices.Services;

namespace WebAPI.Controllers
{
    public class AgentiesController : ApiController
    {
        private readonly IAgentieService _agentieService;

        public AgentiesController()
        {
            _agentieService = new AgentieService();
        }

        // GET: api/agenties
        public HttpResponseMessage GetAll()
        {
            var agentiee = _agentieService.GetAllAgencies();
            if (agentiee != null)
            {
                var agentieEntities = agentiee as List<AgentieEntity> ?? agentiee.ToList();
                if (agentieEntities.Any())
                    return Request.CreateResponse(HttpStatusCode.OK, agentieEntities);
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "agentie not found");
        }

        //// GET: api/agenties/5
        public HttpResponseMessage Get(int id)
        {
            var agentie = _agentieService.GetAgencyById(id);
            if (agentie != null)
                return Request.CreateResponse(HttpStatusCode.OK, agentie);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No AGENCY found for this id");
        }

        // POST api/agenties
        [ResponseType(typeof(OfertaEntity))]
        public IHttpActionResult Post([FromBody] AgentieEntity agentieEntity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _agentieService.CreateAgency(agentieEntity);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, agentieEntity);
            response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = agentieEntity.agentieId }));


            return StatusCode(HttpStatusCode.Conflict);
        }

        // PUT api/agenties/put/5
        public bool Put(int id, [FromBody] AgentieEntity agentieEntity)
        {
            if (id > 0)
            {
                return _agentieService.UpdateAgency(id, agentieEntity);
            }
            return false;
        }

        // DELETE api/People/delete/5
        public bool Delete(int id)
        {
            if (id > 0)
                return _agentieService.DeleteAgency(id);
            return false;
        }
    }
}