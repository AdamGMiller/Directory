using Directory.Repository;
using System.Net;
using System.Web.Http;

namespace Directory.Controllers
{
    public class PersonController : ApiController
    {
        readonly IPersonRepository repo;
        public PersonController(IPersonRepository personRepository)
        {
            this.repo = personRepository;
        }

        // GET: api/Person/
        [HttpGet]
        public IHttpActionResult GetAll(int page = 1, int pageSize = 10, string search = null)
        {
            return Ok(repo.GetAll(page, pageSize, search));
        }

        // GET: api/Person/5
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            if(repo.Exists(id) == false)
            {
                return Content(HttpStatusCode.NotFound, "Person " + id.ToString() + " not found.");
            }

            Person person = repo.Get(id);

            return Ok(person);
        }

        // POST: api/Person/
        [HttpPost]
        public IHttpActionResult Post(Person person)
        {
            repo.Add(person);
            return CreatedAtRoute("DefaultApi", new { id = person.Id }, person);
        }

        // DELETE: api/Person/5
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            if (repo.Exists(id) == false)
            {
                return Content(HttpStatusCode.NotFound, "Person " + id.ToString() + " not found.");
            }

            repo.Delete(id);
            return Ok();
        }

        // PUT: api/Person/5
        [HttpPut]
        public IHttpActionResult Put(int id, Person person)
        {
            if(!ModelState.IsValid)
            {
                return Content(HttpStatusCode.BadRequest, "Person model is invalid.");
            }

            if (repo.Exists(id) == false)
            {
                return Content(HttpStatusCode.NotFound, "Person " + id.ToString() + " not found.");
            }

            repo.Update(id, person);

            return Content(HttpStatusCode.Accepted, person);
        }
    }
}