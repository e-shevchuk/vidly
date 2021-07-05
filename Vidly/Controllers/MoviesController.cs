using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Index()
        {
            var movies = new List<Movie>
            {
                new Movie {Id = 0, Name = "Start Wars"},
                new Movie {Id = 1, Name = "Big Lebovsky"}
            };

            var viewModel = new MoviesViewModel()
            {
                Movies = movies
            };

            return View(viewModel);
        }

        public ActionResult Details(int id)
        {
            var movies = new List<Movie>
            {
                new Movie {Id = 0, Name = "Start Wars"},
                new Movie {Id = 1, Name = "Big Lebovsky"}
            };

            var movie = movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();
            
            return View(movie);
        }

        public ActionResult Edit(int id)
        {
            return Content($"id={id.ToString()}");
        }
        
        // Attribute route constraints example
        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content($"{year.ToString()}/{month.ToString()}");
        }

        
        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie { Name = "Shrek!" };
            var customers = new List<Customer>
            {
                new Customer() {Name = "Customer 1"},
                new Customer() {Name = "Customer 2"}
            };

            var viewModel = new RandomMovieViewModel()
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
        }

    }
}