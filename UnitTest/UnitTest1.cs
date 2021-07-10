using NUnit.Framework;
using Data.Model;
using System.Collections.Generic;
using API.Services.Repo.CorsoRESTRepo;

namespace UnitTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var i = new CorsoRESTMovieRepoMock();

            var m = i.GetAllMovies();
            Assert.Pass();
        }
    }
}