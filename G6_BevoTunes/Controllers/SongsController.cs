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
    public class SongsController : Controller
    {
        private readonly AppDbContext _context;

        public SongsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Songs
        public async Task<IActionResult> Index()
        {
            List<Song> songs = _context.Songs
                                .Where(s => s.IsActive)
                                .Include(s => s.Artists)
                                .Include(s => s.Genres)
                                .Include(s => s.Reviews)
                                .Include(s => s.Promotions)
                                .ToList();

            return View(songs);
        }

        // GET: Products/SongDetails/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var song = await _context.Songs
                .Include(s => s.Artists)
                .Include(s => s.Genres)
                .Include(s => s.Albums)
                .Include(s => s.Reviews)
                .Include(s => s.Promotions)
                .FirstOrDefaultAsync(m => m.SongId == id);

            if (song == null)
            {
                return NotFound();
            }
            return View(song);
        }

        // GET: Products/CreateSong
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create()
        {
            ViewBag.Artists = new SelectList(await _context.Artists.ToListAsync(), "ArtistId", "ArtistName");
            ViewBag.Genres = new SelectList(await _context.Genres.ToListAsync(), "GenreId", "GenreName");
            ViewBag.Albums = new SelectList(await _context.Albums.ToListAsync(), "AlbumId", "AlbumName");
            return View(new Song());
        }

        // POST: Products/CreateSong
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([Bind("SongId,SongTitle,SongPrice")] Song song, int[] selectedArtists, int[] selectedGenres, int[] selectedAlbums)
        {
            if (ModelState.IsValid)
            {
                // Add selected artists to song
                if (selectedArtists != null && selectedArtists.Length > 0)
                {
                    var artists = await _context.Artists
                        .Where(a => selectedArtists.Contains(a.ArtistId)
                                    && a.Songs.Select(s => s.SongTitle).Contains(song.SongTitle))
                        .ToListAsync();
                    
                    // after checking that there is an artist which made the song with the same title,
                    // return the view with a relevant error message
                    if (artists.Count > 0) 
                    {
                        ModelState.AddModelError(String.Empty, "An artist cannot have more than one song with the same title");
                        ViewBag.Artists = new SelectList(await _context.Artists.ToListAsync(), "ArtistId", "ArtistName");
                        ViewBag.Genres = new SelectList(await _context.Genres.ToListAsync(), "GenreId", "GenreName");
                        ViewBag.Albums = new SelectList(await _context.Albums.ToListAsync(), "AlbumId", "AlbumName");
                        return View(song);
                    }
                    song.Artists = artists;
                }

                // Add selected genres to song
                if (selectedGenres != null && selectedGenres.Length > 0)
                {
                    var genres = await _context.Genres
                        .Where(g => selectedGenres.Contains(g.GenreId))
                        .ToListAsync();
                    song.Genres = genres;
                }

                // Add selected albums to song
                if (selectedAlbums != null && selectedAlbums.Length > 0)
                {
                    var albums = await _context.Albums
                        .Where(a => selectedAlbums.Contains(a.AlbumId))
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    .ToListAsync();
                    song.Albums = albums;
                }

                _context.Add(song);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Artists = new SelectList(await _context.Artists.ToListAsync(), "ArtistId", "ArtistName");
            ViewBag.Genres = new SelectList(await _context.Genres.ToListAsync(), "GenreId", "GenreName");
            ViewBag.Albums = new SelectList(await _context.Albums.ToListAsync(), "AlbumId", "AlbumName");
            return View(song);
        }

        // GET: Products/EditSong/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var song = await _context.Songs
                .Include(s => s.Artists)
                .Include(s => s.Genres)
                .Include(s => s.Albums)
                .FirstOrDefaultAsync(s => s.SongId == id);

            if (song == null)
            {
                return NotFound();
            }

            ViewBag.Artists = new SelectList(await _context.Artists.ToListAsync(), "ArtistId", "ArtistName", song.Artists.Select(a => a.ArtistId));
            ViewBag.Genres = new SelectList(await _context.Genres.ToListAsync(), "GenreId", "GenreName", song.Genres.Select(g => g.GenreId));
            ViewBag.Albums = new SelectList(await _context.Albums.ToListAsync(), "AlbumId", "AlbumName", song.Albums.Select(a => a.AlbumId));
            ViewData["SelectedArtists"] = song.Artists.Select(a => a.ArtistId).ToList();
            ViewData["SelectedGenres"] = song.Genres.Select(g => g.GenreId).ToList();
            ViewData["SelectedAlbums"] = song.Albums.Select(a => a.AlbumId).ToList();

            return View(song);
        }

        // POST: Products/EditSong/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, [Bind("SongId,SongTitle,SongPrice")] Song song, int[] selectedArtists, int[] selectedGenres, int[] selectedAlbums)
        {
            if (id != song.SongId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var existingSong = await _context.Songs
                        .Include(s => s.Artists)
                        .Include(s => s.Genres)
                        .Include(s => s.Albums)
                        .FirstOrDefaultAsync(s => s.SongId == id);

                    if (existingSong == null)
                    {
                        return NotFound();
                    }

                    // Update basic properties
                    existingSong.SongTitle = song.SongTitle;
                    existingSong.SongPrice = song.SongPrice;

                    // Update artists
                    existingSong.Artists.Clear();
                    if (selectedArtists != null && selectedArtists.Length > 0)
                    {
                        var artists = await _context.Artists
                            .Where(a => selectedArtists.Contains(a.ArtistId))
                            .ToListAsync();
                        existingSong.Artists = artists;
                    }

                    // Update genres
                    existingSong.Genres.Clear();
                    if (selectedGenres != null && selectedGenres.Length > 0)
                    {
                        var genres = await _context.Genres
                            .Where(g => selectedGenres.Contains(g.GenreId))
                            .ToListAsync();
                        existingSong.Genres = genres;
                    }

                    // Update albums
                    existingSong.Albums.Clear();
                    if (selectedAlbums != null && selectedAlbums.Length > 0)
                    {
                        var albums = await _context.Albums
                            .Where(a => selectedAlbums.Contains(a.AlbumId))
                            .ToListAsync();
                        existingSong.Albums = albums;
                    }

                    _context.Update(existingSong);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SongExists(song.SongId))
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

            ViewBag.Artists = new SelectList(await _context.Artists.ToListAsync(), "ArtistId", "ArtistName");
            ViewBag.Genres = new SelectList(await _context.Genres.ToListAsync(), "GenreId", "GenreName");
            ViewBag.Albums = new SelectList(await _context.Albums.ToListAsync(), "AlbumId", "AlbumName");
            ViewData["SelectedArtists"] = selectedArtists != null ? selectedArtists.ToList() : new List<int>();
            ViewData["SelectedGenres"] = selectedGenres != null ? selectedGenres.ToList() : new List<int>();
            ViewData["SelectedAlbums"] = selectedAlbums != null ? selectedAlbums.ToList() : new List<int>();
            return View(song);
        }

        
        // GET: Artists/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var song = await _context.Songs
                .FirstOrDefaultAsync(m => m.SongId == id);
            if (song == null)
            {
                return NotFound();
            }

            return View(song);
        }

        // POST: Artists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var song = await _context.Songs.FindAsync(id);
            if (song != null)
            {
                song.IsActive = false; // Soft delete by setting IsActive to false
                _context.Songs.Update(song);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        private bool SongExists(int id)
        {
            return _context.Songs.Any(e => e.SongId == id);
        }

        // GET: Songs/InactiveList - Admin only
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> InactiveList()
        {
            List<Song> inactiveSongs = await _context.Songs
                .Where(s => !s.IsActive)
                .Include(s => s.Artists)
                .Include(s => s.Genres)
                .Include(s => s.Reviews)
                .Include(s => s.Promotions)
                .ToListAsync();

            return View(inactiveSongs);
        }

        // POST: Songs/Activate/5 - Admin only
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Activate(int id)
        {
            var song = await _context.Songs.FindAsync(id);
            if (song == null)
            {
                return NotFound();
            }

            song.IsActive = true;
            _context.Songs.Update(song);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = $"Song '{song.SongTitle}' has been reactivated.";
            return RedirectToAction(nameof(InactiveList));
        }
    }
}
