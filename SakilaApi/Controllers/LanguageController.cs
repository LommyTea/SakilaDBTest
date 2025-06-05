using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SakilaApi.Data;
using SakilaApi.Models;

namespace SakilaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguagesController : ControllerBase
    {
        private readonly SakilaDbContext _context;

        public LanguagesController(SakilaDbContext context)
        {
            _context = context;
        }

        // GET: api/Languages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Language>>> GetLanguages()
        {
            return await _context.Languages
            .Include(l => l.Films)
            .ToListAsync();
        }

        // GET: api/Languages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Language>> GetLanguage(int id)
        {
            var language = await _context.Languages.Include(l => l.Films).FirstOrDefaultAsync(l => l.LanguageId == id);

            if (language == null)
                return NotFound();

            return language;
        }
    }
}
