using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Directory;
using Directory.Controllers;
using Moq;
using Directory.Repository;

namespace Directory.Tests.Controllers
{
    [TestClass]
    public class PersonControllerTest
    {
        public readonly IPersonRepository MockPersonRepository;

        public PersonControllerTest()
        {
            // create some mock products to play with
            IList<Person> people = new List<Person>
                {
                    new Person() { Id = 1, FirstName = "Adam", LastName = "Tucker", Interests = "Volunteer, Geek, Database Wrangler, Green building lover, Tape therapist. I'm real, I hope my followers are too.", Dob = DateTime.Parse("11/16/1950"), ActiveFlag = true },
                    new Person() { Id = 2, FirstName = "Alan", LastName = "Riley", Interests = "Misanthrope, Musician, Avid Gamer, Saviour of Mankind, Like Neo from 'The Matrix', but less terrible.. Thank you hand sanitizer for letting me know that I have a cut in my hand.", Dob = DateTime.Parse("01/20/1956"), ActiveFlag = true },
                    new Person() { Id = 3, FirstName = "Amanda", LastName = "Robinson", Interests = "Rambler, Communicator, Avid Baker, Wearer of unrelated hats, King of the Forest. I get mini heart attacks when my wallet isn't in my pocket.", Dob = DateTime.Parse("05/06/1970"), ActiveFlag = false },
                    new Person() { Id = 4, FirstName = "Andrew", LastName = "Carter", Interests = "Citizen, Chef, Friends of Animals, Cultural Mythologist, Walking Organ Donor. Hitting things to make them work.", Dob = DateTime.Parse("08/29/1964"), ActiveFlag = true },
                    new Person() { Id = 5, FirstName = "Angela", LastName = "Berry", Interests = "Doctor, Editor, Idea Diva, Connector of Awesomeness, Wet blanket. I have a car for each day of the month.", Dob = DateTime.Parse("03/26/1952"), ActiveFlag = true },
                    new Person() { Id = 6, FirstName = "Anna", LastName = "Simmons", Interests = "Musician, Genius, Choco-holic, World Traveler, Replacement President of a Major Soft Drink Manufacturer. I speak lorem ipsum", Dob = DateTime.Parse("10/17/1985"), ActiveFlag = true },
                    new Person() { Id = 7, FirstName = "Antonio", LastName = "Martinez", Interests = "Alcoholic, Avatar, Social Media Guru, Beer Fanatic, Terminator. Is this water dry?.", Dob = DateTime.Parse("03/15/1963"), ActiveFlag = true },
                    new Person() { Id = 8, FirstName = "Ashley", LastName = "Stephens", Interests = "Citizen, Communicator, World's Pickiest Vegetarian, Founder of People, Wet blanket. I own 25 hoolahoops.", Dob = DateTime.Parse("10/07/1980"), ActiveFlag = true },
                    new Person() { Id = 9, FirstName = "Beverly", LastName = "Butler", Interests = "Storyfinder, Researcher, Domestic Diva, Political Activist, Terminator. I sip water quite slowly.", Dob = DateTime.Parse("12/12/1967"), ActiveFlag = true },
                    new Person() { Id = 10, FirstName = "Beverly", LastName = "Mitchell", Interests = "Dancer, Learner, Domestic Diva, Strategic Storyteller, Tape therapist. I drop my phone on my face when texting laying down.", Dob = DateTime.Parse("01/21/1962"), ActiveFlag = true },
                    new Person() { Id = 11, FirstName = "Brandon", LastName = "Black", Interests = "Producer, Achiever, Sock Hater, Database Wrangler, Unwashed Mass. I unleashed the zombie apocalypse.", Dob = DateTime.Parse("08/06/1984"), ActiveFlag = true },
                    new Person() { Id = 12, FirstName = "Brandon", LastName = "Morgan", Interests = "Gambler, Fan, Data Visualizer, Trends Addict, Twitteratti. I used to think that you could just go to the bank and ask for money.", Dob = DateTime.Parse("06/20/1973"), ActiveFlag = true },
                    new Person() { Id = 13, FirstName = "Carl", LastName = "Graham", Interests = "Disrupter, Geek, Fire Spinner, Chihuahua Lover, Mayonaise Tester. My life is the first half of a Spider Man movie.", Dob = DateTime.Parse("12/07/1970"), ActiveFlag = true }
                };

            // Mock the Products Repository using Moq
            Mock<IPersonRepository> mockPersonRepository = new Mock<IPersonRepository>();

            // Return the first page of people
            int page = 1;
            int pageSize = 10;
            mockPersonRepository.Setup(mr => mr.GetAll(page, pageSize, "")).Returns(people.OrderBy(q => q.FirstName).Take(pageSize));

            // return a person by Id
            mockPersonRepository.Setup(mr => mr.Get(It.IsAny<int>())).Returns((int i) => people.Where(x => x.Id == i).Single());

            // Complete the setup of our Mock Product Repository
            this.MockPersonRepository = mockPersonRepository.Object;
        }

        [TestMethod]
        public void CanReturnProductById()
        {
            // Try finding a product by id
            Person testPerson = this.MockPersonRepository.Get(2);

            Assert.IsNotNull(testPerson); // Test if null
            Assert.IsInstanceOfType(testPerson, typeof(Person)); // Test type
            Assert.AreEqual("Alan", testPerson.FirstName); // Verify it is the right product
        }
    }
}

