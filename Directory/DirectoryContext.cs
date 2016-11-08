using Directory.Repository;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Directory.Context
{
    public class DirectoryContext : DbContext
    {
        public DirectoryContext() : base("name=DirectoryConnectionString")
        {
            // use a custom initializer in order to seed the data
            Database.SetInitializer(new DirectoryInitializer());
        }

        public DbSet<Person> People{ get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Person>().Property(p => p.ConcurrencyToken).IsConcurrencyToken();

            base.OnModelCreating(modelBuilder);
        }
    }
}