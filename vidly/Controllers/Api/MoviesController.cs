using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using vidly.Data;
using vidly.Dtos;
using vidly.Models;

namespace vidly.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {

        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public MoviesController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        // GET: api/Movies
        [HttpGet]
        public async Task<IEnumerable<MovieDto>> GetMovies()
        {
            var movies = await _context.Movies.ToListAsync();
            var movieDtos = movies.Select(_mapper.Map<Movie, MovieDto>);
            return movieDtos;
        }

        // GET: api/Movies/5
        [HttpGet("{id:int}", Name = "GetMovie")]
        public async Task<ActionResult<MovieDto>> GetMovie(int id)
        {
            var movie = await _context.Movies.FindAsync(id);

            if (movie == null)
                return NotFound();

            return _mapper.Map<Movie, MovieDto>(movie);
        }

        // POST: api/Movies
        [HttpPost]
        public async Task<ActionResult<MovieDto>> CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movie = _mapper.Map<MovieDto, Movie>(movieDto);
            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();

            movieDto.Id = movie.Id;

            return CreatedAtAction(nameof(GetMovie), new {id = movieDto.Id}, movieDto);
        }

        // PUT: api/Movies/5
        [HttpPut("{id:int}")]
        public async Task<ActionResult> PutMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movieInDb = await _context.Movies.SingleOrDefaultAsync(c => c.Id == id);

            if (movieInDb == null)
                return NotFound();

            _mapper.Map(movieDto, movieInDb);

            await _context.SaveChangesAsync();

            return AcceptedAtAction(nameof(GetMovie), new {id = movieDto.Id}, movieDto);
        }

        // DELETE: api/Movies/5
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteMovie(int id)
        {
            var movieInDb = await _context.Movies.SingleOrDefaultAsync(c => c.Id == id);

            if (movieInDb == null)
                return NotFound();


            _context.Movies.Remove(movieInDb);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
