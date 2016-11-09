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
            // This method will be called after running the Update-Database command.
            // Normally you'd want to use Ids or something safer than first/last name matches to prevent duplicates
            // but this is a quick demo and it's easy enough to delete and recreate the database.

            // update seed data as needed
            context.People.AddOrUpdate(
              p => new { p.FirstName, p.LastName },
                new Person() { FirstName = "Adam", LastName = "Tucker", Interests = "Volunteer, Geek, Database Wrangler, Green building lover, Tape therapist. I'm real, I hope my followers are too.", Dob = DateTime.Parse("11/16/1950"), ActiveFlag = true },
                new Person() { FirstName = "Alan", LastName = "Riley", Interests = "Misanthrope, Musician, Avid Gamer, Saviour of Mankind, Like Neo from 'The Matrix', but less terrible.. Thank you hand sanitizer for letting me know that I have a cut in my hand.", Dob = DateTime.Parse("01/20/1956"), ActiveFlag = true },
                new Person() { FirstName = "Amanda", LastName = "Robinson", Interests = "Rambler, Communicator, Avid Baker, Wearer of unrelated hats, King of the Forest. I get mini heart attacks when my wallet isn't in my pocket.", Dob = DateTime.Parse("05/06/1970"), ActiveFlag = true },
                new Person() { FirstName = "Andrew", LastName = "Carter", Interests = "Citizen, Chef, Friends of Animals, Cultural Mythologist, Walking Organ Donor. Hitting things to make them work.", Dob = DateTime.Parse("08/29/1964"), ActiveFlag = true },
                new Person() { FirstName = "Angela", LastName = "Berry", Interests = "Doctor, Editor, Idea Diva, Connector of Awesomeness, Wet blanket. I have a car for each day of the month.", Dob = DateTime.Parse("03/26/1952"), ActiveFlag = true },
                new Person() { FirstName = "Anna", LastName = "Simmons", Interests = "Musician, Genius, Choco-holic, World Traveler, Replacement President of a Major Soft Drink Manufacturer. I speak lorem ipsum", Dob = DateTime.Parse("10/17/1985"), ActiveFlag = true },
                new Person() { FirstName = "Antonio", LastName = "Martinez", Interests = "Alcoholic, Avatar, Social Media Guru, Beer Fanatic, Terminator. Is this water dry?.", Dob = DateTime.Parse("03/15/1963"), ActiveFlag = true },
                new Person() { FirstName = "Ashley", LastName = "Stephens", Interests = "Citizen, Communicator, World's Pickiest Vegetarian, Founder of People, Wet blanket. I own 25 hoolahoops.", Dob = DateTime.Parse("10/07/1980"), ActiveFlag = true },
                new Person() { FirstName = "Beverly", LastName = "Butler", Interests = "Storyfinder, Researcher, Domestic Diva, Political Activist, Terminator. I sip water quite slowly.", Dob = DateTime.Parse("12/12/1967"), ActiveFlag = true },
                new Person() { FirstName = "Beverly", LastName = "Mitchell", Interests = "Dancer, Learner, Domestic Diva, Strategic Storyteller, Tape therapist. I drop my phone on my face when texting laying down.", Dob = DateTime.Parse("01/21/1962"), ActiveFlag = true },
                new Person() { FirstName = "Brandon", LastName = "Black", Interests = "Producer, Achiever, Sock Hater, Database Wrangler, Unwashed Mass. I unleashed the zombie apocalypse.", Dob = DateTime.Parse("08/06/1984"), ActiveFlag = true },
                new Person() { FirstName = "Brandon", LastName = "Morgan", Interests = "Gambler, Fan, Data Visualizer, Trends Addict, Twitteratti. I used to think that you could just go to the bank and ask for money.", Dob = DateTime.Parse("06/20/1973"), ActiveFlag = true },
                new Person() { FirstName = "Carl", LastName = "Graham", Interests = "Disrupter, Geek, Fire Spinner, Chihuahua Lover, Mayonaise Tester. My life is the first half of a Spider Man movie.", Dob = DateTime.Parse("12/07/1970"), ActiveFlag = true },
                new Person() { FirstName = "Carolyn", LastName = "Roberts", Interests = "Chef, Geek, Aspiring Yogi, Creator of Systems, Your long lost twin. I feed my cats poptarts.", Dob = DateTime.Parse("01/02/1944"), ActiveFlag = true },
                new Person() { FirstName = "Catherine", LastName = "Wagner", Interests = "Extreme creator. Total gamer. Internet expert. Twitter nerd. Professional food fanatic.", Dob = DateTime.Parse("05/06/1944"), ActiveFlag = true },
                new Person() { FirstName = "Christine", LastName = "Mitchell", Interests = "Freelance tv fan. Twitter maven. Gamer. Pop culture lover. Zombie expert. Music advocate. Explorer.", Dob = DateTime.Parse("01/16/1963"), ActiveFlag = true },
                new Person() { FirstName = "Christine", LastName = "Barnes", Interests = "Avid bacon nerd. Food guru. Amateur alcohol practitioner. Passionate zombie ninja.", Dob = DateTime.Parse("05/05/1959"), ActiveFlag = true },
                new Person() { FirstName = "Christopher", LastName = "Peters", Interests = "Passionate twitter guru. Hardcore coffee fan. Certified zombie fanatic. Tv enthusiast.", Dob = DateTime.Parse("11/24/1960"), ActiveFlag = true },
                new Person() { FirstName = "Clarence", LastName = "Warren", Interests = "enhance dot-com supply-chains", Dob = DateTime.Parse("09/01/1988"), ActiveFlag = true },
                new Person() { FirstName = "Clarence", LastName = "Brown", Interests = "e-enable plug-and-play methodologies", Dob = DateTime.Parse("03/18/1985"), ActiveFlag = true },
                new Person() { FirstName = "Craig", LastName = "Lawrence", Interests = "revolutionize turn-key e-services", Dob = DateTime.Parse("04/05/1965"), ActiveFlag = true },
                new Person() { FirstName = "Cynthia", LastName = "Boyd", Interests = "innovate e-business convergence", Dob = DateTime.Parse("08/05/1941"), ActiveFlag = true },
                new Person() { FirstName = "Daniel", LastName = "Fernandez", Interests = "repurpose dot-com content", Dob = DateTime.Parse("04/01/1949"), ActiveFlag = true },
                new Person() { FirstName = "David", LastName = "Snyder", Interests = "revolutionize killer experiences", Dob = DateTime.Parse("11/24/1966"), ActiveFlag = true },
                new Person() { FirstName = "David", LastName = "Montgomery", Interests = "embrace user-centric methodologies", Dob = DateTime.Parse("06/24/1973"), ActiveFlag = true },
                new Person() { FirstName = "Diana", LastName = "Brooks", Interests = "streamline cross-platform initiatives", Dob = DateTime.Parse("11/01/1959"), ActiveFlag = true },
                new Person() { FirstName = "Diana", LastName = "Richardson", Interests = "scale dot-com functionalities", Dob = DateTime.Parse("02/11/1982"), ActiveFlag = true },
                new Person() { FirstName = "Diane", LastName = "Simpson", Interests = "target scalable channels", Dob = DateTime.Parse("07/20/1944"), ActiveFlag = true },
                new Person() { FirstName = "Emily", LastName = "Dunn", Interests = "revolutionize real-time paradigms", Dob = DateTime.Parse("05/22/1984"), ActiveFlag = true },
                new Person() { FirstName = "Ernest", LastName = "Thomas", Interests = "envisioneer leading-edge models", Dob = DateTime.Parse("03/25/1972"), ActiveFlag = true },
                new Person() { FirstName = "Ernest", LastName = "Turner", Interests = "visualize extensible users", Dob = DateTime.Parse("04/28/1984"), ActiveFlag = true },
                new Person() { FirstName = "Ernest", LastName = "Olson", Interests = "extend cross-media vortals", Dob = DateTime.Parse("04/06/1942"), ActiveFlag = true },
                new Person() { FirstName = "Eugene", LastName = "Cox", Interests = "syndicate world-class relationships", Dob = DateTime.Parse("06/09/1962"), ActiveFlag = true },
                new Person() { FirstName = "Evelyn", LastName = "Martinez", Interests = "brand dynamic niches", Dob = DateTime.Parse("02/19/1945"), ActiveFlag = true },
                new Person() { FirstName = "Evelyn", LastName = "Hall", Interests = "integrate best-of-breed markets", Dob = DateTime.Parse("10/26/1979"), ActiveFlag = true },
                new Person() { FirstName = "Gary", LastName = "Austin", Interests = "redefine value-added partnerships", Dob = DateTime.Parse("08/21/1950"), ActiveFlag = true },
                new Person() { FirstName = "Henry", LastName = "Simpson", Interests = "generate 24/365 niches", Dob = DateTime.Parse("05/27/1954"), ActiveFlag = true },
                new Person() { FirstName = "Howard", LastName = "Mason", Interests = "e-enable compelling methodologies", Dob = DateTime.Parse("06/17/1941"), ActiveFlag = true },
                new Person() { FirstName = "Jack", LastName = "Hart", Interests = "aggregate frictionless experiences", Dob = DateTime.Parse("08/18/1964"), ActiveFlag = true },
                new Person() { FirstName = "James", LastName = "Stevens", Interests = "recontextualize integrated e-services", Dob = DateTime.Parse("09/20/1984"), ActiveFlag = true },
                new Person() { FirstName = "Janet", LastName = "Welch", Interests = "architect collaborative networks", Dob = DateTime.Parse("04/28/1978"), ActiveFlag = true },
                new Person() { FirstName = "Jason", LastName = "Price", Interests = "deploy B2C e-tailers", Dob = DateTime.Parse("03/10/1964"), ActiveFlag = true },
                new Person() { FirstName = "Jeanie", LastName = "Walker", Interests = "seize collaborative applications", Dob = DateTime.Parse("07/10/1965"), ActiveFlag = true },
                new Person() { FirstName = "Jean", LastName = "Walker", Interests = "visualize holistic applications", Dob = DateTime.Parse("02/21/1967"), ActiveFlag = true },
                new Person() { FirstName = "Jeffrey", LastName = "Walker", Interests = "facilitate integrated synergies", Dob = DateTime.Parse("02/07/1962"), ActiveFlag = true },
                new Person() { FirstName = "Jennifer", LastName = "Webb", Interests = "deliver user-centric eyeballs", Dob = DateTime.Parse("09/17/1976"), ActiveFlag = true },
                new Person() { FirstName = "Jeremy", LastName = "Morgan", Interests = "synthesize open-source e-markets", Dob = DateTime.Parse("05/08/1984"), ActiveFlag = true },
                new Person() { FirstName = "Jeremy", LastName = "Gilbert", Interests = "implement frictionless vortals", Dob = DateTime.Parse("10/24/1947"), ActiveFlag = true },
                new Person() { FirstName = "Jerry", LastName = "Gibson", Interests = "innovate one-to-one systems", Dob = DateTime.Parse("07/19/1958"), ActiveFlag = true },
                new Person() { FirstName = "Jerry", LastName = "West", Interests = "e-enable sticky interfaces", Dob = DateTime.Parse("03/15/1987"), ActiveFlag = true },
                new Person() { FirstName = "Jesse", LastName = "Allen", Interests = "transform 24/7 content", Dob = DateTime.Parse("03/04/1988"), ActiveFlag = true },
                new Person() { FirstName = "Jessica", LastName = "Hansen", Interests = "repurpose revolutionary models", Dob = DateTime.Parse("05/05/1981"), ActiveFlag = true },
                new Person() { FirstName = "Jimmy", LastName = "Garcia", Interests = "embrace cross-platform interfaces", Dob = DateTime.Parse("04/25/1962"), ActiveFlag = true },
                new Person() { FirstName = "Jimmy", LastName = "Phillips", Interests = "syndicate vertical e-commerce", Dob = DateTime.Parse("04/26/1985"), ActiveFlag = true },
                new Person() { FirstName = "Joan", LastName = "Carpenter", Interests = "matrix extensible applications", Dob = DateTime.Parse("10/09/1969"), ActiveFlag = true },
                new Person() { FirstName = "Joseph", LastName = "Duncan", Interests = "productize bleeding-edge experiences", Dob = DateTime.Parse("11/15/1987"), ActiveFlag = true },
                new Person() { FirstName = "Judith", LastName = "Dunn", Interests = "enhance real-time action-items", Dob = DateTime.Parse("07/11/1960"), ActiveFlag = true },
                new Person() { FirstName = "Judith", LastName = "Hudson", Interests = "productize customized communities", Dob = DateTime.Parse("04/25/1957"), ActiveFlag = true },
                new Person() { FirstName = "Judy", LastName = "West", Interests = "leverage e-business web-readiness", Dob = DateTime.Parse("07/27/1956"), ActiveFlag = true },
                new Person() { FirstName = "Julie", LastName = "Harper", Interests = "leverage value-added applications", Dob = DateTime.Parse("02/12/1960"), ActiveFlag = true },
                new Person() { FirstName = "Julie", LastName = "Fernandez", Interests = "expedite leading-edge schemas", Dob = DateTime.Parse("02/03/1976"), ActiveFlag = true },
                new Person() { FirstName = "Karen", LastName = "Carroll", Interests = "reinvent revolutionary deliverables", Dob = DateTime.Parse("09/03/1956"), ActiveFlag = true },
                new Person() { FirstName = "Kathleen", LastName = "Pierce", Interests = "deploy bleeding-edge mindshare", Dob = DateTime.Parse("04/15/1943"), ActiveFlag = true },
                new Person() { FirstName = "Kimberly", LastName = "Olson", Interests = "morph bricks-and-clicks niches", Dob = DateTime.Parse("02/28/1949"), ActiveFlag = true },
                new Person() { FirstName = "Kimberly", LastName = "Howell", Interests = "reinvent user-centric supply-chains", Dob = DateTime.Parse("10/04/1973"), ActiveFlag = true },
                new Person() { FirstName = "Lillian", LastName = "Rogers", Interests = "target interactive eyeballs", Dob = DateTime.Parse("07/22/1985"), ActiveFlag = true },
                new Person() { FirstName = "Lillian", LastName = "Lynch", Interests = "scale viral communities", Dob = DateTime.Parse("10/03/1962"), ActiveFlag = true },
                new Person() { FirstName = "Marie", LastName = "Shaw", Interests = "recontextualize value-added applications", Dob = DateTime.Parse("10/04/1964"), ActiveFlag = true },
                new Person() { FirstName = "Mark", LastName = "Lawrence", Interests = "synergize impressive interfaces", Dob = DateTime.Parse("12/12/1980"), ActiveFlag = true },
                new Person() { FirstName = "Mark", LastName = "Fuller", Interests = "leverage vertical e-business", Dob = DateTime.Parse("07/16/1961"), ActiveFlag = true },
                new Person() { FirstName = "Martha", LastName = "Carr", Interests = "maximize granular functionalities", Dob = DateTime.Parse("04/07/1972"), ActiveFlag = true },
                new Person() { FirstName = "Martin", LastName = "Murphy", Interests = "whiteboard extensible interfaces", Dob = DateTime.Parse("10/25/1967"), ActiveFlag = true },
                new Person() { FirstName = "Martin", LastName = "Hall", Interests = "synergize web-enabled web services", Dob = DateTime.Parse("01/08/1946"), ActiveFlag = true },
                new Person() { FirstName = "Michael", LastName = "Morgan", Interests = "visualize holistic action-items", Dob = DateTime.Parse("05/29/1978"), ActiveFlag = true },
                new Person() { FirstName = "Michelle", LastName = "White", Interests = "architect clicks-and-mortar channels", Dob = DateTime.Parse("08/23/1959"), ActiveFlag = true },
                new Person() { FirstName = "Mildred", LastName = "Brown", Interests = "transform 24/365 bandwidth", Dob = DateTime.Parse("04/06/1972"), ActiveFlag = true },
                new Person() { FirstName = "Mildred", LastName = "Reid", Interests = "scale killer convergence", Dob = DateTime.Parse("05/28/1979"), ActiveFlag = true },
                new Person() { FirstName = "Nancy", LastName = "Robinson", Interests = "reinvent extensible markets", Dob = DateTime.Parse("03/14/1960"), ActiveFlag = true },
                new Person() { FirstName = "Paul", LastName = "Gordon", Interests = "optimize cross-platform web-readiness", Dob = DateTime.Parse("10/28/1960"), ActiveFlag = true },
                new Person() { FirstName = "Phyllis", LastName = "Howell", Interests = "engage e-business methodologies", Dob = DateTime.Parse("07/02/1961"), ActiveFlag = true },
                new Person() { FirstName = "Rachel", LastName = "Wheeler", Interests = "synthesize visionary partnerships", Dob = DateTime.Parse("04/06/1955"), ActiveFlag = true },
                new Person() { FirstName = "Rebecca", LastName = "Robertson", Interests = "engage holistic niches", Dob = DateTime.Parse("03/11/1989"), ActiveFlag = true },
                new Person() { FirstName = "Richard", LastName = "Russell", Interests = "disintermediate global infrastructures", Dob = DateTime.Parse("04/27/1977"), ActiveFlag = true },
                new Person() { FirstName = "Robin", LastName = "Hamilton", Interests = "orchestrate one-to-one communities", Dob = DateTime.Parse("05/04/1983"), ActiveFlag = true },
                new Person() { FirstName = "Roger", LastName = "Chavez", Interests = "deploy robust communities", Dob = DateTime.Parse("11/07/1979"), ActiveFlag = true },
                new Person() { FirstName = "Ronald", LastName = "Weaver", Interests = "synergize extensible interfaces", Dob = DateTime.Parse("01/16/1952"), ActiveFlag = true },
                new Person() { FirstName = "Rose", LastName = "Fields", Interests = "engage clicks-and-mortar schemas", Dob = DateTime.Parse("02/25/1965"), ActiveFlag = true },
                new Person() { FirstName = "Ryan", LastName = "Bradley", Interests = "maximize end-to-end models", Dob = DateTime.Parse("07/28/1968"), ActiveFlag = true },
                new Person() { FirstName = "Ryan", LastName = "Shaw", Interests = "incentivize user-centric applications", Dob = DateTime.Parse("08/28/1961"), ActiveFlag = true },
                new Person() { FirstName = "Samuel", LastName = "Wilson", Interests = "repurpose 24/7 methodologies", Dob = DateTime.Parse("02/18/1945"), ActiveFlag = true },
                new Person() { FirstName = "Sean", LastName = "Brown", Interests = "iterate robust paradigms", Dob = DateTime.Parse("01/29/1984"), ActiveFlag = true },
                new Person() { FirstName = "Shawn", LastName = "Butler", Interests = "brand cross-platform content", Dob = DateTime.Parse("04/05/1990"), ActiveFlag = true },
                new Person() { FirstName = "Susan", LastName = "Andrews", Interests = "e-enable revolutionary users", Dob = DateTime.Parse("07/31/1942"), ActiveFlag = true },
                new Person() { FirstName = "Tammy", LastName = "Miller", Interests = "visualize revolutionary interfaces", Dob = DateTime.Parse("09/28/1940"), ActiveFlag = true },
                new Person() { FirstName = "Tammy", LastName = "Hernandez", Interests = "maximize enterprise web services", Dob = DateTime.Parse("12/19/1940"), ActiveFlag = true },
                new Person() { FirstName = "Theresa", LastName = "Hudson", Interests = "benchmark cross-platform relationships", Dob = DateTime.Parse("01/29/1947"), ActiveFlag = true },
                new Person() { FirstName = "Virginia", LastName = "Mendoza", Interests = "drive transparent metrics", Dob = DateTime.Parse("12/29/1963"), ActiveFlag = true },
                new Person() { FirstName = "Walter", LastName = "Kelley", Interests = "strategize real-time infomediaries", Dob = DateTime.Parse("09/18/1964"), ActiveFlag = true },
                new Person() { FirstName = "Wanda", LastName = "Davis", Interests = "syndicate unusual users", Dob = DateTime.Parse("01/12/1990"), ActiveFlag = true },
                new Person() { FirstName = "Wanda", LastName = "Simpson", Interests = "synergize end-to-end interfaces", Dob = DateTime.Parse("05/13/1951"), ActiveFlag = true }
            );
        }
    }
}
