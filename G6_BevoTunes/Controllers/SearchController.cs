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
        public async Task<IActionResult> DisplaySearchResults(AlbumSearchViewModel asvm)
        {
            var albumQuery = _context.Albums.AsQueryable();
            var artistQuery = _context.Artists.AsQueryable();

            // Filter by Name (applies to all)
            if (!String.IsNullOrEmpty(asvm.AlbumName))
            {
                albumQuery = albumQuery.Where(a => a.AlbumName.Contains(asvm.AlbumName));
            }

            if (!String.IsNullOrEmpty(asvm.ArtistName))
            {
                albumQuery = albumQuery.Where(a => a.Artists // for all artists,
                                                .Any(ar => ar.ArtistName.Contains(asvm.ArtistName))); // the artist name contains the searched string
            }

            // Filter by Genre; we probably have to set up the "null" or all genres value, or be lazy and set to null
            if (asvm.Genre != 0)
            {
                albumQuery = albumQuery.Where(a => a.Genres.Any(g => g.GenreId == asvm.Genre));
            }

            // Filter by ratings
            if (asvm.Rating != 1.0m)
            {
                if (asvm.RatingBound == RatingBound.GreaterThan)
                {
                    albumQuery = albumQuery.Where(a => a.AverageRating >= asvm.Rating);
                }
                else
                {
                    albumQuery = albumQuery.Where(a => a.Reviews.Sum(r => r.Rating) <= asvm.Rating);
                }
            }

            var results = albumQuery
                            .Include(s => s.Artists)
                            .Include(s => s.Genres)
                            .Include(s => s.Songs)
                            .Include(s => s.Reviews)
                            .Include(s => s.Promotions)
                            .ToList();

            return View("Index", results);
        }
        
        // Song Search
        public Task<IActionResult> DisplaySearchResults(SongSearchViewModel ssvm)
        {
            var songQuery = _context.Songs.AsQueryable();

            // Filter by Song Title
            if (!String.IsNullOrEmpty(ssvm.SongTitle))
            {
                songQuery = songQuery.Where(s => s.SongTitle.Contains(ssvm.SongTitle));
            }

            // Filter by Album Name
            if (!String.IsNullOrEmpty(ssvm.AlbumName))
            {
                songQuery = songQuery.Where(s => s.Albums.Any(a => a.AlbumName.Contains(ssvm.AlbumName)));
            }

            if (!String.IsNullOrEmpty(ssvm.ArtistName))
            {
                songQuery = songQuery.Where(s => s.Artists // for all artists,
                                                .Any(ar => ar.ArtistName.Contains(ssvm.ArtistName)));
            }

            // Filter by Genre
            if (ssvm.Genre != 0)
            {
                songQuery = songQuery.Where(s => s.Genres.Any(g => g.GenreId == ssvm.Genre));
            }

            // Filter by ratings
            if (ssvm.Rating != 1.0m)
            {
                if (ssvm.RatingBound == RatingBound.GreaterThan)
                {
                    songQuery = songQuery.Where(s => s.AverageRating >= ssvm.Rating);
                }
                else
                {
                    songQuery = songQuery.Where(s => s.Reviews.Sum(r => r.Rating) <= ssvm.Rating);
                }
            }

            // Execute queries
            var results = songQuery
                            .Include(s => s.Artists)
                            .Include(s => s.Genres)
                            .Include(s => s.Albums)
                            .Include(s => s.Reviews)
                            .Include(s => s.Promotions)
                            .ToList();

            return Task.FromResult<IActionResult>(View("Index", results));
        }

        // Artist Search
        public Task<IActionResult> DisplaySearchResults(ArtistSearchViewModel asvm)
        {
            var artistQuery = _context.Artists.AsQueryable();

            // Filter by Artist Name
            if (!String.IsNullOrEmpty(asvm.ArtistName))
            {
                artistQuery = artistQuery.Where(ar => ar.ArtistName.Contains(asvm.ArtistName));
            }

            // Filter by Genre
            if (asvm.Genre != 0)
            {
                artistQuery = artistQuery.Where(ar => ar.Genres.Any(g => g.GenreId == asvm.Genre));
            }

            // Filter by ratings
            if (asvm.Rating != 1.0m)
            {
                if (asvm.RatingBound == RatingBound.GreaterThan)
                {
                    artistQuery = artistQuery.Where(ar => ar.Reviews.Sum(r => r.Rating) >= asvm.Rating);
                }
                else
                {
                    artistQuery = artistQuery.Where(ar => ar.Reviews.Sum(r => r.Rating) <= asvm.Rating);
                }
            }

            // Execute query
            var results = artistQuery
                            .Include(ar => ar.Genres)
                            .Include(ar => ar.Albums)
                            .Include(ar => ar.Songs)
                            .Include(ar => ar.Reviews)
                            .ToList();

            return Task.FromResult<IActionResult>(View("Index", results));
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