using Directory.Context;
using Directory.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Directory
{
    public class DirectoryInitializer : CreateDatabaseIfNotExists<DirectoryContext>
    {
        // Seed the initial database with some temporary values
        protected override void Seed(DirectoryContext context)
        {
            IList<Person> seedPeople = new List<Person>();

            seedPeople.Add(new Person() { FirstName = "Andrew", LastName = "Peters", ActiveFlag = true });
            seedPeople.Add(new Person() { FirstName = "Jackson", LastName = "Smith", ActiveFlag = true });
            seedPeople.Add(new Person() { FirstName = "Rowan", LastName = "Miller", ActiveFlag = true });
            seedPeople.Add(new Person() { FirstName = "Dennis", LastName = "Mehl", ActiveFlag = true });

            foreach (Person seedPerson in seedPeople)
                context.People.Add(seedPerson);

            base.Seed(context);
        }
    }
}