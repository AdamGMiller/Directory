﻿using Directory.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Directory.Repository
{
    public class PersonRepository : IPersonRepository
    {
        private DirectoryContext db = new DirectoryContext();

        public PersonRepository()
        {
        }

        public IEnumerable<Person> GetAll(int page, int pageSize, string search)
        {
            // pull all active people
            IQueryable<Person> people = db.People
                .Where(q => q.ActiveFlag == true);

            // perform "smart" name search if space or comma present
            if (String.IsNullOrEmpty(search) == false)
            {
                string[] names = search.Split(new Char[] { ',', ' ' },
                                 StringSplitOptions.RemoveEmptyEntries);

                if (names.Length > 1)
                {
                    string firstName = "";
                    string lastName = "";
                    // if comma present, use lastname, firstname format
                    if (search.Contains(','))
                    {
                        firstName = names.Last();
                        lastName = names.First();
                    }
                    else
                    // if no comma, use firstname lastname format
                    {
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
                .OrderBy(q => new { q.FirstName, q.LastName})
                .Skip((page - 1) * pageSize)
                .Take(pageSize);

            return people;
        }
        public Person Get(int id)
        {
            if (Exists(id) == false)
            {
                throw new Exception("Person Id cannot be found.");
            }

            return db.People.Single(p => p.Id == id);
        }
        public void Add(Person person)
        {
            if (person == null)
            {
                throw new ArgumentNullException("No person data to add.");
            }

            db.People.Add(person);
            db.SaveChanges();
        }
        public void Update(int id, Person person)
        {
            if (person == null)
            {
                throw new ArgumentNullException("No person data to update.");
            }

            if (Exists(id) == false)
            {
                throw new Exception("Person Id cannot be found.");
            }

            if (id != person.Id)
            {
                throw new Exception("Url Id doesn't match object Id.");
            }

            Person currentPerson = db.People.Single(q => q.Id == person.Id);
            currentPerson.FirstName = person.FirstName;
            currentPerson.LastName = person.LastName;
            currentPerson.Dob = person.Dob;
            currentPerson.Interests = person.Interests;

            db.SaveChanges();
        }

        // Mark record as inactive
        // This is generally preferred for data integrity and data loss mitigation
        public void Delete(int id)
        {
            Person person = db.People.Single(q => q.Id == id);
            person.ActiveFlag = false;

            db.SaveChanges();
        }

        public bool Exists(int id)
        {
            return db.People.Count(e => e.Id == id) > 0;
        }
    }
}