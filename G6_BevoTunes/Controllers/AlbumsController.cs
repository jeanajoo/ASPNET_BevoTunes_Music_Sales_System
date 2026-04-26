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
                        .Where(a => a.IsActive) // Only show active albums
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
                .Include(a => a.Promotions)
                .FirstOrDefaultAsync(m => m.AlbumId == id);

            if (album == null)
            {
                return NotFound();
            }
            return View(album);
        }

        // GET: Albums/Create
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create()
        {
            ViewBag.Artists = new SelectList(await _context.Artists.ToListAsync(), "ArtistId", "ArtistName");
            ViewBag.Genres = new SelectList(await _context.Genres.ToListAsync(), "GenreId", "GenreName");
            return View(new Album());
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
                return RedirectToAction("Index", "Search");
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
        // [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        // GET: Products/EditAlbum/5
        public async Task<IActionResult> Edit(int? id)
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

            ViewBag.Artists = new SelectList(await _context.Artists.ToListAsync(), "ArtistId", "ArtistName", album.Artists.Select(a => a.ArtistId));
            ViewBag.Genres = new SelectList(await _context.Genres.ToListAsync(), "GenreId", "GenreName", album.Genres.Select(g => g.GenreId));
            ViewBag.Songs = new SelectList(await _context.Songs.ToListAsync(), "SongId", "SongTitle", album.Songs.Select(s => s.SongId));
            ViewData["SelectedArtists"] = album.Artists.Select(a => a.ArtistId).ToList();
            ViewData["SelectedGenres"] = album.Genres.Select(g => g.GenreId).ToList();
            ViewData["SelectedSongs"] = album.Songs.Select(s => s.SongId).ToList();

            return View(album);
        }

        // POST: Products/EditAlbum/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
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
                return RedirectToAction("Index", "Search");
            }

            ViewBag.Artists = new SelectList(await _context.Artists.ToListAsync(), "ArtistId", "ArtistName");
            ViewBag.Genres = new SelectList(await _context.Genres.ToListAsync(), "GenreId", "GenreName");
            ViewBag.Songs = new SelectList(await _context.Songs.ToListAsync(), "SongId", "SongTitle");
            ViewData["SelectedArtists"] = selectedArtists != null ? selectedArtists.ToList() : new List<int>();
            ViewData["SelectedGenres"] = selectedGenres != null ? selectedGenres.ToList() : new List<int>();
            ViewData["SelectedSongs"] = selectedSongs != null ? selectedSongs.ToList() : new List<int>();
            return View(album);
        }

        // GET: Products/DeleteAlbum/5
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var album = await _context.Albums.FindAsync(id);
            if (album != null)
            {
                album.IsActive = false; // Soft delete by setting IsActive to false
                _context.Albums.Update(album);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Search");
        }

        private bool AlbumExists(int id)
        {
            return _context.Albums.Any(e => e.AlbumId == id);
        }

        // GET: Albums/InactiveList - Admin only
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> InactiveList()
        {
            List<Album> inactiveAlbums = await _context.Albums
                .Where(a => !a.IsActive)
                .Include(a => a.Artists)
                .Include(a => a.Genres)
                .Include(a => a.Songs)
                .Include(a => a.Reviews)
                .ToListAsync();

            return View(inactiveAlbums);
        }

        // POST: Albums/Activate/5 - Admin only
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Activate(int id)
        {
            var album = await _context.Albums.FindAsync(id);
            if (album == null)
            {
                return NotFound();
            }

            album.IsActive = true;
            _context.Albums.Update(album);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = $"Album '{album.AlbumName}' has been reactivated.";
            return RedirectToAction(nameof(InactiveList));
        }
    }
}
