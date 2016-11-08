using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Directory.Repository;
using System.Web.Http;

namespace Directory.Controllers
{
    public class PersonController : ApiController
    {
        readonly IPersonRepository repo;
        public PersonController(IPersonRepository person)
        {
            this.repo = person;
        }

        // GET: api/Person/
        [HttpGet]
        public IHttpActionResult Index(int page = 1, int pageSize = 10, string search = null)
        {
            return Ok(repo.GetAll(page, pageSize, search));
        }

        // GET: api/Person/5
        [HttpGet]
        public IHttpActionResult GetPerson(int id)
        {
            if(repo.Exists(id) == false)
            {
                return BadRequest("Id not found");
            }

            Person person = repo.Get(id);

            return Ok(person);
        }

    }
}