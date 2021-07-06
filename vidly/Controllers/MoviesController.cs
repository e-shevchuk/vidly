using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using vidly.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            var movies = GetMovies();

            return View(movies);
        }

        public ActionResult Details(int id)
        {
            var movies = GetMovies();

            var movie = movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return NotFound();

            return View(movie);
        }

        // Hardcoded method for getting movies list
        private IEnumerable<Movie> GetMovies()
        {
            return new List<Movie>
            {
                new Movie { Id = 1, Name = "Rick and Morty" },
                new Movie { Id = 2, Name = "Star Wars: Empire strikes back" }
            };
        }

    }

}
