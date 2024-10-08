﻿using Microsoft.AspNetCore.Mvc;
using MoviesApi.Models.In;
using MoviesApi.Models.Out;

namespace MoviesApi.Controllers
{
    [Route("api/movies")]
    [ApiController]
    public class MoviesController : Controller
    {
        //[HttpGet]
        //public IActionResult GetMovies() 
        //{
        //    return Ok("Shrek, Avatar");
        //}
        //Attribute para indicarle a ASP.NET Core que este método de acción 
        //corresponde a una solicitud HTTP con verbo Get
        [HttpGet]
        //Firma del método de acción. 
        //IActionResult es un tipo base para representar respuestas HTTP.
        public IActionResult GetMovieByPostfix([FromQuery] string? endsWith) // ?endsWith=2
        {
            string[] movies = { "Shrek", "Harry Potter", "Avengers: Endgame", "Avatar" };
            if (endsWith is null)
            {
                return Ok(movies);
            }
            return Ok(movies.Where(x => x.EndsWith(endsWith)).ToList());
        }

        [HttpGet("{title}")]
        public IActionResult GetMovieByTitle([FromRoute] string title) // /Avatar
        {
            string[] movies = { "Shrek", "Harry Potter", "Avengers: Endgame", "Avatar" };
            return Ok(from movie in movies
                      where movie.ToLower().Equals(title.ToLower())
                      select movie);
        }

        [HttpPost]
        public IActionResult CreateMovie([FromBody] CreateMovieRequest movie)
        {
            CreateMovieResponse response = new CreateMovieResponse()
            {
                Title = movie.Title,
                Genres = movie.Genres
            };
            return Created(string.Empty, response);
            //return createdataction(nameof(getmoviebytitle), new { title = response.title }, response);
        }
    }
}
