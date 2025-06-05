using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SakilaApi.Data;
using SakilaApi.Models;

namespace SakilaApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ActorsController : ControllerBase
    {
        private readonly SakilaDbContext _context;

        public ActorsController(SakilaDbContext context)
        {
            _context = context;
        }

        // GET: api/actors
        // This method returns all actors in the database including their IDs, first names, last names, and last update timestamps.
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Actor>>> GetActors()
        {
            return await _context.Actors.ToListAsync();
        }

        // GET: api/actors/5
        // This method retrieves a specific actor by ID, returning their first name, last name, and last update timestamp.
        [HttpGet("{id}")]
        public async Task<ActionResult<Actor>> GetActor(int id)
        {
            var actor = await _context.Actors.FindAsync(id);

            if (actor == null)
            {
                return NotFound();
            }

            return actor;
        }
        // POST: api/actors
        // This method creates a new actor in the database, setting the last update timestamp to the current time.
        [HttpPost]
        public async Task<ActionResult<Actor>> CreateActor(Actor actor)
        {
            actor.LastUpdate = DateTime.UtcNow;
            _context.Actors.Add(actor);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetActor), new { id = actor.ActorId }, actor);
        }

        // PUT: api/actors/5
        // This method updates an existing actor's information in the database, including their first name, last name, and last update timestamp.
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateActor(int id, Actor actor)
        {
            if (id != actor.ActorId) return BadRequest();

            actor.LastUpdate = DateTime.UtcNow;
            _context.Entry(actor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Actors.Any(e => e.ActorId == id))
                    return NotFound();
                throw;
            }

            return NoContent();
        }

        // DELETE: api/actors/5
        // This method deletes an actor from the database by their ID.
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActor(int id)
        {
            var actor = await _context.Actors.FindAsync(id);
            if (actor == null) return NotFound();

            _context.Actors.Remove(actor);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
