using DataAccess.Context;
using DataAccess.Repositories;
using Domain;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
        public void GetMovieByTitleOkTest()
        {
            // Arrange
            Movie expectedMovie = new Movie {Title = "Shrek", Genres = new List<string>(){"Comedy", "Fantasy", "Adventure" } };
            LoadContext(TestData());

            Movie result = _movieRepository.GetMovieByTitle("Shrek");
            Assert.AreEqual(expectedMovie, result);
        }
    }
}
