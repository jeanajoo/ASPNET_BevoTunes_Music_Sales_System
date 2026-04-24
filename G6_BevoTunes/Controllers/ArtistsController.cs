using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using G6_BevoTunes.DAL;
using G6_BevoTunes.Models;
using Microsoft.AspNetCore.Authorization;

namespace G6_BevoTunes.Controllers
{
    public class ArtistsController : Controller
    {
        private readonly AppDbContext _context;

        public ArtistsController(AppDbContext context)
        {

            _context = context;
        }

        // GET: Artists
        public async Task<IActionResult> Index()
        {
            List<Artist> artists = await _context.Artists
                .Include(a => a.Genres)
                .Include(a => a.Albums)
                .Include(a => a.Songs)
                .Include(a => a.Reviews)
                .ToListAsync();
        
            return View(artists);
        }

        // GET: Artists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artist = await _context.Artists
                .Include(s => s.Albums)
                    .ThenInclude(a => a.Reviews)
                    .ThenInclude(r => r.Reviewer)
                .Include(s => s.Genres)
                .Include(s => s.Songs)
                    .ThenInclude(s => s.Reviews)
                    .ThenInclude(r => r.Reviewer)
                .Include(s => s.Reviews)
                    .ThenInclude(r => r.Reviewer)
                .Include(s => s.Promotions)
                .FirstOrDefaultAsync(m => m.ArtistId == id);
            if (artist == null)
            {
                return NotFound();
            }

            return View(artist);
        }

        // GET: Artists/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            ViewBag.AllGenres = GetAllGenresList();
            return View();
        }

        // POST: Artists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([Bind("ArtistId,ArtistName")] Artist artist, int[] selectedGenres)
        {
            if (ModelState.IsValid)
            {
                // Add selected genres to artist
                if (selectedGenres != null && selectedGenres.Length > 0)
                {
                    var genres = await _context.Genres
                        .Where(g => selectedGenres.Contains(g.GenreId))
                        .ToListAsync();
                    artist.Genres = genres;
                }

                _context.Add(artist);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.AllGenres = GetAllGenresList();
            return View(artist);
        }

        // GET: Artists/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artist = await _context.Artists
                .Include(a => a.Genres)
                .FirstOrDefaultAsync(a => a.ArtistId == id);
            if (artist == null)
            {
                return NotFound();
            }
            ViewBag.AllGenres = GetAllGenresList();
            ViewData["SelectedGenres"] = artist.Genres.Select(g => g.GenreId).ToList();
            return View(artist);
        }

        // POST: Artists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, [Bind("ArtistId,ArtistName")] Artist artist, int[] selectedGenres)
        {
            if (id != artist.ArtistId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var existingArtist = await _context.Artists
                        .Include(a => a.Genres)
                        .FirstOrDefaultAsync(a => a.ArtistId == id);

                    if (existingArtist == null)
                    {
                        return NotFound();
                    }

                    // Update basic properties
                    existingArtist.ArtistName = artist.ArtistName;

                    // Update genres
                    existingArtist.Genres.Clear();
                    if (selectedGenres != null && selectedGenres.Length > 0)
                    {
                        var genres = await _context.Genres
                            .Where(g => selectedGenres.Contains(g.GenreId))
                            .ToListAsync();
                        existingArtist.Genres = genres;
                    }

                    _context.Update(existingArtist);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArtistExists(artist.ArtistId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewBag.AllGenres = GetAllGenresList();
            ViewData["SelectedGenres"] = artist.Genres.Select(g => g.GenreId).ToList();
            return View(artist);
        }

        // GET: Artists/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artist = await _context.Artists
                .FirstOrDefaultAsync(m => m.ArtistId == id);
            if (artist == null)
            {
                return NotFound();
            }

            return View(artist);
        }

        // POST: Artists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var artist = await _context.Artists.FindAsync(id);
            if (artist != null)
            {
                _context.Artists.Remove(artist);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private SelectList GetAllGenresList()
        {
            List<Genre> genres = _context.Genres.ToList();
            genres.OrderBy(m => m.GenreId);

            return new SelectList(genres, "GenreId", "GenreName");
        }

        private bool ArtistExists(int id)
        {
            return _context.Artists.Any(e => e.ArtistId == id);
        }
    }
}
