﻿using Moq;
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
            }.AsQueryable();
            fakeMovieRepository = new Mock<IRepository<Movie>>();
            fakeMovieRepository.Setup(m=>m.ReadAll()).Returns(movies);
            movieLogic = new MovieLogic(fakeMovieRepository.Object);

            var directors = new List<Director>()
            {
                new Director("1#Test One"),
                new Director("2#Test Two"),
                new Director("3#Test Three"),
            }.AsQueryable();
            fakeDirectorRepository = new Mock<IRepository<Director>>();
            fakeDirectorRepository.Setup(d => d.ReadAll()).Returns(directors);
            

            var actors = new List<Actor>()
            {
                new Actor("1#Testactor One"),
                new Actor("2#Testactor Two"),
                new Actor("3#Testactor Three")
            }.AsQueryable();
            fakeActorRepository = new Mock<IRepository<Actor>>();
            fakeActorRepository.Setup(a => a.ReadAll()).Returns(actors);
            personLogic = new PersonLogic(fakeActorRepository.Object, fakeDirectorRepository.Object);

            var roles = new List<Role>()
            {
                new Role("1#1#1#1#IronMan"),
                new Role("2#1#2#2#RoleTwo"),
                new Role("3#2#1#3#RoleThree"),
                new Role("4#2#2#4#IronMan"),
                new Role("5#3#1#5#RoleFive"),
                new Role("6#4#3#6#RoleSix"),
            }.AsQueryable();
            fakeRoleRepository = new Mock<IRepository<Role>>();
            fakeRoleRepository.Setup(r => r.ReadAll()).Returns(roles);
            roleLogic = new RoleLogic(fakeRoleRepository.Object);

        }
        [Test]
        public void PersonCreationTestWithNullValueTest()
        {
            IPerson testPerson = null;

            Assert.That(()=>personLogic.Create(testPerson),Throws.TypeOf<ArgumentNullException>());
        }
        [Test]
        public void RoleCreationTestWithNullValueTest()
        {
            Role testRole = null;

            Assert.That(() => roleLogic.Create(testRole), Throws.TypeOf<ArgumentNullException>());
        }
        [Test]
        public void MovieCreationTestWithNullValueTest()
        {
            Movie testMovie = null;

            Assert.That(() => movieLogic.Create(testMovie), Throws.TypeOf<ArgumentNullException>());
        }
        [Test]
        public void OldestMovieTest()
        {
            var expected = new Movie("1#TestMovie 1#585,8#1#2008*05*02#7,9");

            var result = movieLogic.Oldest();

            Assert.AreEqual(expected, result);
        }
        [Test]
        public void TopRatingMovieTest()
        {
            var expected = new Movie("1#TestMovie 1#585,8#1#2008*05*02#7,9");

            var result= movieLogic.TopRating();

            Assert.AreEqual(expected, result);
        }
        [Test]
        public void DirectorWithMostFilmsTest()
        {
            var expected = new Director("1#Test One");

            var result = personLogic.DirectorWithMostFilms();

            Assert.AreEqual(expected, result);
        }
        [Test]
        public void GetMostCommonRoleNameTest()
        {
            string expected = "IronMan";

            string result = roleLogic.GetMostCommonRoleName();

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
