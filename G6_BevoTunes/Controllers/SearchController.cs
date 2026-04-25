using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using G6_BevoTunes.DAL;
using G6_BevoTunes.Models;
using Microsoft.AspNetCore.Authorization;

namespace G6_BevoTunes.Controllers
{
    public class SearchController : Controller
    {
        private readonly AppDbContext _context;

        public SearchController(AppDbContext context)
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
                // .Include(a => a.Songs)
                // .Include(a => a.Reviews)
                .ToListAsync();

            ProductsViewModel pvm = new ProductsViewModel();

            pvm.Albums = albums;
            pvm.Songs = songs;

            return View(pvm);
        }

        public async Task<IActionResult> SearchArtists()
        {
            ViewBag.AllGenres = GetAllGenresList();
            return View();
        }

        public async Task<IActionResult> SearchAlbums()
        {
            ViewBag.AllGenres = GetAllGenresList();
            return View();
        }

        public async Task<IActionResult> SearchSongs()
        {
            ViewBag.AllGenres = GetAllGenresList();
            return View();
        }

        // Album Search
        public async Task<IActionResult> DisplayAlbumSearchResults(AlbumSearchViewModel asvm, string SelectedCustomerId = null, string SelectedCustomerEmail = null)
        {
            // Restore customer context from form values
            if (!string.IsNullOrEmpty(SelectedCustomerId))
            {
                TempData["SelectedCustomerId"] = SelectedCustomerId;
                TempData["SelectedCustomerEmail"] = SelectedCustomerEmail;
            }

            var albumQuery = _context.Albums.AsQueryable();
            var artistQuery = _context.Artists.AsQueryable();

            // Filter by Name (applies to all)
            if (!String.IsNullOrEmpty(asvm.AlbumName))
            {
                albumQuery = albumQuery.Where(a => a.AlbumName.Contains(asvm.AlbumName) && a.IsActive);
            }

            if (!String.IsNullOrEmpty(asvm.ArtistName))
            {
                albumQuery = albumQuery.Where(a => a.Artists // for all artists,
                                                .Any(ar => ar.ArtistName.Contains(asvm.ArtistName) && ar.IsActive)); // the artist name contains the searched string
            }

            // Filter by Genre; we probably have to set up the "null" or all genres value, or be lazy and set to null
            if (asvm != null && asvm.Genres.Count > 0)
            {
                albumQuery = albumQuery.Where(a => a.Genres.Any(g => asvm.Genres.Contains(g.GenreId) && g.IsActive));
            }

            // Filter by ratings
            if (asvm.Rating != 0.0m)
            {
                if (asvm.RatingBound == RatingBound.GreaterThan)
                {
                    albumQuery = albumQuery.Where(a => (decimal)a.Reviews.Average(r => r.Rating) >= asvm.Rating);
                }
                else
                {
                    albumQuery = albumQuery.Where(a => (decimal)a.Reviews.Average(r => r.Rating) <= asvm.Rating);
                }
            }

            var results = albumQuery
                            .Include(s => s.Artists)
                            .Include(s => s.Genres)
                            .Include(s => s.Songs)
                            .Include(s => s.Reviews)
                            .Include(s => s.Promotions)
                            .ToList();

            ProductsViewModel pvm = new ProductsViewModel();
            pvm.Albums = results;

            return View("Index", pvm);
        }
        
        // Song Search
        public Task<IActionResult> DisplaySongSearchResults(SongSearchViewModel ssvm, string SelectedCustomerId = null, string SelectedCustomerEmail = null)
        {
            if (!string.IsNullOrEmpty(SelectedCustomerId))
            {
                TempData["SelectedCustomerId"] = SelectedCustomerId;
                TempData["SelectedCustomerEmail"] = SelectedCustomerEmail;
            }

            var songQuery = _context.Songs.AsQueryable();

            if (!String.IsNullOrEmpty(ssvm.SongTitle))
            {
                songQuery = songQuery.Where(s => s.SongTitle.Contains(ssvm.SongTitle) && s.IsActive);
            }

            if (!String.IsNullOrEmpty(ssvm.AlbumName))
            {
                songQuery = songQuery.Where(s => s.Albums.Any(a => a.AlbumName.Contains(ssvm.AlbumName) && a.IsActive));
            }

            if (!String.IsNullOrEmpty(ssvm.ArtistName))
            {
                songQuery = songQuery.Where(s => s.Artists.Any(ar => ar.ArtistName.Contains(ssvm.ArtistName) && ar.IsActive));
            }

            if (ssvm.Genres != null && ssvm.Genres.Count > 0)
            {
                songQuery = songQuery.Where(s => s.Genres.Any(g => ssvm.Genres.Contains(g.GenreId)));
            }

            if (ssvm.Rating != 0.0m)
            {
                if (ssvm.RatingBound == RatingBound.GreaterThan)
                {
                    songQuery = songQuery.Where(s => s.Reviews.Any() && (decimal)s.Reviews.Average(r => r.Rating) >= ssvm.Rating);
                }
                else
                {
                    songQuery = songQuery.Where(s => s.Reviews.Any() && (decimal)s.Reviews.Average(r => r.Rating) <= ssvm.Rating);
                }
            }
            var results = songQuery
                            .Include(s => s.Artists)
                            .Include(s => s.Genres)
                            .Include(s => s.Albums)
                            .Include(s => s.Reviews)
                            .Include(s => s.Promotions)
                            .ToList();

            ProductsViewModel pvm = new ProductsViewModel { Songs = results };

            return Task.FromResult<IActionResult>(View("Index", pvm));
        }

        // Artist Search
        public async Task<IActionResult> DisplayArtistSearchResults(ArtistSearchViewModel asvm, string SelectedCustomerId = null, string SelectedCustomerEmail = null)
        {
            // Restore customer context from form values
            if (!string.IsNullOrEmpty(SelectedCustomerId))
            {
                TempData["SelectedCustomerId"] = SelectedCustomerId;
                TempData["SelectedCustomerEmail"] = SelectedCustomerEmail;
            }

            var artistQuery = _context.Artists.AsQueryable();

            // Filter by Artist Name
            if (!String.IsNullOrEmpty(asvm.ArtistName))
            {
                artistQuery = artistQuery.Where(ar => ar.ArtistName.Contains(asvm.ArtistName) && ar.IsActive);
            }

            // Filter by Genre
            if (asvm.Genres != null && asvm.Genres.Count > 0)
            {
                artistQuery = artistQuery.Where(ar => ar.Genres.Any(g => asvm.Genres.Contains(g.GenreId) && g.IsActive));
            }

            // Filter by ratings
            if (asvm.Rating != 0.0m)
            {
                if (asvm.RatingBound == RatingBound.GreaterThan)
                {
                    artistQuery = artistQuery.Where(ar => (decimal)ar.Reviews.Average(r => r.Rating) >= asvm.Rating);
                }
                else
                {
                    artistQuery = artistQuery.Where(ar => (decimal)ar.Reviews.Average(r => r.Rating) <= asvm.Rating);
                }
            }

            // Execute query
            var results = await artistQuery
                            .Include(ar => ar.Genres)
                            .Include(ar => ar.Albums)
                            .Include(ar => ar.Songs)
                            .Include(ar => ar.Reviews)
                            .ToListAsync();

            return View("ArtistSearchResults", results);
        }

        // Artist Search Results
        public IActionResult ArtistSearchResults(IEnumerable<Artist> artists)
        {
            return View(artists);
        } 

        private SelectList GetAllGenresList()
        {
            var genres = _context.Genres.OrderBy(g => g.GenreName).ToList();
            return new SelectList(genres, "GenreId", "GenreName");
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