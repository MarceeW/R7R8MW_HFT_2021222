using Moq;
using NUnit.Framework;
using R7R8MW_HFT_2021222.Logic;
using R7R8MW_HFT_2021222.Models;
using R7R8MW_HFT_2021222.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R7R8MW_HFT_2021222.Test
{
    internal class LogicTester
    {
        MovieLogic movieLogic;
        PersonLogic personLogic;
        RoleLogic roleLogic;

        Mock<IRepository<Movie>> fakeMovieRepository;
        Mock<IRepository<Actor>> fakeActorRepository;
        Mock<IRepository<Director>> fakeDirectorRepository;
        Mock<IRepository<Role>> fakeRoleRepository;

        [SetUp]
        public void Init()
        {
            var movies = new List<Movie>()
            {
                new Movie("1#TestMovie 1#585,8#1#2008*05*02#7,9"),
                new Movie("2#TestMovie 2#264,8#2#2008*06*13#6,6"),
                new Movie("3#TestMovie 3#623,9#1#2010*05*07#6,9"),
                new Movie("4#TestMovie 4#449,3#3#2011*05*06#7"),
            };
            fakeMovieRepository = new Mock<IRepository<Movie>>();
            fakeMovieRepository.Setup(m=>m.ReadAll()).Returns(movies.AsQueryable());
            fakeMovieRepository.Setup(m => m.Create(It.IsAny<Movie>())).Callback((Movie movie) => movies.Add(movie)).Verifiable();
            fakeMovieRepository.Setup(m=>m.Read(It.IsAny<int>())).Returns((int i)=>movies.ElementAt(i-1));
            movieLogic = new MovieLogic(fakeMovieRepository.Object);

            var directors = new List<Director>()
            {
                new Director("1#Test One"),
                new Director("2#Test Two"),
                new Director("3#Test Three"),
            };
            fakeDirectorRepository = new Mock<IRepository<Director>>();
            fakeDirectorRepository.Setup(d => d.ReadAll()).Returns(directors.AsQueryable());
            fakeDirectorRepository.Setup(d => d.Create(It.IsAny<Director>())).Callback((Director dir) => directors.Add(dir)).Verifiable();
            fakeDirectorRepository.Setup(d => d.Read(It.IsAny<int>())).Returns((int i) => directors.ElementAt(i - 1));


            var actors = new List<Actor>()
            {
                new Actor("1#Testactor One"),
                new Actor("2#Testactor Two"),
                new Actor("3#Testactor Three")
            };
            fakeActorRepository = new Mock<IRepository<Actor>>();
            fakeActorRepository.Setup(a => a.ReadAll()).Returns(actors.AsQueryable());
            fakeActorRepository.Setup(a => a.Create(It.IsAny<Actor>())).Callback((Actor actor) => actors.Add(actor)).Verifiable();
            fakeActorRepository.Setup(a => a.Read(It.IsAny<int>())).Returns((int i) => actors.ElementAt(i - 1));
            personLogic = new PersonLogic(fakeActorRepository.Object, fakeDirectorRepository.Object);

            var roles = new List<Role>()
            {
                new Role("1#1#1#1#IronMan"),
                new Role("2#1#2#2#RoleTwo"),
                new Role("3#2#1#3#RoleThree"),
                new Role("4#2#2#4#IronMan"),
                new Role("5#3#1#5#RoleFive"),
                new Role("6#4#3#6#RoleSix"),
            };
            fakeRoleRepository = new Mock<IRepository<Role>>();
            fakeRoleRepository.Setup(r => r.ReadAll()).Returns(roles.AsQueryable());
            fakeRoleRepository.Setup(r => r.Create(It.IsAny<Role>())).Callback((Role role) => roles.Add(role)).Verifiable();
            fakeRoleRepository.Setup(r => r.Read(It.IsAny<int>())).Returns((int i) => roles.ElementAt(i - 1));
            roleLogic = new RoleLogic(fakeRoleRepository.Object);

        }
        [Test]
        public void ActorCreationTestWithNullValue()
        {
            Actor testPerson = null;

            Assert.That(()=>personLogic.Create(testPerson),Throws.TypeOf<ArgumentNullException>());
        }
        [Test]
        public void ActorCreationTestWithNegativeId()
        {
            IPerson testPerson = new Actor(){ Id = -1 };

            Assert.That(() => personLogic.Create(testPerson), Throws.TypeOf<ArgumentNullException>());
        }
        [Test]
        public void ActorCreationTest()
        {
            Actor actor = new Actor("4#TestActor Four");
            personLogic.Create(actor);

            Assert.AreEqual(personLogic.Read(4,true), actor);
        }
        [Test]
        public void DirectorCreationTest()
        {
            Director director = new Director("4#Test Four");
            personLogic.Create(director);

            Assert.AreEqual(personLogic.Read(4, false), director);
        }
        [Test]
        public void DirectorCreationTestWithNegativeId()
        {
            IPerson testPerson = new Director() { Id = -1 };

            Assert.That(() => personLogic.Create(testPerson), Throws.TypeOf<ArgumentNullException>());
        }
        [Test]
        public void DirectorCreationTestWithNullValue()
        {
            Director testPerson = null;

            Assert.That(() => personLogic.Create(testPerson), Throws.TypeOf<ArgumentNullException>());
        }
        [Test]
        public void RoleCreationTestWithNullValue()
        {
            Role testRole = null;

            Assert.That(() => roleLogic.Create(testRole), Throws.TypeOf<ArgumentNullException>());
        }
        [Test]
        public void RoleCreationTestWithNegativeId()
        {
            Role testRole = new Role() { RoleId = -1 };

            Assert.That(() => roleLogic.Create(testRole), Throws.TypeOf<ArgumentNullException>());
        }
        [Test]
        public void RoleCreationTest()
        {
            Role testRole = new Role("7#2#2#2#IronGirl");

            roleLogic.Create(testRole);

            Assert.AreEqual(roleLogic.Read(7), testRole);
        }
        [Test]
        public void MovieCreationTestWithNullValue()
        {
            Movie testMovie = null;

            Assert.That(() => movieLogic.Create(testMovie), Throws.TypeOf<ArgumentNullException>());
        }
        [Test]
        public void MovieCreationTestWithNegativeId()
        {
            Movie testMovie = new Movie() { Id = -1 };

            Assert.That(() => movieLogic.Create(testMovie), Throws.TypeOf<ArgumentNullException>());
        }
        [Test]
        public void MovieCreationTest()
        {
            Movie testMovie = new Movie("5#TestMovie 5#449,3#3#2011*05*06#7");
            movieLogic.Create(testMovie);
            var asd = movieLogic.ReadAll();
            Assert.AreEqual(movieLogic.Read(5), testMovie);
        }
        [Test]
        public void OldestMovieTest()
        {
            var expected = new List<Movie>()
            {
                new Movie("1#TestMovie 1#585,8#1#2008*05*02#7,9")
            };

            var result = movieLogic.Oldest();

            Assert.AreEqual(expected, result);
        }
        [Test]
        public void TopRatingMovieTest()
        {
            var expected = new List<Movie>()
            {
                new Movie("1#TestMovie 1#585,8#1#2008*05*02#7,9")
            };
            var result= movieLogic.TopRating();

            Assert.AreEqual(expected, result);
        }
        [Test]
        public void MoviesPerYearTest()
        {
            var expected = new List<KeyValuePair<int, List<Movie>>>()
            {
                new KeyValuePair<int, List<Movie>>(2008,
                new List<Movie>(){
                    new Movie("1#TestMovie 1#585,8#1#2008*05*02#7,9"),
                    new Movie("2#TestMovie 2#264,8#2#2008*06*13#6,6")}),
                new KeyValuePair<int, List<Movie>>(2010,
                new List<Movie>(){
                    new Movie("3#TestMovie 3#623,9#1#2010*05*07#6,9")}),
                new KeyValuePair<int, List<Movie>>(2011,
                new List<Movie>(){
                    new Movie("4#TestMovie 4#449,3#3#2011*05*06#7")})
            };
            var result=movieLogic.MoviesPerYear();
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void PersonNameStartingLetterTest()
        {
            var expected = new List<IPerson>()
            {
                new Actor("1#Testactor One"),
                new Actor("2#Testactor Two"),
                new Actor("3#Testactor Three"),
                new Director("1#Test One"),
                new Director("2#Test Two"),
                new Director("3#Test Three")
            };

            var result = personLogic.GetAllPersonWithStarting('t');
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void GetMostCommonRoleNameTest()
        {
            var expected = new List<string>() {"IronMan"};

            var result = roleLogic.GetMostCommonRoleName();

            Assert.AreEqual(expected, result);
        }
        [Test]
        public void PersonLogicUpdateTestWithNullParameter()
        {
            Assert.That(() => personLogic.Update(null), Throws.TypeOf<ArgumentNullException>());
        }
        [Test]
        public void MovieLogicUpdateTestWithNullParameter()
        {
            Assert.That(() => movieLogic.Update(null), Throws.TypeOf<ArgumentNullException>());
        }
        [Test]
        public void RoleLogicUpdateTestWithNullParameter()
        {
            Assert.That(() => roleLogic.Update(null), Throws.TypeOf<ArgumentNullException>());
        }
    }
}
