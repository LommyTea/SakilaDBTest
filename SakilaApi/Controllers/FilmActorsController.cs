using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SakilaApi.Data;
using SakilaApi.Models;

namespace SakilaApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FilmActorsController : ControllerBase
    {
        private readonly SakilaDbContext _context;

        public FilmActorsController(SakilaDbContext context)
        {
            _context = context;
        }

        // POST: api/FilmActors
        // Link an actor to a film
        [HttpPost]
        public async Task<IActionResult> AddFilmActor([FromBody] FilmActor filmActor)
        {
            filmActor.LastUpdate = DateTime.UtcNow;

            _context.FilmActors.Add(filmActor);
            await _context.SaveChangesAsync();

            return Ok(filmActor);
        }

        // GET: api/FilmActors/film/5
        // Get all actors in a film
        [HttpGet("film/{filmId}")]
        public async Task<IActionResult> GetActorsByFilm(int filmId)
        {
            var actors = await _context.FilmActors
                .Where(fa => fa.FilmId == filmId)
                .Include(fa => fa.Actor)
                .Select(fa => fa.Actor)
                .ToListAsync();

            return Ok(actors);
        }

        // GET: api/FilmActors/actor/5
        // Get all films an actor is in
        [HttpGet("actor/{actorId}")]
        public async Task<IActionResult> GetFilmsByActor(int actorId)
        {
            var films = await _context.FilmActors
                .Where(fa => fa.ActorId == actorId)
                .Include(fa => fa.Film)
                .Select(fa => fa.Film)
                .ToListAsync();

            return Ok(films);
        }
    }
}
