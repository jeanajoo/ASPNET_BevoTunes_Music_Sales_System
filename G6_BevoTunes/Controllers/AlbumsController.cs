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
    public class AlbumsController : Controller
    {
        private readonly AppDbContext _context;

        public AlbumsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Albums
        public async Task<IActionResult> Index()
        {
            List<Album> albums = await _context.Albums
                        .Include(a => a.Artists)
                        .Include(a => a.Genres)
                        .Include(a => a.Promotions)
                        .ToListAsync();
            return View(albums);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var album = await _context.Albums
                .Include(a => a.Artists)
                .Include(a => a.Genres)
                .Include(a => a.Songs)
                    .ThenInclude(s => s.Reviews)
                .Include(a => a.Reviews)
                .FirstOrDefaultAsync(m => m.AlbumId == id);

            if (album == null)
            {
                return NotFound();
            }
            return View(album);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateAlbum()
        {
            ViewBag["Artists"] = new SelectList(await _context.Artists.ToListAsync(), "ArtistId", "ArtistName");
            ViewBag["Genres"] = new SelectList(await _context.Genres.ToListAsync(), "GenreId", "GenreName");
            ViewBag["Songs"] = new SelectList(await _context.Songs.ToListAsync(), "SongId", "SongTitle");
            return View(new Album());
        }
        // GET: Albums/Create
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create()
        {
            ViewBag.Artists = new SelectList(await _context.Artists.ToListAsync(), "ArtistId", "ArtistName");
            ViewBag.Genres = new SelectList(await _context.Genres.ToListAsync(), "GenreId", "GenreName");
            return View(new Album());
        }

        // POST: Albums/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AlbumId,AlbumName,AlbumPrice,AlbumCover")] Album album)
        {
            if (ModelState.IsValid)
            {
                _context.Add(album);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(album);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([Bind("AlbumId,AlbumName,AlbumPrice,AlbumCover")] Album album, int[] selectedArtists, int[] selectedGenres, int[] selectedSongs)
        {
            if (ModelState.IsValid)
            {
                // Add selected artists to album
                if (selectedArtists != null && selectedArtists.Length > 0)
                {
                    var artists = await _context.Artists
                        .Where(a => selectedArtists.Contains(a.ArtistId))
                        .ToListAsync();
                    album.Artists = artists;
                }

                // Add selected genres to album
                if (selectedGenres != null && selectedGenres.Length > 0)
                {
                    var genres = await _context.Genres
                        .Where(g => selectedGenres.Contains(g.GenreId))
                        .ToListAsync();
                    album.Genres = genres;
                }

                // Add selected songs to album
                if (selectedSongs != null && selectedSongs.Length > 0)
                {
                    var songs = await _context.Songs
                        .Where(s => selectedSongs.Contains(s.SongId))
                        .ToListAsync();
                    album.Songs = songs;
                }

                _context.Add(album);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Artists = new SelectList(await _context.Artists.ToListAsync(), "ArtistId", "ArtistName");
            ViewBag.Genres = new SelectList(await _context.Genres.ToListAsync(), "GenreId", "GenreName");
            return View(album);
        }

        // GET: Albums/GetSongsByArtists - API endpoint to get songs by selected artists
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetSongsByArtists(int[] artistIds)
        {
            if (artistIds == null || artistIds.Length == 0)
            {
                return Json(new List<object>());
            }

            var songs = await _context.Songs
                .Where(s => s.Artists.Any(a => artistIds.Contains(a.ArtistId)))
                .Distinct()
                .Select(s => new { id = s.SongId, name = s.SongTitle })
                .ToListAsync();

            return Json(songs);
        }

        // POST: Products/CreateAlbum
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        // GET: Products/EditAlbum/5
        public async Task<IActionResult> EditAlbum(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var album = await _context.Albums
                .Include(a => a.Artists)
                .Include(a => a.Genres)
                .Include(a => a.Songs)
                .FirstOrDefaultAsync(a => a.AlbumId == id);

            if (album == null)
            {
                return NotFound();
            }

            ViewBag["Artists"] = new SelectList(await _context.Artists.ToListAsync(), "ArtistId", "ArtistName", album.Artists.Select(a => a.ArtistId));
            ViewBag["Genres"] = new SelectList(await _context.Genres.ToListAsync(), "GenreId", "GenreName", album.Genres.Select(g => g.GenreId));
            ViewBag["Songs"] = new SelectList(await _context.Songs.ToListAsync(), "SongId", "SongTitle", album.Songs.Select(s => s.SongId));
            ViewBag["SelectedArtists"] = album.Artists.Select(a => a.ArtistId).ToList();
            ViewBag["SelectedGenres"] = album.Genres.Select(g => g.GenreId).ToList();
            ViewBag["SelectedSongs"] = album.Songs.Select(s => s.SongId).ToList();

            return View(album);
        }

        // POST: Products/EditAlbum/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AlbumId,AlbumName,AlbumPrice,AlbumCover")] Album album, int[] selectedArtists, int[] selectedGenres, int[] selectedSongs)
        {
            if (id != album.AlbumId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var existingAlbum = await _context.Albums
                        .Include(a => a.Artists)
                        .Include(a => a.Genres)
                        .Include(a => a.Songs)
                        .FirstOrDefaultAsync(a => a.AlbumId == id);

                    if (existingAlbum == null)
                    {
                        return NotFound();
                    }

                    // Update basic properties
                    existingAlbum.AlbumName = album.AlbumName;
                    existingAlbum.AlbumPrice = album.AlbumPrice;
                    existingAlbum.AlbumCover = album.AlbumCover;

                    // Update artists
                    existingAlbum.Artists.Clear();
                    if (selectedArtists != null && selectedArtists.Length > 0)
                    {
                        var artists = await _context.Artists
                            .Where(a => selectedArtists.Contains(a.ArtistId))
                            .ToListAsync();
                        existingAlbum.Artists = artists;
                    }

                    // Update genres
                    existingAlbum.Genres.Clear();
                    if (selectedGenres != null && selectedGenres.Length > 0)
                    {
                        var genres = await _context.Genres
                            .Where(g => selectedGenres.Contains(g.GenreId))
                            .ToListAsync();
                        existingAlbum.Genres = genres;
                    }

                    // Update songs
                    existingAlbum.Songs.Clear();
                    if (selectedSongs != null && selectedSongs.Length > 0)
                    {
                        var songs = await _context.Songs
                            .Where(s => selectedSongs.Contains(s.SongId))
                            .ToListAsync();
                        existingAlbum.Songs = songs;
                    }

                    _context.Update(existingAlbum);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlbumExists(album.AlbumId))
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

            ViewBag["Artists"] = new SelectList(await _context.Artists.ToListAsync(), "ArtistId", "ArtistName");
            ViewBag["Genres"] = new SelectList(await _context.Genres.ToListAsync(), "GenreId", "GenreName");
            ViewBag["Songs"] = new SelectList(await _context.Songs.ToListAsync(), "SongId", "SongTitle");
            return View(album);
        }

        // GET: Products/DeleteAlbum/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var album = await _context.Albums
                .Include(a => a.Artists)
                .Include(a => a.Genres)
                .Include(a => a.Songs)
                .FirstOrDefaultAsync(m => m.AlbumId == id);

            if (album == null)
            {
                return NotFound();
            }

            return View("Index");
        }

        // POST: Products/DeleteAlbum/5
        [HttpPost, ActionName("DeleteAlbum")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var album = await _context.Albums.FindAsync(id);
            if (album != null)
            {
                _context.Albums.Remove(album);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlbumExists(int id)
        {
            return _context.Albums.Any(e => e.AlbumId == id);
        }
    }
}
