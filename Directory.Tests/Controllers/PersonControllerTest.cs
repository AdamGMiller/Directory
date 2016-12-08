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
using System.Web.Http.Results;
using System.Web.Http.Hosting;
using System.Net;

namespace Directory.Tests.Controllers
{
    [TestClass]
    public class PersonControllerTest
    {
        private IList<Person> people;

        [TestInitialize]
        public void Setup()
        {
            // generate list of test data
            people = new List<Person>
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
        }
        
        [TestMethod]
        public void GetInvalidItemFromControllerReturnsNotFound()
        {
            // Arrange
            var mockRepository = new Mock<IPersonRepository>();
            mockRepository.Setup(x => x.Exists(2))
                .Returns(false);
            var controller = new PersonController(mockRepository.Object);

            // Act
            var actionResult = controller.Get(2);
            var negativeResult = actionResult as NegotiatedContentResult<string>;

            // Assert
            Assert.IsNotNull(negativeResult);
            Assert.AreEqual("Person 2 not found.", negativeResult.Content);
            Assert.AreEqual(HttpStatusCode.NotFound, negativeResult.StatusCode);
        }

        [TestMethod]
        public void DeleteInvalidItemFromControllerReturnsNotFound()
        {
            // Arrange
            var mockRepository = new Mock<IPersonRepository>();
            mockRepository.Setup(x => x.Exists(2))
                .Returns(false);
            var controller = new PersonController(mockRepository.Object);

            // Act
            var actionResult = controller.Delete(2);
            var negativeResult = actionResult as NegotiatedContentResult<string>;

            // Assert
            Assert.IsNotNull(negativeResult);
            Assert.AreEqual("Person 2 not found.", negativeResult.Content);
            Assert.AreEqual(HttpStatusCode.NotFound, negativeResult.StatusCode);
        }

        [TestMethod]
        public void GetActiveItemsFromControllerReturnsPeople()
        {
            // Arrange
            var mockRepository = new Mock<IPersonRepository>();
            mockRepository.Setup(x => x.GetAll(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()))
                .Returns(people.Where(q => q.ActiveFlag == true));
            var controller = new PersonController(mockRepository.Object);

            // Act
            var actionResult = controller.GetAll(1, 20, "");

            // Assert
            var response = actionResult as OkNegotiatedContentResult<IEnumerable<Person>>;
            Assert.IsNotNull(response);
            Assert.AreEqual(12, response.Content.Count());
        }

        [TestMethod]
        public void GetSinglePageFromControllerReturnsPartialResults()
        {
            // Arrange
            var mockRepository = new Mock<IPersonRepository>();
            mockRepository.Setup(x => x.GetAll(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()))
                .Returns(people.Where(q => q.ActiveFlag == true).OrderBy(q => q.FirstName).Take(10));
            var controller = new PersonController(mockRepository.Object);

            // Act
            var actionResult = controller.GetAll(1, 10, "");

            // Assert
            var response = actionResult as OkNegotiatedContentResult<IEnumerable<Person>>;
            Assert.IsNotNull(response);
            Assert.AreEqual(10, response.Content.Count());
        }

        [TestMethod]
        public void DeleteReturnsOk()
        {
            // Arrange
            var mockRepository = new Mock<IPersonRepository>();
            var controller = new PersonController(mockRepository.Object);
            mockRepository.Setup(x => x.Exists( It.IsAny<int>()))
                .Returns(true);

            // Act
            IHttpActionResult actionResult = controller.Delete(10);

            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(OkResult));
        }

        [TestMethod]
        public void PostMethodSetsLocationHeader()
        {
            // Arrange
            var mockRepository = new Mock<IPersonRepository>();
            var controller = new PersonController(mockRepository.Object);

            // Act
            IHttpActionResult actionResult = controller.Post(people.First());
            var createdResult = actionResult as CreatedAtRouteNegotiatedContentResult<Person>;

            // Assert
            Assert.IsNotNull(createdResult);
            Assert.AreEqual("DefaultApi", createdResult.RouteName);
            Assert.AreEqual(1, createdResult.RouteValues["id"]);
        }

        [TestMethod]
        public void PutReturnsContentResult()
        {
            // Arrange
            var mockRepository = new Mock<IPersonRepository>();
            var controller = new PersonController(mockRepository.Object);
            mockRepository.Setup(x => x.Exists(It.IsAny<int>()))
                .Returns(true);

            // Act
            IHttpActionResult actionResult = controller.Put(12, new Person() { Id = 12, FirstName = "Jack", LastName = "Flash", Interests = "Test.", Dob = DateTime.Parse("1/07/1970"), ActiveFlag = true });
            var contentResult = actionResult as NegotiatedContentResult<Person>;

            // Assert
            Assert.IsNotNull(contentResult);
            Assert.AreEqual(HttpStatusCode.Accepted, contentResult.StatusCode);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(12, contentResult.Content.Id);
        }

        [TestMethod]
        public void PutWithInvalidModelReturnsError()
        {
            // Arrange
            var mockRepository = new Mock<IPersonRepository>();
            var controller = new PersonController(mockRepository.Object);
            controller.ModelState.AddModelError("error", "error");
            mockRepository.Setup(x => x.Exists(It.IsAny<int>()))
                .Returns(true);

            // Act
            IHttpActionResult actionResult = controller.Put(10, new Person());
            var negativeResult = actionResult as NegotiatedContentResult<string>;

            // Assert
            Assert.IsNotNull(negativeResult);
            Assert.AreEqual("Person model is invalid.", negativeResult.Content);
            Assert.AreEqual(HttpStatusCode.BadRequest, negativeResult.StatusCode);
        }
    }
}

