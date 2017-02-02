// <copyright file="PersonController.cs" company="Adam Miller">
// Copyright (c) Adam Miller. All rights reserved.
// </copyright>

namespace Directory.Controllers
{
    using System.Net;
    using System.Web.Http;
    using Directory.Repository;

    /// <summary>
    /// Controller for the Person repository
    /// Handles REST services
    /// </summary>
    public class PersonController : ApiController
    {
        private readonly IPersonRepository repo;

        /// <summary>
        /// Initializes a new instance of the <see cref="PersonController"/> class.
        /// Creates an instance of a Person controller
        /// </summary>
        /// <param name="personRepository">This is the injectable repository.</param>
        public PersonController(IPersonRepository personRepository)
        {
            this.repo = personRepository;
        }

        /// <summary>
        /// GET: api/Person/
        /// Gets multiple people through the REST API
        /// </summary>
        /// <param name="page">The page number to return.</param>
        /// <param name="pageSize">The number of records returned per page.</param>
        /// <param name="search">The search text.</param>
        /// <returns>People that match the criteria from the repo.</returns>
        [HttpGet]
        public IHttpActionResult GetAll(int page = 1, int pageSize = 10, string search = null)
        {
            return this.Ok(this.repo.GetAll(page, pageSize, search));
        }

        /// <summary>
        /// GET: api/Person/5
        /// Gets a single person record through the REST API
        /// </summary>
        /// <param name="id">The id of the Person record.</param>
        /// <returns>Single person that match the criteria.</returns>
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            if (this.repo.Exists(id) == false)
            {
                return this.Content(HttpStatusCode.NotFound, "Person " + id.ToString() + " not found.");
            }

            Person person = this.repo.Get(id);

            return this.Ok(person);
        }

        // POST: api/Person/
        [HttpPost]
        public IHttpActionResult Post(Person person)
        {
            this.repo.Add(person);
            return this.CreatedAtRoute("DefaultApi", new { id = person.Id }, person);
        }

        // DELETE: api/Person/5
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            if (this.repo.Exists(id) == false)
            {
                return this.Content(HttpStatusCode.NotFound, "Person " + id.ToString() + " not found.");
            }

            this.repo.Delete(id);
            return this.Ok();
        }

        // PUT: api/Person/5
        [HttpPut]
        public IHttpActionResult Put(int id, Person person)
        {
            if (!this.ModelState.IsValid)
            {
                return this.Content(HttpStatusCode.BadRequest, "Person model is invalid.");
            }

            if (this.repo.Exists(id) == false)
            {
                return this.Content(HttpStatusCode.NotFound, "Person " + id.ToString() + " not found.");
            }

            this.repo.Update(id, person);

            return this.Content(HttpStatusCode.Accepted, person);
        }
    }
}