using Domain;
using IBusinessLogic;
using Microsoft.AspNetCore.Mvc;
using Models.Out;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDDAvanzado.Controllers;

namespace TestAPI
{
    [TestClass]
    public class MoviesControllerTest
    {
        private MoviesController _moviesController;
        private RetrieveMovieResponse _retrieveMovieResponse;
        private Movie _movie;

        [TestInitialize]
        public void Setup()
        {
            _retrieveMovieResponse = new RetrieveMovieResponse() { Title = "Avatar", Genres = new List<string>() };
            _movie = new Movie() { Title = "Avatar", Genres = new List<string>() };
        }

        [TestMethod]
        public void GetMovieByTitleOk()
        {
            //Arrange
            Mock<IMovieLogic> movieLogicMock = new Mock<IMovieLogic>(MockBehavior.Strict);
            movieLogicMock.Setup(logic => logic.GetMovieByTitle(It.IsAny<string>())).Returns(_movie);
            _moviesController = new MoviesController(movieLogicMock.Object);
            OkObjectResult expected = new OkObjectResult(_retrieveMovieResponse);
            RetrieveMovieResponse expectedObject = expected.Value as RetrieveMovieResponse;

            //Act
            OkObjectResult result = _moviesController.GetMovieByTitle("") as OkObjectResult;
            RetrieveMovieResponse objectResult = result.Value as RetrieveMovieResponse;

            //Assert
            movieLogicMock.VerifyAll();
            Assert.AreEqual(expectedObject, objectResult);
        }
    }
}
