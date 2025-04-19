using Microsoft.AspNetCore.Mvc;

namespace jurnal_modul9.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController : ControllerBase
    {
        private static List<Movie> Movies = new List<Movie>
        {
            new Movie {
                Title = "The Shawshank Redemption",
                Director = "Frank Darabont",
                Stars = new List<string> { "Tim Robbins", "Morgan Freeman" },
                Description = "Two imprisoned men bond over a number of years..."
            },
            new Movie {
                Title = "The Godfather",
                Director = "Francis Ford Coppola",
                Stars = new List<string> { "Marlon Brando", "Al Pacino" },
                Description = "The aging patriarch of an organized crime dynasty..."
            },
            new Movie {
                Title = "The Dark Knight",
                Director = "Christopher Nolan",
                Stars = new List<string> { "Christian Bale", "Heath Ledger" },
                Description = "When the menace known as the Joker wreaks havoc..."
            }
        };

        [HttpGet]
        public ActionResult<List<Movie>> GetAllMovies() => Movies;

        [HttpGet("{id}")]
        public ActionResult<Movie> GetMovieById(int id)
        {
            if (id < 0 || id >= Movies.Count)
                return NotFound();
            return Movies[id];
        }

        [HttpPost]
        public ActionResult AddMovie([FromBody] Movie movie)
        {
            Movies.Add(movie);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteMovie(int id)
        {
            if (id < 0 || id >= Movies.Count)
                return NotFound();
            Movies.RemoveAt(id);
            return Ok();
        }
    }
}
