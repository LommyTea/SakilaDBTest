using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SakilaApi.Data;
using SakilaApi.Models;

namespace SakilaApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FilmsController : ControllerBase
    {
        private readonly SakilaDbContext _context;

        public FilmsController(SakilaDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Film>>> GetFilms()
        {
            return await _context.Films.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Film>> GetFilm(int id)
        {
            var film = await _context.Films.FindAsync(id);
            if (film == null) return NotFound();
            return film;
        }

        [HttpPost]
        public async Task<ActionResult<Film>> CreateFilm(Film film)
        {
            film.LastUpdate = DateTime.UtcNow;
            _context.Films.Add(film);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetFilm), new { id = film.FilmId }, film);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFilm(int id, Film film)
        {
            if (id != film.FilmId) return BadRequest();
            film.LastUpdate = DateTime.UtcNow;
            _context.Entry(film).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Films.Any(f => f.FilmId == id))
                    return NotFound();
                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFilm(int id)
        {
            var film = await _context.Films.FindAsync(id);
            if (film == null) return NotFound();

            _context.Films.Remove(film);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
