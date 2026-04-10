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
    public class ProductsController : Controller
    {
        private readonly AppDbContext _context;

        public ProductsController(AppDbContext context)
        {
            _context = context;
        }

        #region Songs

        // GET: Products/Songs
        public async Task<IActionResult> Index()
        {
            List<Song> songs = await _context.Songs
                .Include(s => s.Artists)
                .Include(s => s.Genres)
                .Include(s => s.Albums)
                .Include(s => s.Reviews)
                .ToListAsync();

            List<Album> albums = await _context.Albums
                .Include(a => a.Artists)
                .Include(a => a.Genres)
                .Include(a => a.Songs)
                .Include(a => a.Reviews)
                .ToListAsync();

            ProductsViewModel pvm = new ProductsViewModel();

            pvm.Albums = albums;
            pvm.Songs = songs;

            return View(pvm);
        }

        public async Task<IActionResult> AdvancedSearch()
        {
            ViewBag.AllGenres = GetAllGenresList();
            return View();
        }

        public async Task<IActionResult> DisplaySearchResults(SearchViewModel svm)
        {
            var songQuery = _context.Songs.AsQueryable();
            var albumQuery = _context.Albums.AsQueryable();
            var artistQuery = _context.Artists.AsQueryable();

            // Filter by Name (applies to all)
            if (!String.IsNullOrEmpty(svm.SearchString))
            {
                songQuery = songQuery.Where(s => s.SongTitle.Contains(svm.SearchString));
                albumQuery = albumQuery.Where(a => a.AlbumName.Contains(svm.SearchString));
                artistQuery = artistQuery.Where(ar => ar.ArtistName.Contains(svm.SearchString));
            }

            // Filter by Genre; we probably have to set up the "null" or all genres value, or be lazy and set to null
            if (svm.Genre != 0)
            {
                songQuery = songQuery.Where(s => s.Genres.Any(g => g.GenreId == svm.Genre));
                albumQuery = albumQuery.Where(a => a.Genres.Any(g => g.GenreId == svm.Genre));
            }

            // Filter by ratings
            if (svm.Rating != 1.0m)
            {
                if (svm.RatingBound == RatingBound.GreaterThan)
                {
                    songQuery = songQuery.Where(s => s.Reviews.Sum(r => r.Rating) >= svm.Rating);
                    albumQuery = albumQuery.Where(a => a.Reviews.Sum(r => r.Rating) >= svm.Rating);
                }
                else
                {
                    songQuery = songQuery.Where(s => s.Reviews.Sum(r => r.Rating) <= svm.Rating);
                    albumQuery = albumQuery.Where(a => a.Reviews.Sum(r => r.Rating) <= svm.Rating);
                }
            }

            // Execute queries
            var songs = songQuery                
                            .Include(s => s.Artists)
                            .Include(s => s.Genres)
                            .Include(s => s.Albums)
                            .Include(s => s.Reviews)
                            .Include(s => s.Promotions)
                            .ToList();
            var albums = albumQuery                            
                            .Include(s => s.Artists)
                            .Include(s => s.Genres)
                            .Include(s => s.Songs)
                            .Include(s => s.Reviews)
                            .Include(s => s.Promotions)
                            .ToList();
            var artists = artistQuery.ToList();

            /*
                for artists, I decided to show their songs and albums if a user typed their names in.
                this might be wrong but we can talk about it when we meet in person.
                .
                .
                .
                Question: is Qianbo a smart fella or a fart smeller?
            */ 
            List<Song> artistSongs = new List<Song>();
            List<Album> artistAlbums = new List<Album>();

            foreach (Artist ar in artists)
            {
                artistSongs = new[] { artistSongs, ar.Songs}.SelectMany(x => x).ToList();
                artistAlbums = new[] { artistAlbums, ar.Albums}.SelectMany(x => x).ToList();
            }

            songs = new[] { songs, artistSongs}.SelectMany(x => x).ToList();
            albums = new[] { albums, artistAlbums}.SelectMany(x => x).ToList();

            // Combine results into a single view model
            var results = new SearchResultsViewModel
            {
                Songs = songs,
                Albums = albums
            };

            // ViewBag counts
            ViewBag.AllProducts = _context.Songs.Count() + _context.Albums.Count();
            ViewBag.SelectedResults = songs.Count + albums.Count;

            return View("Index", results);
        }

        // GET: Products/SongDetails/5
        public async Task<IActionResult> SongDetails(int? id)
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
        public async Task<IActionResult> CreateSong()
        {
            ViewData["Artists"] = new SelectList(await _context.Artists.ToListAsync(), "ArtistId", "ArtistName");
            ViewData["Genres"] = new SelectList(await _context.Genres.ToListAsync(), "GenreId", "GenreName");
            ViewData["Albums"] = new SelectList(await _context.Albums.ToListAsync(), "AlbumId", "AlbumName");
            return View();
        }

        // POST: Products/CreateSong
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateSong([Bind("SongId,SongTitle,SongPrice")] Song song, int[] selectedArtists, int[] selectedGenres, int[] selectedAlbums)
        {
            if (ModelState.IsValid)
            {
                // Add selected artists to song
                if (selectedArtists != null && selectedArtists.Length > 0)
                {
                    var artists = await _context.Artists
                        .Where(a => selectedArtists.Contains(a.ArtistId))
                        .ToListAsync();
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

            ViewData["Artists"] = new SelectList(await _context.Artists.ToListAsync(), "ArtistId", "ArtistName");
            ViewData["Genres"] = new SelectList(await _context.Genres.ToListAsync(), "GenreId", "GenreName");
            ViewData["Albums"] = new SelectList(await _context.Albums.ToListAsync(), "AlbumId", "AlbumName");
            return View(song);
        }

        // GET: Products/EditSong/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> EditSong(int? id)
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

            ViewData["Artists"] = new SelectList(await _context.Artists.ToListAsync(), "ArtistId", "ArtistName", song.Artists.Select(a => a.ArtistId));
            ViewData["Genres"] = new SelectList(await _context.Genres.ToListAsync(), "GenreId", "GenreName", song.Genres.Select(g => g.GenreId));
            ViewData["Albums"] = new SelectList(await _context.Albums.ToListAsync(), "AlbumId", "AlbumName", song.Albums.Select(a => a.AlbumId));
            ViewData["SelectedArtists"] = song.Artists.Select(a => a.ArtistId).ToList();
            ViewData["SelectedGenres"] = song.Genres.Select(g => g.GenreId).ToList();
            ViewData["SelectedAlbums"] = song.Albums.Select(a => a.AlbumId).ToList();

            return View(song);
        }

        // POST: Products/EditSong/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> EditSong(int id, [Bind("SongId,SongTitle,SongPrice")] Song song, int[] selectedArtists, int[] selectedGenres, int[] selectedAlbums)
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

            ViewData["Artists"] = new SelectList(await _context.Artists.ToListAsync(), "ArtistId", "ArtistName");
            ViewData["Genres"] = new SelectList(await _context.Genres.ToListAsync(), "GenreId", "GenreName");
            ViewData["Albums"] = new SelectList(await _context.Albums.ToListAsync(), "AlbumId", "AlbumName");
            return View(song);
        }
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> AlbumDetails(int? id)
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
            ViewData["Artists"] = new SelectList(await _context.Artists.ToListAsync(), "ArtistId", "ArtistName");
            ViewData["Genres"] = new SelectList(await _context.Genres.ToListAsync(), "GenreId", "GenreName");
            ViewData["Songs"] = new SelectList(await _context.Songs.ToListAsync(), "SongId", "SongTitle");
            return View();
        }

        // POST: Products/CreateAlbum
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateAlbum([Bind("AlbumId,AlbumName,AlbumPrice,AlbumCover")] Album album, int[] selectedArtists, int[] selectedGenres, int[] selectedSongs)
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

            ViewData["Artists"] = new SelectList(await _context.Artists.ToListAsync(), "ArtistId", "ArtistName");
            ViewData["Genres"] = new SelectList(await _context.Genres.ToListAsync(), "GenreId", "GenreName");
            ViewData["Songs"] = new SelectList(await _context.Songs.ToListAsync(), "SongId", "SongTitle");
            return View(album);
        }

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

            ViewData["Artists"] = new SelectList(await _context.Artists.ToListAsync(), "ArtistId", "ArtistName", album.Artists.Select(a => a.ArtistId));
            ViewData["Genres"] = new SelectList(await _context.Genres.ToListAsync(), "GenreId", "GenreName", album.Genres.Select(g => g.GenreId));
            ViewData["Songs"] = new SelectList(await _context.Songs.ToListAsync(), "SongId", "SongTitle", album.Songs.Select(s => s.SongId));
            ViewData["SelectedArtists"] = album.Artists.Select(a => a.ArtistId).ToList();
            ViewData["SelectedGenres"] = album.Genres.Select(g => g.GenreId).ToList();
            ViewData["SelectedSongs"] = album.Songs.Select(s => s.SongId).ToList();

            return View(album);
        }

        // POST: Products/EditAlbum/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAlbum(int id, [Bind("AlbumId,AlbumName,AlbumPrice,AlbumCover")] Album album, int[] selectedArtists, int[] selectedGenres, int[] selectedSongs)
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

            ViewData["Artists"] = new SelectList(await _context.Artists.ToListAsync(), "ArtistId", "ArtistName");
            ViewData["Genres"] = new SelectList(await _context.Genres.ToListAsync(), "GenreId", "GenreName");
            ViewData["Songs"] = new SelectList(await _context.Songs.ToListAsync(), "SongId", "SongTitle");
            return View(album);
        }

        // GET: Products/DeleteAlbum/5
        public async Task<IActionResult> DeleteAlbum(int? id)
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
        public async Task<IActionResult> DeleteAlbumConfirmed(int id)
        {
            var album = await _context.Albums.FindAsync(id);
            if (album != null)
            {
                _context.Albums.Remove(album);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private SelectList GetAllGenresList()
        {
            List<Genre> genres = _context.Genres.ToList();

            return new SelectList(genres);
        }

        private bool SongExists(int id)
        {
            return _context.Songs.Any(e => e.SongId == id);
        }

        private bool AlbumExists(int id)
        {
            return _context.Albums.Any(e => e.AlbumId == id);
        }

        #endregion
    }
}