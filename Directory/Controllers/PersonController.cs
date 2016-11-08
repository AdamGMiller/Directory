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

        // GET: Person
        [HttpGet]
        public IHttpActionResult Index()
        {
            return Ok(repo.GetAll());
        }
        
    }
}