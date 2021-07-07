using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using vidly.Data;
using vidly.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController(ApplicationDbContext context)
        {
            _context = context;
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        
        // GET: /<controller>/
        public IActionResult Index()
        {
            var movies = _context.Movies.Include(m => m.Genre).ToList();

            return View(movies);
        }

        public ActionResult Details(int id)
        {
            var movie =
                _context.Movies.Include(m => m.Genre).
                    SingleOrDefault(m => m.Id == id);

            // var movie = movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return NotFound();

            return View(movie);
        }
    }
}
