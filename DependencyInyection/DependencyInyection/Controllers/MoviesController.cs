using Microsoft.AspNetCore.Mvc;
using Models.In;
using Models.Out;

namespace DependencyInyection.Controllers
{
    [Route("api/movies")]
    [ApiController]
    public class MoviesController : Controller
    {
        [HttpGet]
        public IActionResult GetMovieByPostfix([FromQuery] string? endsWith) 
        {
            string[] movies = { "Shrek", "Harry Potter", "Avengers: Endgame", "Avatar" };
            if (endsWith is null)
            {
                return Ok(movies);
            }
            return Ok(movies.Where(x => x.EndsWith(endsWith)).ToList());
        }

        [HttpGet("{title}")]
        public IActionResult GetMovieByTitle([FromRoute] string title) 
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
        }
    }
}
