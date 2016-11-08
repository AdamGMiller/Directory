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

            seedPeople.Add(new Person() { FirstName = "Jennifer", LastName = "Webb", Interests = "deliver user-centric eyeballs", Dob = DateTime.Parse("03/21/1956"), ActiveFlag = true });
            seedPeople.Add(new Person() { FirstName = "Kimberly", LastName = "Olson", Interests = "morph bricks-and-clicks niches", Dob = DateTime.Parse("07/30/1970"), ActiveFlag = true });
            seedPeople.Add(new Person() { FirstName = "Marie", LastName = "Shaw", Interests = "recontextualize value-added applications", Dob = DateTime.Parse("08/01/1970"), ActiveFlag = true });
            seedPeople.Add(new Person() { FirstName = "Rose", LastName = "Fields", Interests = "engage clicks-and-mortar schemas", Dob = DateTime.Parse("10/20/1941"), ActiveFlag = true });
            seedPeople.Add(new Person() { FirstName = "Eugene", LastName = "Cox", Interests = "syndicate world-class relationships", Dob = DateTime.Parse("03/08/1967"), ActiveFlag = true });
            seedPeople.Add(new Person() { FirstName = "Richard", LastName = "Russell", Interests = "disintermediate global infrastructures", Dob = DateTime.Parse("04/22/1976"), ActiveFlag = true });
            seedPeople.Add(new Person() { FirstName = "Jean", LastName = "Walker", Interests = "seize collaborative applications", Dob = DateTime.Parse("01/23/1966"), ActiveFlag = true });
            seedPeople.Add(new Person() { FirstName = "Mark", LastName = "Lawrence", Interests = "synergize impressive interfaces", Dob = DateTime.Parse("09/28/1964"), ActiveFlag = true });
            seedPeople.Add(new Person() { FirstName = "Lillian", LastName = "Rogers", Interests = "target interactive eyeballs", Dob = DateTime.Parse("04/27/1975"), ActiveFlag = true });
            seedPeople.Add(new Person() { FirstName = "David", LastName = "Snyder", Interests = "revolutionize killer experiences", Dob = DateTime.Parse("11/04/1986"), ActiveFlag = true });
            seedPeople.Add(new Person() { FirstName = "Beverly", LastName = "Butler", Interests = "maximize bricks-and-clicks vortals", Dob = DateTime.Parse("11/26/1986"), ActiveFlag = true });
            seedPeople.Add(new Person() { FirstName = "Judith", LastName = "Dunn", Interests = "enhance real-time action-items", Dob = DateTime.Parse("02/16/1977"), ActiveFlag = true });
            seedPeople.Add(new Person() { FirstName = "Ernest", LastName = "Thomas", Interests = "envisioneer leading-edge models", Dob = DateTime.Parse("04/02/1950"), ActiveFlag = true });
            seedPeople.Add(new Person() { FirstName = "Julie", LastName = "Harper", Interests = "leverage value-added applications", Dob = DateTime.Parse("02/14/1958"), ActiveFlag = true });
            seedPeople.Add(new Person() { FirstName = "Gary", LastName = "Austin", Interests = "redefine value-added partnerships", Dob = DateTime.Parse("07/28/1944"), ActiveFlag = true });
            seedPeople.Add(new Person() { FirstName = "Judith", LastName = "Hudson", Interests = "productize customized communities", Dob = DateTime.Parse("12/24/1941"), ActiveFlag = true });
            seedPeople.Add(new Person() { FirstName = "Ryan", LastName = "Bradley", Interests = "maximize end-to-end models", Dob = DateTime.Parse("12/07/1949"), ActiveFlag = true });
            seedPeople.Add(new Person() { FirstName = "Roger", LastName = "Chavez", Interests = "deploy robust communities", Dob = DateTime.Parse("11/03/1988"), ActiveFlag = true });
            seedPeople.Add(new Person() { FirstName = "Howard", LastName = "Mason", Interests = "e-enable compelling methodologies", Dob = DateTime.Parse("03/07/1981"), ActiveFlag = true });
            seedPeople.Add(new Person() { FirstName = "Ryan", LastName = "Shaw", Interests = "incentivize user-centric applications", Dob = DateTime.Parse("11/10/1970"), ActiveFlag = true });
            seedPeople.Add(new Person() { FirstName = "Ernest", LastName = "Turner", Interests = "visualize extensible users", Dob = DateTime.Parse("01/07/1964"), ActiveFlag = true });
            seedPeople.Add(new Person() { FirstName = "Lillian", LastName = "Lynch", Interests = "scale viral communities", Dob = DateTime.Parse("03/09/1961"), ActiveFlag = true });
            seedPeople.Add(new Person() { FirstName = "Beverly", LastName = "Mitchell", Interests = "maximize e-business ROI", Dob = DateTime.Parse("12/08/1971"), ActiveFlag = true });
            seedPeople.Add(new Person() { FirstName = "Tammy", LastName = "Miller", Interests = "visualize revolutionary interfaces", Dob = DateTime.Parse("05/20/1987"), ActiveFlag = true });
            seedPeople.Add(new Person() { FirstName = "Evelyn", LastName = "Martinez", Interests = "brand dynamic niches", Dob = DateTime.Parse("08/14/1985"), ActiveFlag = true });
            seedPeople.Add(new Person() { FirstName = "Diana", LastName = "Brooks", Interests = "streamline cross-platform initiatives", Dob = DateTime.Parse("06/20/1990"), ActiveFlag = true });
            seedPeople.Add(new Person() { FirstName = "Rebecca", LastName = "Robertson", Interests = "engage holistic niches", Dob = DateTime.Parse("03/30/1959"), ActiveFlag = true });
            seedPeople.Add(new Person() { FirstName = "Carolyn", LastName = "Roberts", Interests = "synthesize seamless e-markets", Dob = DateTime.Parse("06/26/1985"), ActiveFlag = true });
            seedPeople.Add(new Person() { FirstName = "Mildred", LastName = "Brown", Interests = "transform 24/365 bandwidth", Dob = DateTime.Parse("06/13/1972"), ActiveFlag = true });
            seedPeople.Add(new Person() { FirstName = "Samuel", LastName = "Wilson", Interests = "repurpose 24/7 methodologies", Dob = DateTime.Parse("12/15/1952"), ActiveFlag = true });
            seedPeople.Add(new Person() { FirstName = "Phyllis", LastName = "Howell", Interests = "engage e-business methodologies", Dob = DateTime.Parse("07/08/1987"), ActiveFlag = true });
            seedPeople.Add(new Person() { FirstName = "Joan", LastName = "Carpenter", Interests = "matrix extensible applications", Dob = DateTime.Parse("05/28/1944"), ActiveFlag = true });
            seedPeople.Add(new Person() { FirstName = "Wanda", LastName = "Davis", Interests = "syndicate unusual users", Dob = DateTime.Parse("11/02/1956"), ActiveFlag = true });
            seedPeople.Add(new Person() { FirstName = "Martin", LastName = "Murphy", Interests = "whiteboard extensible interfaces", Dob = DateTime.Parse("09/18/1988"), ActiveFlag = true });
            seedPeople.Add(new Person() { FirstName = "Amanda", LastName = "Robinson", Interests = "facilitate extensible partnerships", Dob = DateTime.Parse("12/14/1965"), ActiveFlag = true });
            seedPeople.Add(new Person() { FirstName = "Jimmy", LastName = "Garcia", Interests = "embrace cross-platform interfaces", Dob = DateTime.Parse("08/31/1983"), ActiveFlag = true });
            seedPeople.Add(new Person() { FirstName = "Kimberly", LastName = "Howell", Interests = "reinvent user-centric supply-chains", Dob = DateTime.Parse("09/04/1959"), ActiveFlag = true });
            seedPeople.Add(new Person() { FirstName = "Henry", LastName = "Simpson", Interests = "generate 24/365 niches", Dob = DateTime.Parse("09/19/1988"), ActiveFlag = true });
            seedPeople.Add(new Person() { FirstName = "Daniel", LastName = "Fernandez", Interests = "repurpose dot-com content", Dob = DateTime.Parse("12/14/1942"), ActiveFlag = true });
            seedPeople.Add(new Person() { FirstName = "Jessica", LastName = "Hansen", Interests = "repurpose revolutionary models", Dob = DateTime.Parse("02/01/1963"), ActiveFlag = true });
            seedPeople.Add(new Person() { FirstName = "Susan", LastName = "Andrews", Interests = "e-enable revolutionary users", Dob = DateTime.Parse("05/11/1952"), ActiveFlag = true });
            seedPeople.Add(new Person() { FirstName = "Emily", LastName = "Dunn", Interests = "revolutionize real-time paradigms", Dob = DateTime.Parse("10/14/1973"), ActiveFlag = true });
            seedPeople.Add(new Person() { FirstName = "Wanda", LastName = "Simpson", Interests = "synergize end-to-end interfaces", Dob = DateTime.Parse("06/18/1958"), ActiveFlag = true });
            seedPeople.Add(new Person() { FirstName = "Martha", LastName = "Carr", Interests = "maximize granular functionalities", Dob = DateTime.Parse("03/28/1984"), ActiveFlag = true });
            seedPeople.Add(new Person() { FirstName = "Rachel", LastName = "Wheeler", Interests = "synthesize visionary partnerships", Dob = DateTime.Parse("11/06/1955"), ActiveFlag = true });
            seedPeople.Add(new Person() { FirstName = "Antonio", LastName = "Martinez", Interests = "transform leading-edge vortals", Dob = DateTime.Parse("07/20/1962"), ActiveFlag = true });
            seedPeople.Add(new Person() { FirstName = "Anna", LastName = "Simmons", Interests = "strategize plug-and-play networks", Dob = DateTime.Parse("05/23/1968"), ActiveFlag = true });
            seedPeople.Add(new Person() { FirstName = "Ernest", LastName = "Olson", Interests = "extend cross-media vortals", Dob = DateTime.Parse("05/20/1949"), ActiveFlag = true });
            seedPeople.Add(new Person() { FirstName = "Sean", LastName = "Brown", Interests = "iterate robust paradigms", Dob = DateTime.Parse("03/31/1976"), ActiveFlag = true });
            seedPeople.Add(new Person() { FirstName = "Ashley", LastName = "Stephens", Interests = "streamline robust solutions", Dob = DateTime.Parse("08/24/1952"), ActiveFlag = true });
            seedPeople.Add(new Person() { FirstName = "Jason", LastName = "Price", Interests = "deploy B2C e-tailers", Dob = DateTime.Parse("04/09/1975"), ActiveFlag = true });
            seedPeople.Add(new Person() { FirstName = "Brandon", LastName = "Black", Interests = "brand customized e-markets", Dob = DateTime.Parse("03/05/1978"), ActiveFlag = true });
            seedPeople.Add(new Person() { FirstName = "Mark", LastName = "Fuller", Interests = "leverage vertical e-business", Dob = DateTime.Parse("12/16/1974"), ActiveFlag = true });
            seedPeople.Add(new Person() { FirstName = "Judy", LastName = "West", Interests = "leverage e-business web-readiness", Dob = DateTime.Parse("01/02/1946"), ActiveFlag = true });
            seedPeople.Add(new Person() { FirstName = "Jimmy", LastName = "Phillips", Interests = "syndicate vertical e-commerce", Dob = DateTime.Parse("08/20/1981"), ActiveFlag = true });
            seedPeople.Add(new Person() { FirstName = "Cynthia", LastName = "Boyd", Interests = "innovate e-business convergence", Dob = DateTime.Parse("03/12/1943"), ActiveFlag = true });
            seedPeople.Add(new Person() { FirstName = "Carl", LastName = "Graham", Interests = "orchestrate holistic e-business", Dob = DateTime.Parse("02/12/1978"), ActiveFlag = true });
            seedPeople.Add(new Person() { FirstName = "Paul", LastName = "Gordon", Interests = "optimize cross-platform web-readiness", Dob = DateTime.Parse("01/25/1952"), ActiveFlag = true });
            seedPeople.Add(new Person() { FirstName = "Jean", LastName = "Walker", Interests = "visualize holistic applications", Dob = DateTime.Parse("02/15/1982"), ActiveFlag = true });
            seedPeople.Add(new Person() { FirstName = "Walter", LastName = "Kelley", Interests = "strategize real-time infomediaries", Dob = DateTime.Parse("04/24/1943"), ActiveFlag = true });
            seedPeople.Add(new Person() { FirstName = "Robin", LastName = "Hamilton", Interests = "orchestrate one-to-one communities", Dob = DateTime.Parse("01/30/1950"), ActiveFlag = true });
            seedPeople.Add(new Person() { FirstName = "Virginia", LastName = "Mendoza", Interests = "drive transparent metrics", Dob = DateTime.Parse("05/09/1990"), ActiveFlag = true });
            seedPeople.Add(new Person() { FirstName = "Nancy", LastName = "Robinson", Interests = "reinvent extensible markets", Dob = DateTime.Parse("12/23/1988"), ActiveFlag = true });
            seedPeople.Add(new Person() { FirstName = "Julie", LastName = "Fernandez", Interests = "expedite leading-edge schemas", Dob = DateTime.Parse("09/30/1959"), ActiveFlag = true });
            seedPeople.Add(new Person() { FirstName = "David", LastName = "Montgomery", Interests = "embrace user-centric methodologies", Dob = DateTime.Parse("12/05/1972"), ActiveFlag = true });
            seedPeople.Add(new Person() { FirstName = "Karen", LastName = "Carroll", Interests = "reinvent revolutionary deliverables", Dob = DateTime.Parse("09/10/1979"), ActiveFlag = true });
            seedPeople.Add(new Person() { FirstName = "Adam", LastName = "Tucker", Interests = "streamline intuitive metrics", Dob = DateTime.Parse("07/12/1961"), ActiveFlag = true });
            seedPeople.Add(new Person() { FirstName = "James", LastName = "Stevens", Interests = "recontextualize integrated e-services", Dob = DateTime.Parse("07/16/1952"), ActiveFlag = true });
            seedPeople.Add(new Person() { FirstName = "Catherine", LastName = "Wagner", Interests = "orchestrate global models", Dob = DateTime.Parse("04/05/1968"), ActiveFlag = true });
            seedPeople.Add(new Person() { FirstName = "Jesse", LastName = "Allen", Interests = "transform 24/7 content", Dob = DateTime.Parse("12/01/1963"), ActiveFlag = true });
            seedPeople.Add(new Person() { FirstName = "Ronald", LastName = "Weaver", Interests = "synergize extensible interfaces", Dob = DateTime.Parse("07/08/1942"), ActiveFlag = true });
            seedPeople.Add(new Person() { FirstName = "Janet", LastName = "Welch", Interests = "architect collaborative networks", Dob = DateTime.Parse("11/25/1983"), ActiveFlag = true });
            seedPeople.Add(new Person() { FirstName = "Clarence", LastName = "Warren", Interests = "enhance dot-com supply-chains", Dob = DateTime.Parse("06/10/1972"), ActiveFlag = true });
            seedPeople.Add(new Person() { FirstName = "Shawn", LastName = "Butler", Interests = "brand cross-platform content", Dob = DateTime.Parse("09/21/1985"), ActiveFlag = true });
            seedPeople.Add(new Person() { FirstName = "Andrew", LastName = "Carter", Interests = "strategize global eyeballs", Dob = DateTime.Parse("05/16/1958"), ActiveFlag = true });
            seedPeople.Add(new Person() { FirstName = "Kathleen", LastName = "Pierce", Interests = "deploy bleeding-edge mindshare", Dob = DateTime.Parse("10/08/1974"), ActiveFlag = true });
            seedPeople.Add(new Person() { FirstName = "Jack", LastName = "Hart", Interests = "aggregate frictionless experiences", Dob = DateTime.Parse("12/25/1946"), ActiveFlag = true });
            seedPeople.Add(new Person() { FirstName = "Michelle", LastName = "White", Interests = "architect clicks-and-mortar channels", Dob = DateTime.Parse("10/28/1957"), ActiveFlag = true });
            seedPeople.Add(new Person() { FirstName = "Jeremy", LastName = "Morgan", Interests = "synthesize open-source e-markets", Dob = DateTime.Parse("03/13/1969"), ActiveFlag = true });
            seedPeople.Add(new Person() { FirstName = "Clarence", LastName = "Brown", Interests = "e-enable plug-and-play methodologies", Dob = DateTime.Parse("07/22/1952"), ActiveFlag = true });
            seedPeople.Add(new Person() { FirstName = "Jerry", LastName = "Gibson", Interests = "innovate one-to-one systems", Dob = DateTime.Parse("03/03/1973"), ActiveFlag = true });
            seedPeople.Add(new Person() { FirstName = "Tammy", LastName = "Hernandez", Interests = "maximize enterprise web services", Dob = DateTime.Parse("04/07/1982"), ActiveFlag = true });
            seedPeople.Add(new Person() { FirstName = "Christopher", LastName = "Peters", Interests = "synthesize scalable applications", Dob = DateTime.Parse("01/05/1960"), ActiveFlag = true });
            seedPeople.Add(new Person() { FirstName = "Angela", LastName = "Berry", Interests = "target holistic content", Dob = DateTime.Parse("10/25/1949"), ActiveFlag = true });
            seedPeople.Add(new Person() { FirstName = "Diana", LastName = "Richardson", Interests = "scale dot-com functionalities", Dob = DateTime.Parse("01/04/1947"), ActiveFlag = true });
            seedPeople.Add(new Person() { FirstName = "Mildred", LastName = "Reid", Interests = "scale killer convergence", Dob = DateTime.Parse("03/27/1970"), ActiveFlag = true });
            seedPeople.Add(new Person() { FirstName = "Joseph", LastName = "Duncan", Interests = "productize bleeding-edge experiences", Dob = DateTime.Parse("11/19/1963"), ActiveFlag = true });
            seedPeople.Add(new Person() { FirstName = "Brandon", LastName = "Morgan", Interests = "visualize integrated niches", Dob = DateTime.Parse("03/28/1981"), ActiveFlag = true });
            seedPeople.Add(new Person() { FirstName = "Alan", LastName = "Riley", Interests = "repurpose viral content", Dob = DateTime.Parse("05/31/1952"), ActiveFlag = true });
            seedPeople.Add(new Person() { FirstName = "Christine", LastName = "Mitchell", Interests = "aggregate impactful infomediaries", Dob = DateTime.Parse("05/12/1980"), ActiveFlag = true });
            seedPeople.Add(new Person() { FirstName = "Martin", LastName = "Hall", Interests = "synergize web-enabled web services", Dob = DateTime.Parse("10/01/1960"), ActiveFlag = true });
            seedPeople.Add(new Person() { FirstName = "Michael", LastName = "Morgan", Interests = "visualize holistic action-items", Dob = DateTime.Parse("01/24/1966"), ActiveFlag = true });
            seedPeople.Add(new Person() { FirstName = "Jeremy", LastName = "Gilbert", Interests = "implement frictionless vortals", Dob = DateTime.Parse("12/14/1982"), ActiveFlag = true });
            seedPeople.Add(new Person() { FirstName = "Craig", LastName = "Lawrence", Interests = "revolutionize turn-key e-services", Dob = DateTime.Parse("10/31/1988"), ActiveFlag = true });
            seedPeople.Add(new Person() { FirstName = "Jeffrey", LastName = "Walker", Interests = "facilitate integrated synergies", Dob = DateTime.Parse("04/01/1948"), ActiveFlag = true });
            seedPeople.Add(new Person() { FirstName = "Christine", LastName = "Barnes", Interests = "reintermediate dot-com channels", Dob = DateTime.Parse("07/08/1981"), ActiveFlag = true });
            seedPeople.Add(new Person() { FirstName = "Theresa", LastName = "Hudson", Interests = "benchmark cross-platform relationships", Dob = DateTime.Parse("09/21/1989"), ActiveFlag = true });
            seedPeople.Add(new Person() { FirstName = "Evelyn", LastName = "Hall", Interests = "integrate best-of-breed markets", Dob = DateTime.Parse("05/10/1978"), ActiveFlag = true });
            seedPeople.Add(new Person() { FirstName = "Jerry", LastName = "West", Interests = "e-enable sticky interfaces", Dob = DateTime.Parse("07/27/1961"), ActiveFlag = true });
            seedPeople.Add(new Person() { FirstName = "Diane", LastName = "Simpson", Interests = "target scalable channels", Dob = DateTime.Parse("07/28/1974"), ActiveFlag = true });

            foreach (Person seedPerson in seedPeople)
                context.People.Add(seedPerson);

            base.Seed(context);
        }
    }
}