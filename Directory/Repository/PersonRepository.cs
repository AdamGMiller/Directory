using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Directory.Repository
{
    public class PersonRepository : IPersonRepository
    {
        private List<Person> people = new List<Person>();

        public PersonRepository()
        {
            // Add products for the Demonstration  
            Add(new Person { FirstName = "Adam", LastName = "Miller" });
            Add(new Person { FirstName = "Bob", LastName = "Smith" });
        }

        public IEnumerable<Person> GetAll()
        {
            // TO DO : Code to get the list of all the records in database  
            return people;
        }
        public Person Get(int id)
        {
            // TO DO : Code to find a record in database  
            return people.Find(p => p.Id == id);
        }
        public Person Add(Person item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            people.Add(item);
            return item;
        }
        public bool Update(Person item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            // TO DO : Code to update record into database  
            int index = people.FindIndex(p => p.Id == item.Id);
            if (index == -1)
            {
                return false;
            }
            people.RemoveAt(index);
            people.Add(item);
            return true;
        }
        public bool Delete(int id)
        {
            // TO DO : Code to remove the records from database  
            people.RemoveAll(p => p.Id == id);
            return true;
        }
    }
}