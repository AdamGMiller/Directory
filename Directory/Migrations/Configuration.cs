namespace Directory.Migrations
{
    using Repository;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Directory.Context.DirectoryContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Directory.Context.DirectoryContext context)
        {
            //  This method will be called after migrating to the latest version.

            // update seed data as needed
              context.People.AddOrUpdate(
                p => new { p.FirstName, p.LastName },
                new Person { FirstName = "Andrew", LastName = "Peters", ActiveFlag = true },
                new Person { FirstName = "Jackson", LastName = "Smith", ActiveFlag = true },
                new Person { FirstName = "Rowan", LastName = "Miller", ActiveFlag = true },
                new Person { FirstName = "Dennis", LastName = "Mehl", ActiveFlag = false }
              );

        }
    }
}
