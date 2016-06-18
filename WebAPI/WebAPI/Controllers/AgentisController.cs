using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using AttributeRouting.Web.Http;
using BusinessEntities.Entities;
using BusinessServices.Interfaces;
using BusinessServices.Services;
using WebAPI.ActionFilters;
using WebAPI.ErrorHelper;

namespace WebAPI.Controllers
{
    //[AuthorizationRequired]
    //[RoutePrefix("v1/Agentis/Agenti")]
    public class AgentisController : ApiController
    {
        private readonly IAgentiService _agentService;

        public AgentisController()
        {
            _agentService = new AgentiService();
        }

        // GET: api/Agentis
        public HttpResponseMessage GetAllAgenti()
        {
            var agents = _agentService.GetAllAgents();
            var agentEntities = agents as List<AgentiEntity> ?? agents.ToList();
            if (agentEntities.Any())
                return Request.CreateResponse(HttpStatusCode.OK, agentEntities);
            throw new ApiDataException(1000, "Agent not found not found", HttpStatusCode.NotFound);
        } 
        
        // GET: api/Agentis
        public HttpResponseMessage GetAll()
        {
            var agents = _agentService.GetAllAgents();
            if (agents != null)
            {
                var agentEntities = agents as List<AgentiEntity> ?? agents.ToList();
                if (agentEntities.Any())
                    return Request.CreateResponse(HttpStatusCode.OK, agentEntities);
            }
            throw new ApiDataException(1000, "Agent not found not found", HttpStatusCode.NotFound);
        }


        // GET: api/Agentis/5
        public HttpResponseMessage Get(int id)
        {
            var agent = _agentService.GetAgentiById(id);
            if (agent != null)
                    return Request.CreateResponse(HttpStatusCode.OK, agent);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No product found for this id");
            
        }

        [ResponseType(typeof(OfertaEntity))]
        public IHttpActionResult Post([FromBody] AgentiEntity agentiEntity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _agentService.CreateAgent(agentiEntity);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, agentiEntity);

            response.Headers.Location = new Uri(Url.Link("DefaultApi", new {id = agentiEntity.agentID}));
            return StatusCode(HttpStatusCode.Conflict);

        }

        // PUT api/Agentis/5
        public bool Put(int id, [FromBody] AgentiEntity agentiEntity)
        {
            if (id > 0)
            {
                return _agentService.UpdateAgent(id, agentiEntity);
            }
            return false;
        }

        // DELETE api/People/5
        public bool Delete(int id)
        {
            if (id != null && id > 0)
            {
                var isSuccess = _agentService.DeleteAgent(id);
                if (isSuccess)
                {
                    return isSuccess;
                }
                throw new ApiDataException(1002, "agent already deleted or not exist in sistem ",
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
