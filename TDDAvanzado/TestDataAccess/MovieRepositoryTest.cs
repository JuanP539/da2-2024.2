using DataAccess.Context;
using DataAccess.Repositories;
using Domain;
using IDataAccess;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Moq.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDataAccess
{
    [TestClass]
    public class MovieRepositoryTest
    {
        private SqliteConnection _connection;
        private MovieContext _context;
        private MovieRepository _movieRepository;

        [TestInitialize]
        public void Setup()
        {
            // Fake in-memory database
            _connection = new SqliteConnection("Filename=:memory:");
            _connection.Open();

            var contextOptions = new DbContextOptionsBuilder<MovieContext>()
                .UseSqlite(_connection)
                .Options;

            _context = new MovieContext(contextOptions);
            _context.Database.EnsureCreated();

            _movieRepository = new MovieRepository(_context);
        }

        [TestCleanup]
        public void Cleanup()
        {
            _context.Database.EnsureDeleted();
        }

        private void LoadContext(List<Movie> movies)
        {
            _context.Movies.AddRange(movies);
            _context.SaveChanges();
        }

        private List<Movie> TestData()
        {
            return new List<Movie>
            {
                new Movie {Title = "Shrek", Genres = new List<string>(){"Comedy", "Fantasy", "Adventure" } },
                new Movie {Title = "Harry Potter", Genres = new List<string>(){ "Fantasy", "Adventure", "Mystery" } }
             };
        }

        [TestMethod]
        public void GetMovieByTitleOkFakeTest()
        {
            // Arrange
            Movie expectedMovie = new Movie {Title = "Shrek" };
            LoadContext(TestData());

            //Act
            Movie result = _movieRepository.GetMovieByTitle("Shrek");

            //Assert
            Assert.AreEqual(expectedMovie, result);
        }

        [TestMethod]
        public void GetMovieByTitleMockOkTest() 
        {
            //Arrange
            Movie expectedMovie = new Movie { Title = "Shrek" };
            Mock<MovieContext> moviesContext = new Mock<MovieContext>();
            moviesContext.Setup(ctx => ctx.Movies).ReturnsDbSet(TestData());
            IMovieRepository movieRepository = new MovieRepository(moviesContext.Object);

            //Act
            Movie result = movieRepository.GetMovieByTitle("Shrek");

            //Assert
            Assert.AreEqual(expectedMovie, result);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void GetMovieByTitleFail() 
        {
            Movie expectedMovie = new Movie { Title = "Shrek" };
            LoadContext(TestData());

            Movie result = _movieRepository.GetMovieByTitle(null);
        }
    }
}
