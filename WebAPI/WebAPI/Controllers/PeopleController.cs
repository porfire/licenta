using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Mvc;
using BusinessEntities.Entities;
using BusinessServices.Interfaces;
using BusinessServices.Services;

namespace WebAPI.Controllers
{

    public class PeopleController : ApiController
    {
        private readonly IPersonService _personService;
        //private AgentieImobiliaraEntities db = new AgentieImobiliaraEntities();
        // private PersonRepository personRepository;

        public PeopleController()
        {
            _personService = new PersonService();
        }


        // GET api/People/allpeoples
        //[Route("people/people/all")]

        //AGENTieimobiliara/people/getall
        public HttpResponseMessage GetAll()
        {
            var persons = _personService.GetAllPersons();
            if (persons != null)
            {
                var productEntities = persons as List<PersonEntity> ?? persons.ToList();
                if (productEntities.Any())
                    return Request.CreateResponse(HttpStatusCode.OK, productEntities);
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Products not found");
        }


        // GET api/People/5
        public HttpResponseMessage Get(int id)
        {
            var person = _personService.GetPersonById(id);
            if (person != null)
                return Request.CreateResponse(HttpStatusCode.OK, person);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No product found for this id");
        }

        [ResponseType(typeof(PersonEntity))]
        public IHttpActionResult Post(PersonEntity personEntity)
        {
            if (String.IsNullOrEmpty(personEntity.email) ||
                String.IsNullOrEmpty(personEntity.password))
            {
                return StatusCode(HttpStatusCode.BadRequest);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (personEntity.userName != null)
            {
                _personService.CreatePerson(personEntity);
                return StatusCode(HttpStatusCode.OK);
                //HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, personEntity);
            }

            return StatusCode(HttpStatusCode.Conflict);

        }

        [ResponseType(typeof(PersonEntity))]
        public IHttpActionResult Post1(string username, PersonEntity personEntity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (username != personEntity.userName)
                //if(personEntity.userName != null)
            {
                _personService.CreatePerson(personEntity);
            }
            return StatusCode(HttpStatusCode.NoContent);
        }


        [ResponseType(typeof(PersonEntity))]
        public async Task<HttpStatusCodeResult> Register(string email, string password, string passwordConfirm)
        {
            if (String.IsNullOrEmpty(email) ||
                String.IsNullOrEmpty(password) ||
                !String.Equals(password, passwordConfirm))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Registration from is invalid");
            }
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("");
                client.DefaultRequestHeaders.Accept.Clear();
                var registerModel = new Dictionary<string, string>
                {
                    {"Email", email},
                    {"Password", password},
                    {"ConfirmPassword", password}
                };

                var response = await client.PostAsJsonAsync("agentieimobiliara/People/Register", registerModel);
                return new HttpStatusCodeResult(response.StatusCode, response.ReasonPhrase);
            }
        }



        // POST api/Account/Register

        //[System.Web.Mvc.AllowAnonymous]
        //[System.Web.Mvc.Route("Register")]
        //public async Task<IHttpActionResult> Register(RegisterBindingModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var user = new PersonEntity() { userName = model.Email, email = model.Email };

        //    IdentityResult result = _personService.CreatePerson(model.Email, model.Password);

        //    if (!result.Succeeded)
        //    {
        //        return GetErrorResult(result);
        //    }

        //    return Ok();
        //}

        //private IHttpActionResult GetErrorResult(IdentityResult result)
        //{
        //    if (result == null)
        //    {
        //        return InternalServerError();
        //    }

        //    if (!result.Succeeded)
        //    {
        //        if (result.Errors != null)
        //        {
        //            foreach (string error in result.Errors)
        //            {
        //                ModelState.AddModelError("", error);
        //            }
        //        }

        //        if (ModelState.IsValid)
        //        {
        //            // No ModelState errors are available to send, so just return an empty BadRequest.
        //            return BadRequest();
        //        }

        //        return BadRequest(ModelState);
        //    }

        //    return null;
        //}


        //public JsonResult IsUserNameAvailable(string UserName)
        //{
        //    if (!UserExists(UserName))
        //        return Json(true, JsonRequestBehavior.AllowGet);
        //    else
        //        return Json("Sorry, " + UserName + " already exist", JsonRequestBehavior.AllowGet);
        //}

        //private bool UserExists(string UserName)
        //{
        //    var usr = _db.Users.FirstOrDefault(d => d.UserName == UserName);
        //    return (usr != null);
        //}
        //public IHttpActionResult Post(PersonEntity personEntity)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    _personService.CreatePerson(personEntity);
        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        public HttpResponseMessage Login(PersonEntity person)
        {
            //if (!ModelState.IsValid)
            var account = _personService.GetByEmailAndPassword(person.email, person.password);
            if (account == null)
            {
                ModelState.AddModelError("Email", "Login failed");
                return Request.CreateResponse(HttpStatusCode.OK, person);

            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No product found for this id");
        }
    
    
        public bool Put(int id, [FromBody] PersonEntity personEntity)
        {
            if (id > 0)
            {
                return _personService.UpdatePerson(id, personEntity);
            }
            return false;
        }

        // DELETE api/People/5
        public bool Delete(int id)
        {
            if (id > 0)
                return _personService.DeletePerson(id);
            return false;
        }

        /// <summary>
        /// Creates the response sent back to client 
        /// after a new entity is successfully created.
        /// </summary>
        /// <param name="httpStatusCode">Status code to return</param>
        /// <param name="entityToEmbed">Entity instance 
        /// to embed in the response</param>
        /// <returns>HttpResponseMessage with the provided
        /// status code and object to embed</returns>
        protected HttpResponseMessage CreateResponse
            (HttpStatusCode httpStatusCode, PersonEntity entityToEmbed)
        {
            HttpResponseMessage response = Request.
                CreateResponse<PersonEntity>(httpStatusCode, entityToEmbed);

            string uri = Url.Link("DefaultApi", new { id = entityToEmbed.personID });
            response.Headers.Location = new Uri(uri);

            return response;
        }

      
}
}