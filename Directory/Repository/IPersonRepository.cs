using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Directory.Repository
{
    public interface IPersonRepository
    {
        IEnumerable<Person> GetAll(string search);
        Person Get(int id);
        void Add(Person person);
        void Update(int id, Person person);
        void Delete(int id);
        bool Exists(int id);
    }
}