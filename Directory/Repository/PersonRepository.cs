// <copyright file="PersonRepository.cs" company="Adam Miller">
// Copyright (c) Adam Miller. All rights reserved.
// </copyright>

namespace Directory.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using Directory.Context;

    /// <summary>
    /// Repository for people information
    /// </summary>
    public class PersonRepository : IPersonRepository
    {
        private DirectoryContext db = new DirectoryContext();

        /// <summary>
        /// Initializes a new instance of the <see cref="PersonRepository"/> class.
        /// </summary>
        public PersonRepository()
        {
        }

        /// <summary>
        /// Joins a first name and a last name together into a single string.
        /// </summary>
        /// <param name="page">The page number to return.</param>
        /// <param name="pageSize">The number of records returned per page.</param>
        /// <param name="search">The search text.</param>
        /// <returns>People that match the criteria.</returns>
        public IEnumerable<Person> GetAll(int page, int pageSize, string search)
        {
            // OCCASIONALLY FORCE A DELAY IN RESPONSE
            // FOR DEMO PURPOSES ONLY!
            Random r = new Random();
            int random = r.Next(0, 10);
            if (random < 4)
            {
                Thread.Sleep(1000);
            }

            // pull all active people
            IQueryable<Person> people = this.db.People
                .Where(q => q.ActiveFlag == true);

            // perform "smart" name search if space or comma present
            if (string.IsNullOrEmpty(search) == false)
            {
                string[] names = search.Split(
                    new char[] { ',', ' ' },
                                 StringSplitOptions.RemoveEmptyEntries);

                if (names.Length > 1)
                {
                    string firstName = string.Empty;
                    string lastName = string.Empty;
                    if (search.Contains(','))
                    {
                        // if comma present, use lastname, firstname format
                        firstName = names.Last();
                        lastName = names.First();
                    }
                    else
                    {
                        // if no comma, use firstname lastname format
                        firstName = names.First();
                        lastName = names.Last();
                    }

                    people = people.Where(q => q.FirstName.StartsWith(firstName) &&
                                               q.LastName.StartsWith(lastName));
                }
                else
                {
                    // simple one-word search
                    people = people.Where(q => q.FirstName.Contains(search) ||
                                               q.LastName.Contains(search));
                }
            }

            // limit results, sorting by first and last name
            people = people
                .OrderBy(q => new { q.FirstName, q.LastName })
                .Skip((page - 1) * pageSize)
                .Take(pageSize);

            return people;
        }

        /// <summary>
        /// Gets a single Person record
        /// </summary>
        /// <param name="id">The key of the person record.</param>
        /// <returns>Person with that id.</returns>
        public Person Get(int id)
        {
            if (this.Exists(id) == false)
            {
                throw new Exception("Person Id cannot be found.");
            }

            return this.db.People.Single(p => p.Id == id);
        }

        /// <summary>
        /// Adds a single Person record
        /// </summary>
        /// <param name="person">A new person record.</param>
        public void Add(Person person)
        {
            if (person == null)
            {
                throw new ArgumentNullException("No person data to add.");
            }

            this.db.People.Add(person);
            this.db.SaveChanges();
        }

        /// <summary>
        /// Updates a single Person record
        /// </summary>
        /// <param name="id">The key of the person record.</param>
        /// <param name="person">The person record to replace it.</param>
        public void Update(int id, Person person)
        {
            if (person == null)
            {
                throw new ArgumentNullException("No person data to update.");
            }

            if (this.Exists(id) == false)
            {
                throw new Exception("Person Id cannot be found.");
            }

            if (id != person.Id)
            {
                throw new Exception("Url Id doesn't match object Id.");
            }

            Person currentPerson = this.db.People.Single(q => q.Id == person.Id);
            currentPerson.FirstName = person.FirstName;
            currentPerson.LastName = person.LastName;
            currentPerson.Dob = person.Dob;
            currentPerson.Interests = person.Interests;
            currentPerson.Photo = person.Photo;

            this.db.SaveChanges();
        }

        /// <summary>
        /// Mark record as inactive
        /// This is generally preferred for data integrity and data loss mitigation
        /// </summary>
        /// <param name="id">The key of the person record to delete.</param>
        public void Delete(int id)
        {
            Person person = this.db.People.Single(q => q.Id == id);
            person.ActiveFlag = false;

            this.db.SaveChanges();
        }

        /// <summary>
        /// Checks if a single Person record exists
        /// </summary>
        /// <param name="id">The key of the person record.</param>
        /// <returns>Whether or not the person exists.</returns>
        public bool Exists(int id)
        {
            return this.db.People.Count(e => e.Id == id) > 0;
        }
    }
}