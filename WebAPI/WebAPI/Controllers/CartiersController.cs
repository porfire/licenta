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
    public class CartiersController : ApiController
    {
        // private CartiereImobiliaraEntities db = new CartiereImobiliaraEntities();
        private readonly ICartierService _cartierService;

        public CartiersController()
        {
            _cartierService = new CartierService();
        }

        // GET: api/Cartiers
        public HttpResponseMessage GetAll()
        {
            var cartiere = _cartierService.GetAllCartiers();
            if (cartiere != null)
            {
                var cartierEntities = cartiere as List<CartierEntity> ?? cartiere.ToList();
                if (cartierEntities.Any())
                    return Request.CreateResponse(HttpStatusCode.OK, cartierEntities);
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Cartier not found");
        }

        //// GET: api/Cartiers/5
        public HttpResponseMessage GetGetCartier(int id)
        {
            var cartier = _cartierService.GetCartierById(id);
            if (cartier != null)
                return Request.CreateResponse(HttpStatusCode.OK, cartier);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No product found for this id");
        }

        // POST api/Cartiers
        public int Post([FromBody] CartierEntity CartierEntity)
        {
            return _cartierService.CreateCartier(CartierEntity);
        }

        // PUT api/Cartiers/5
        public bool Put(int id, [FromBody] CartierEntity CartierEntity)
        {
            if (id > 0)
            {
                return _cartierService.UpdateCartier(id, CartierEntity);
            }
            return false;
        }

        // DELETE api/People/5
        public bool Delete(int id)
        {
            if (id > 0)
                return _cartierService.DeleteCartier(id);
            return false;
        }
    }
}