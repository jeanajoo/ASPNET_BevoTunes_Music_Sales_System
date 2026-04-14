using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using G6_BevoTunes.DAL;
using G6_BevoTunes.Models;
using Microsoft.AspNetCore.Authorization;

namespace G6_BevoTunes.Controllers
{
    // Managers can add/edit, but everyone can View
    public class GenresController : Controller
    {
        private readonly AppDbContext _context;

        public GenresController(AppDbContext context)
        {
            _context = context;
        }

        // Get: Genres
        public async Task<IActionResult> Index()
        {
            var genres = await _context.Genres
                .OrderBy(g => g.GenreName)
                .ToListAsync();

            return View(genres);
        }

        // Get: Genres/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var genre = await _context.Genres
                .Include(g => g.Songs) // Optional: show songs in this genre
                .FirstOrDefaultAsync(m => m.GenreId == id);

            if (genre == null) return NotFound();

            return View(genre);
        }
    }
}