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
                new Person() { FirstName = "Jennifer", LastName = "Webb", Interests = "deliver user-centric eyeballs", Dob = DateTime.Parse("10/22/1973"), ActiveFlag = true },
                new Person() { FirstName = "Kimberly", LastName = "Olson", Interests = "morph bricks-and-clicks niches", Dob = DateTime.Parse("06/01/1990"), ActiveFlag = true },
                new Person() { FirstName = "Marie", LastName = "Shaw", Interests = "recontextualize value-added applications", Dob = DateTime.Parse("08/03/1961"), ActiveFlag = true },
                new Person() { FirstName = "Rose", LastName = "Fields", Interests = "engage clicks-and-mortar schemas", Dob = DateTime.Parse("12/19/1977"), ActiveFlag = true },
                new Person() { FirstName = "Eugene", LastName = "Cox", Interests = "syndicate world-class relationships", Dob = DateTime.Parse("05/26/1988"), ActiveFlag = true },
                new Person() { FirstName = "Richard", LastName = "Russell", Interests = "disintermediate global infrastructures", Dob = DateTime.Parse("05/03/1980"), ActiveFlag = true },
                new Person() { FirstName = "Jean", LastName = "Walker", Interests = "seize collaborative applications", Dob = DateTime.Parse("05/24/1968"), ActiveFlag = true },
                new Person() { FirstName = "Mark", LastName = "Lawrence", Interests = "synergize impressive interfaces", Dob = DateTime.Parse("05/06/1960"), ActiveFlag = true },
                new Person() { FirstName = "Lillian", LastName = "Rogers", Interests = "target interactive eyeballs", Dob = DateTime.Parse("05/01/1960"), ActiveFlag = true },
                new Person() { FirstName = "David", LastName = "Snyder", Interests = "revolutionize killer experiences", Dob = DateTime.Parse("11/15/1972"), ActiveFlag = true },
                new Person() { FirstName = "Beverly", LastName = "Butler", Interests = "maximize bricks-and-clicks vortals", Dob = DateTime.Parse("11/15/1968"), ActiveFlag = true },
                new Person() { FirstName = "Judith", LastName = "Dunn", Interests = "enhance real-time action-items", Dob = DateTime.Parse("01/21/1987"), ActiveFlag = true },
                new Person() { FirstName = "Ernest", LastName = "Thomas", Interests = "envisioneer leading-edge models", Dob = DateTime.Parse("06/17/1940"), ActiveFlag = true },
                new Person() { FirstName = "Julie", LastName = "Harper", Interests = "leverage value-added applications", Dob = DateTime.Parse("07/08/1975"), ActiveFlag = true },
                new Person() { FirstName = "Gary", LastName = "Austin", Interests = "redefine value-added partnerships", Dob = DateTime.Parse("01/18/1962"), ActiveFlag = true },
                new Person() { FirstName = "Judith", LastName = "Hudson", Interests = "productize customized communities", Dob = DateTime.Parse("02/28/1969"), ActiveFlag = true },
                new Person() { FirstName = "Ryan", LastName = "Bradley", Interests = "maximize end-to-end models", Dob = DateTime.Parse("03/27/1961"), ActiveFlag = true },
                new Person() { FirstName = "Roger", LastName = "Chavez", Interests = "deploy robust communities", Dob = DateTime.Parse("03/01/1964"), ActiveFlag = true },
                new Person() { FirstName = "Howard", LastName = "Mason", Interests = "e-enable compelling methodologies", Dob = DateTime.Parse("02/22/1972"), ActiveFlag = true },
                new Person() { FirstName = "Ryan", LastName = "Shaw", Interests = "incentivize user-centric applications", Dob = DateTime.Parse("12/23/1947"), ActiveFlag = true },
                new Person() { FirstName = "Ernest", LastName = "Turner", Interests = "visualize extensible users", Dob = DateTime.Parse("03/22/1954"), ActiveFlag = true },
                new Person() { FirstName = "Lillian", LastName = "Lynch", Interests = "scale viral communities", Dob = DateTime.Parse("09/23/1969"), ActiveFlag = true },
                new Person() { FirstName = "Beverly", LastName = "Mitchell", Interests = "maximize e-business ROI", Dob = DateTime.Parse("02/03/1964"), ActiveFlag = true },
                new Person() { FirstName = "Tammy", LastName = "Miller", Interests = "visualize revolutionary interfaces", Dob = DateTime.Parse("01/19/1945"), ActiveFlag = true },
                new Person() { FirstName = "Evelyn", LastName = "Martinez", Interests = "brand dynamic niches", Dob = DateTime.Parse("07/14/1961"), ActiveFlag = true },
                new Person() { FirstName = "Diana", LastName = "Brooks", Interests = "streamline cross-platform initiatives", Dob = DateTime.Parse("04/26/1960"), ActiveFlag = true },
                new Person() { FirstName = "Rebecca", LastName = "Robertson", Interests = "engage holistic niches", Dob = DateTime.Parse("05/21/1973"), ActiveFlag = true },
                new Person() { FirstName = "Carolyn", LastName = "Roberts", Interests = "synthesize seamless e-markets", Dob = DateTime.Parse("05/01/1956"), ActiveFlag = true },
                new Person() { FirstName = "Mildred", LastName = "Brown", Interests = "transform 24/365 bandwidth", Dob = DateTime.Parse("01/18/1964"), ActiveFlag = true },
                new Person() { FirstName = "Samuel", LastName = "Wilson", Interests = "repurpose 24/7 methodologies", Dob = DateTime.Parse("07/29/1973"), ActiveFlag = true },
                new Person() { FirstName = "Phyllis", LastName = "Howell", Interests = "engage e-business methodologies", Dob = DateTime.Parse("10/01/1983"), ActiveFlag = true },
                new Person() { FirstName = "Joan", LastName = "Carpenter", Interests = "matrix extensible applications", Dob = DateTime.Parse("07/28/1975"), ActiveFlag = true },
                new Person() { FirstName = "Wanda", LastName = "Davis", Interests = "syndicate unusual users", Dob = DateTime.Parse("09/29/1985"), ActiveFlag = true },
                new Person() { FirstName = "Martin", LastName = "Murphy", Interests = "whiteboard extensible interfaces", Dob = DateTime.Parse("01/31/1981"), ActiveFlag = true },
                new Person() { FirstName = "Amanda", LastName = "Robinson", Interests = "facilitate extensible partnerships", Dob = DateTime.Parse("05/01/1964"), ActiveFlag = true },
                new Person() { FirstName = "Jimmy", LastName = "Garcia", Interests = "embrace cross-platform interfaces", Dob = DateTime.Parse("05/28/1961"), ActiveFlag = true },
                new Person() { FirstName = "Kimberly", LastName = "Howell", Interests = "reinvent user-centric supply-chains", Dob = DateTime.Parse("03/06/1985"), ActiveFlag = true },
                new Person() { FirstName = "Henry", LastName = "Simpson", Interests = "generate 24/365 niches", Dob = DateTime.Parse("06/16/1959"), ActiveFlag = true },
                new Person() { FirstName = "Daniel", LastName = "Fernandez", Interests = "repurpose dot-com content", Dob = DateTime.Parse("03/06/1968"), ActiveFlag = true },
                new Person() { FirstName = "Jessica", LastName = "Hansen", Interests = "repurpose revolutionary models", Dob = DateTime.Parse("01/27/1948"), ActiveFlag = true },
                new Person() { FirstName = "Susan", LastName = "Andrews", Interests = "e-enable revolutionary users", Dob = DateTime.Parse("04/18/1951"), ActiveFlag = true },
                new Person() { FirstName = "Emily", LastName = "Dunn", Interests = "revolutionize real-time paradigms", Dob = DateTime.Parse("03/27/1979"), ActiveFlag = true },
                new Person() { FirstName = "Wanda", LastName = "Simpson", Interests = "synergize end-to-end interfaces", Dob = DateTime.Parse("08/14/1978"), ActiveFlag = true },
                new Person() { FirstName = "Martha", LastName = "Carr", Interests = "maximize granular functionalities", Dob = DateTime.Parse("02/28/1971"), ActiveFlag = true },
                new Person() { FirstName = "Rachel", LastName = "Wheeler", Interests = "synthesize visionary partnerships", Dob = DateTime.Parse("02/16/1960"), ActiveFlag = true },
                new Person() { FirstName = "Antonio", LastName = "Martinez", Interests = "transform leading-edge vortals", Dob = DateTime.Parse("07/23/1945"), ActiveFlag = true },
                new Person() { FirstName = "Anna", LastName = "Simmons", Interests = "strategize plug-and-play networks", Dob = DateTime.Parse("12/10/1983"), ActiveFlag = true },
                new Person() { FirstName = "Ernest", LastName = "Olson", Interests = "extend cross-media vortals", Dob = DateTime.Parse("08/26/1972"), ActiveFlag = true },
                new Person() { FirstName = "Sean", LastName = "Brown", Interests = "iterate robust paradigms", Dob = DateTime.Parse("10/19/1965"), ActiveFlag = true },
                new Person() { FirstName = "Ashley", LastName = "Stephens", Interests = "streamline robust solutions", Dob = DateTime.Parse("06/02/1953"), ActiveFlag = true },
                new Person() { FirstName = "Jason", LastName = "Price", Interests = "deploy B2C e-tailers", Dob = DateTime.Parse("05/03/1962"), ActiveFlag = true },
                new Person() { FirstName = "Brandon", LastName = "Black", Interests = "brand customized e-markets", Dob = DateTime.Parse("02/07/1987"), ActiveFlag = true },
                new Person() { FirstName = "Mark", LastName = "Fuller", Interests = "leverage vertical e-business", Dob = DateTime.Parse("04/16/1946"), ActiveFlag = true },
                new Person() { FirstName = "Judy", LastName = "West", Interests = "leverage e-business web-readiness", Dob = DateTime.Parse("02/14/1955"), ActiveFlag = true },
                new Person() { FirstName = "Jimmy", LastName = "Phillips", Interests = "syndicate vertical e-commerce", Dob = DateTime.Parse("06/22/1975"), ActiveFlag = true },
                new Person() { FirstName = "Cynthia", LastName = "Boyd", Interests = "innovate e-business convergence", Dob = DateTime.Parse("10/12/1978"), ActiveFlag = true },
                new Person() { FirstName = "Carl", LastName = "Graham", Interests = "orchestrate holistic e-business", Dob = DateTime.Parse("12/31/1947"), ActiveFlag = true },
                new Person() { FirstName = "Paul", LastName = "Gordon", Interests = "optimize cross-platform web-readiness", Dob = DateTime.Parse("10/14/1942"), ActiveFlag = true },
                new Person() { FirstName = "Jean", LastName = "Walker", Interests = "visualize holistic applications", Dob = DateTime.Parse("05/22/1952"), ActiveFlag = true },
                new Person() { FirstName = "Walter", LastName = "Kelley", Interests = "strategize real-time infomediaries", Dob = DateTime.Parse("06/03/1962"), ActiveFlag = true },
                new Person() { FirstName = "Robin", LastName = "Hamilton", Interests = "orchestrate one-to-one communities", Dob = DateTime.Parse("11/03/1989"), ActiveFlag = true },
                new Person() { FirstName = "Virginia", LastName = "Mendoza", Interests = "drive transparent metrics", Dob = DateTime.Parse("09/03/1943"), ActiveFlag = true },
                new Person() { FirstName = "Nancy", LastName = "Robinson", Interests = "reinvent extensible markets", Dob = DateTime.Parse("06/04/1953"), ActiveFlag = true },
                new Person() { FirstName = "Julie", LastName = "Fernandez", Interests = "expedite leading-edge schemas", Dob = DateTime.Parse("06/23/1958"), ActiveFlag = true },
                new Person() { FirstName = "David", LastName = "Montgomery", Interests = "embrace user-centric methodologies", Dob = DateTime.Parse("11/18/1963"), ActiveFlag = true },
                new Person() { FirstName = "Karen", LastName = "Carroll", Interests = "reinvent revolutionary deliverables", Dob = DateTime.Parse("06/04/1951"), ActiveFlag = true },
                new Person() { FirstName = "Adam", LastName = "Tucker", Interests = "streamline intuitive metrics", Dob = DateTime.Parse("12/18/1942"), ActiveFlag = true },
                new Person() { FirstName = "James", LastName = "Stevens", Interests = "recontextualize integrated e-services", Dob = DateTime.Parse("08/07/1987"), ActiveFlag = true },
                new Person() { FirstName = "Catherine", LastName = "Wagner", Interests = "orchestrate global models", Dob = DateTime.Parse("11/29/1961"), ActiveFlag = true },
                new Person() { FirstName = "Jesse", LastName = "Allen", Interests = "transform 24/7 content", Dob = DateTime.Parse("08/12/1952"), ActiveFlag = true },
                new Person() { FirstName = "Ronald", LastName = "Weaver", Interests = "synergize extensible interfaces", Dob = DateTime.Parse("06/23/1948"), ActiveFlag = true },
                new Person() { FirstName = "Janet", LastName = "Welch", Interests = "architect collaborative networks", Dob = DateTime.Parse("08/19/1944"), ActiveFlag = true },
                new Person() { FirstName = "Clarence", LastName = "Warren", Interests = "enhance dot-com supply-chains", Dob = DateTime.Parse("04/26/1979"), ActiveFlag = true },
                new Person() { FirstName = "Shawn", LastName = "Butler", Interests = "brand cross-platform content", Dob = DateTime.Parse("05/10/1965"), ActiveFlag = true },
                new Person() { FirstName = "Andrew", LastName = "Carter", Interests = "strategize global eyeballs", Dob = DateTime.Parse("01/16/1955"), ActiveFlag = true },
                new Person() { FirstName = "Kathleen", LastName = "Pierce", Interests = "deploy bleeding-edge mindshare", Dob = DateTime.Parse("06/26/1951"), ActiveFlag = true },
                new Person() { FirstName = "Jack", LastName = "Hart", Interests = "aggregate frictionless experiences", Dob = DateTime.Parse("09/06/1951"), ActiveFlag = true },
                new Person() { FirstName = "Michelle", LastName = "White", Interests = "architect clicks-and-mortar channels", Dob = DateTime.Parse("04/07/1944"), ActiveFlag = true },
                new Person() { FirstName = "Jeremy", LastName = "Morgan", Interests = "synthesize open-source e-markets", Dob = DateTime.Parse("12/28/1945"), ActiveFlag = true },
                new Person() { FirstName = "Clarence", LastName = "Brown", Interests = "e-enable plug-and-play methodologies", Dob = DateTime.Parse("09/29/1947"), ActiveFlag = true },
                new Person() { FirstName = "Jerry", LastName = "Gibson", Interests = "innovate one-to-one systems", Dob = DateTime.Parse("03/17/1987"), ActiveFlag = true },
                new Person() { FirstName = "Tammy", LastName = "Hernandez", Interests = "maximize enterprise web services", Dob = DateTime.Parse("08/17/1982"), ActiveFlag = true },
                new Person() { FirstName = "Christopher", LastName = "Peters", Interests = "synthesize scalable applications", Dob = DateTime.Parse("09/08/1969"), ActiveFlag = true },
                new Person() { FirstName = "Angela", LastName = "Berry", Interests = "target holistic content", Dob = DateTime.Parse("06/26/1978"), ActiveFlag = true },
                new Person() { FirstName = "Diana", LastName = "Richardson", Interests = "scale dot-com functionalities", Dob = DateTime.Parse("10/18/1987"), ActiveFlag = true },
                new Person() { FirstName = "Mildred", LastName = "Reid", Interests = "scale killer convergence", Dob = DateTime.Parse("04/18/1959"), ActiveFlag = true },
                new Person() { FirstName = "Joseph", LastName = "Duncan", Interests = "productize bleeding-edge experiences", Dob = DateTime.Parse("07/27/1978"), ActiveFlag = true },
                new Person() { FirstName = "Brandon", LastName = "Morgan", Interests = "visualize integrated niches", Dob = DateTime.Parse("02/28/1985"), ActiveFlag = true },
                new Person() { FirstName = "Alan", LastName = "Riley", Interests = "repurpose viral content", Dob = DateTime.Parse("12/20/1949"), ActiveFlag = true },
                new Person() { FirstName = "Christine", LastName = "Mitchell", Interests = "aggregate impactful infomediaries", Dob = DateTime.Parse("09/14/1989"), ActiveFlag = true },
                new Person() { FirstName = "Martin", LastName = "Hall", Interests = "synergize web-enabled web services", Dob = DateTime.Parse("08/19/1959"), ActiveFlag = true },
                new Person() { FirstName = "Michael", LastName = "Morgan", Interests = "visualize holistic action-items", Dob = DateTime.Parse("05/03/1946"), ActiveFlag = true },
                new Person() { FirstName = "Jeremy", LastName = "Gilbert", Interests = "implement frictionless vortals", Dob = DateTime.Parse("04/18/1963"), ActiveFlag = true },
                new Person() { FirstName = "Craig", LastName = "Lawrence", Interests = "revolutionize turn-key e-services", Dob = DateTime.Parse("02/10/1975"), ActiveFlag = true },
                new Person() { FirstName = "Jeffrey", LastName = "Walker", Interests = "facilitate integrated synergies", Dob = DateTime.Parse("06/07/1954"), ActiveFlag = true },
                new Person() { FirstName = "Christine", LastName = "Barnes", Interests = "reintermediate dot-com channels", Dob = DateTime.Parse("09/11/1941"), ActiveFlag = true },
                new Person() { FirstName = "Theresa", LastName = "Hudson", Interests = "benchmark cross-platform relationships", Dob = DateTime.Parse("11/26/1979"), ActiveFlag = true },
                new Person() { FirstName = "Evelyn", LastName = "Hall", Interests = "integrate best-of-breed markets", Dob = DateTime.Parse("04/06/1983"), ActiveFlag = true },
                new Person() { FirstName = "Jerry", LastName = "West", Interests = "e-enable sticky interfaces", Dob = DateTime.Parse("04/25/1960"), ActiveFlag = true },
                new Person() { FirstName = "Diane", LastName = "Simpson", Interests = "target scalable channels", Dob = DateTime.Parse("09/05/1971"), ActiveFlag = true }
            );
        }
    }
}
