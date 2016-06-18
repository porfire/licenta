using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using DataModel;
using WebAPI.Repository;

namespace WebAPI.Controllers
{
    public abstract partial class
         OpenAccessBaseApiController<TEntity, TContext> : ApiController
         where TContext : AgentieImobiliaraEntities, new()
    {
        protected IOpenAccessBaseRepository<TEntity, TContext> repository;

        public virtual IQueryable<TEntity> Get()
        {
            var allEntities = repository.GetAll();

            return allEntities;
        }

        /// <summary>
        /// Creates a new entity based on the provided data
        /// </summary>
        /// <param name="entity">The new entity to be created</param>
        /// <returns>HTTP Status:
        /// - Accepted when operation is successful or 
        /// - MethodNotAllowed if the operation is disabled for this entity or
        /// - BadRequest if the provided entity is NULL</returns>
        public virtual HttpResponseMessage Post(TEntity entity)
        {
            if (entity == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            //TODO: should we check if the incomming entity 
            //is not an existing one?
            TEntity newEntity = repository.AddNew(entity);

            var response = CreateResponse(HttpStatusCode.Accepted, newEntity);
            return response;
        }

        protected abstract HttpResponseMessage CreateResponse
            (HttpStatusCode httpStatusCode, TEntity entityToEmbed);
    }
}