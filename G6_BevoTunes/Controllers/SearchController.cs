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
        public async Task<IActionResult> Index(String sortOrder)
        {   
                if (TempData["SelectedCustomerId"] != null)
                {
                    TempData.Keep("SelectedCustomerId");
                    TempData.Keep("SelectedCustomerEmail");

                    string selectedCustomerId = TempData["SelectedCustomerId"].ToString();
                    
                    var activeOrder = await _context.Orders
                        .FirstOrDefaultAsync(o => o.Customer.Id == selectedCustomerId 
                                            && o.OrderStatus == OrderStatus.InCart);
                    
                    if (activeOrder != null)
                    {
                        TempData["OrderId"] = activeOrder.OrderID;
                    }
                    else
                    {
                        TempData.Remove("OrderId"); 
                    }

                    TempData.Keep("OrderId");
                }
            
            List<Song> songs = await _context.Songs
                .Include(s => s.Artists)
                .Include(s => s.Genres)
                .Include(s => s.Albums)
                .Include(s => s.Reviews.Where(r => r.Status == ReviewStatus.Approve))
                .Include(s => s.Promotions)
                .ToListAsync();

            List<Album> albums = await _context.Albums
                .Include(a => a.Artists)
                .Include(a => a.Genres)
                .Include(a => a.Promotions)
                // .Include(a => a.Songs)
                // .Include(a => a.Reviews)
                .ToListAsync();

            switch (sortOrder)
            {
                case "title_desc":
                    songs = songs.OrderByDescending(s => s.SongTitle).ToList();
                    albums = albums.OrderByDescending(a => a.AlbumName).ToList();
                    break;
                
                case "title_asc":
                    songs = songs.OrderBy(s => s.SongTitle).ToList();
                    albums = albums.OrderBy(a => a.AlbumName).ToList();
                    break;
                    
                case "genre":
                    songs = songs.OrderBy(s => s.Genres != null && s.Genres.Any() ? s.Genres.FirstOrDefault().GenreName : string.Empty).ToList();
                    albums = albums.OrderBy(a => a.Genres != null && a.Genres.Any() ? a.Genres.FirstOrDefault().GenreName : string.Empty).ToList();
                    break;
                
                case "genre_desc":
                    songs = songs.OrderByDescending(s => s.Genres != null && s.Genres.Any() ? s.Genres.FirstOrDefault().GenreName : string.Empty).ToList();
                    albums = albums.OrderByDescending(a => a.Genres != null && a.Genres.Any() ? a.Genres.FirstOrDefault().GenreName : string.Empty).ToList();
                    break;
                    
                case "rating_desc":
                    songs = songs.OrderByDescending(s => s.Reviews != null && s.Reviews.Any() ? s.Reviews.Average(r => r.Rating) : 0).ToList();
                    albums = albums.OrderByDescending(a => a.Reviews != null && a.Reviews.Any() ? a.Reviews.Average(r => r.Rating) : 0).ToList();
                    break;
                
                case "rating_asc":
                    songs = songs.OrderBy(s => s.Reviews != null && s.Reviews.Any() ? s.Reviews.Average(r => r.Rating) : 0).ToList();
                    albums = albums.OrderBy(a => a.Reviews != null && a.Reviews.Any() ? a.Reviews.Average(r => r.Rating) : 0).ToList();
                    break;
                    
                default: // "title_asc" acts as the default fallback
                    songs = songs.OrderBy(s => s.SongTitle).ToList();
                    albums = albums.OrderBy(a => a.AlbumName).ToList();
                    break;
            }

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
        public async Task<IActionResult> DisplayAlbumSearchResults(AlbumSearchViewModel asvm, int[] selectedGenres, String sortOrder, string SelectedCustomerId = null, string SelectedCustomerEmail = null)
        {
            if (!string.IsNullOrEmpty(SelectedCustomerId))
            {
                TempData["SelectedCustomerId"] = SelectedCustomerId;
                TempData["SelectedCustomerEmail"] = SelectedCustomerEmail;
            }

            var albumQuery = _context.Albums.AsQueryable();
            
            if (!string.IsNullOrEmpty(asvm.AlbumName))
            {
                albumQuery = albumQuery.Where(a => a.AlbumName.Contains(asvm.AlbumName) && a.IsActive);
            }

            if (!string.IsNullOrEmpty(asvm.ArtistName))
            {
                albumQuery = albumQuery.Where(a => a.Artists.Any(ar => ar.ArtistName.Contains(asvm.ArtistName) && ar.IsActive));
            }

            if (selectedGenres != null && selectedGenres.Length > 0)
            {
                albumQuery = albumQuery.Where(a => a.Genres.Any(g => selectedGenres.Contains(g.GenreId) && g.IsActive));
            }

            if (asvm.Rating != 0.0m)
            {
                if (asvm.RatingBound == RatingBound.GreaterThan)
                {
                    albumQuery = albumQuery.Where(a => a.Reviews.Any() && (decimal)a.Reviews.Average(r => r.Rating) >= asvm.Rating);
                }
                else
                {
                    albumQuery = albumQuery.Where(a => a.Reviews.Any() && (decimal)a.Reviews.Average(r => r.Rating) <= asvm.Rating);
                }
            }

            // Apply Sorting
            switch (sortOrder)
            {
                case "title_desc":
                    albumQuery = albumQuery.OrderByDescending(a => a.AlbumName);
                    break;
                case "genre_asc":
                    albumQuery = albumQuery.OrderBy(a => a.Genres.Any() ? a.Genres.FirstOrDefault().GenreName : string.Empty);
                    break;
                case "genre_desc":
                    albumQuery = albumQuery.OrderByDescending(a => a.Genres.Any() ? a.Genres.FirstOrDefault().GenreName : string.Empty);
                    break;
                case "rating_desc":
                    albumQuery = albumQuery.OrderByDescending(a => a.Reviews.Any() ? a.Reviews.Average(r => r.Rating) : 0);
                    break;
                case "rating_asc":
                    albumQuery = albumQuery.OrderBy(a => a.Reviews.Any() ? a.Reviews.Average(r => r.Rating) : 0);
                    break;
                case "title_asc": 
                default: // Default fallback is Title A-Z
                    albumQuery = albumQuery.OrderBy(a => a.AlbumName);
                    break;
            }

            var results = await albumQuery
                            .Include(a => a.Artists)
                            .Include(a => a.Genres)
                            .Include(a => a.Reviews.Where(r => r.Status == ReviewStatus.Approve))
                            .Include(a => a.Promotions)
                            .ToListAsync();

            ProductsViewModel pvm = new ProductsViewModel { Albums = results };

            // Save state to ViewBag
            ViewBag.SearchAlbumName = asvm.AlbumName;
            ViewBag.SearchArtistName = asvm.ArtistName;
            ViewBag.SearchRating = asvm.Rating;
            ViewBag.SearchRatingBound = asvm.RatingBound;
            ViewBag.CurrentGenres = selectedGenres;
            ViewBag.CurrentAction = "DisplayAlbumSearchResults"; // Tells the Index view where to post back to!

            TempData["DisplayAlbumsMessage"] = "Displaying " + results.Count() + " of " + _context.Albums.Count() + " albums";
            return View("Index", pvm);
        }

        // Song Search
        public async Task<IActionResult> DisplaySongSearchResults(SongSearchViewModel ssvm, int[] selectedGenres, String sortOrder, string SelectedCustomerId = null, string SelectedCustomerEmail = null)
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

            if (selectedGenres != null && selectedGenres.Length > 0)
            {
                songQuery = songQuery.Where(s => s.Genres.Any(g => selectedGenres.Contains(g.GenreId) && g.IsActive));
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

            // Expanded Sorting Logic
            switch (sortOrder)
            {
                case "title_desc":
                    songQuery = songQuery.OrderByDescending(s => s.SongTitle);
                    break;
                case "genre_asc":
                    songQuery = songQuery.OrderBy(s => s.Genres.Any() ? s.Genres.FirstOrDefault().GenreName : string.Empty);
                    break;
                case "genre_desc":
                    songQuery = songQuery.OrderByDescending(s => s.Genres.Any() ? s.Genres.FirstOrDefault().GenreName : string.Empty);
                    break;
                case "rating_desc":
                    songQuery = songQuery.OrderByDescending(s => s.Reviews.Any() ? s.Reviews.Average(r => r.Rating) : 0);
                    break;
                case "rating_asc":
                    songQuery = songQuery.OrderBy(s => s.Reviews.Any() ? s.Reviews.Average(r => r.Rating) : 0);
                    break;
                case "title_asc": 
                default: // Default fallback is Title A-Z
                    songQuery = songQuery.OrderBy(s => s.SongTitle);
                    break;
            }

            var results = await songQuery
                            .Include(s => s.Artists)
                            .Include(s => s.Genres)
                            .Include(s => s.Reviews.Where(r => r.Status == ReviewStatus.Approve))
                            .Include(s => s.Promotions)
                            .ToListAsync();

            ProductsViewModel pvm = new ProductsViewModel { Songs = results };

            // Save state to ViewBag
            ViewBag.SearchSongTitle = ssvm.SongTitle;
            ViewBag.SearchAlbumName = ssvm.AlbumName;
            ViewBag.SearchArtistName = ssvm.ArtistName;
            ViewBag.SearchRating = ssvm.Rating;
            ViewBag.SearchRatingBound = ssvm.RatingBound;
            ViewBag.CurrentGenres = selectedGenres;
            ViewBag.CurrentAction = "DisplaySongSearchResults"; // Tells the Index view where to post back to!

            TempData["DisplaySongsMessage"] = "Displaying " + results.Count() + " of " + _context.Songs.Count() + " songs";
            return View("Index", pvm);
        }   

        // Artist Search
        public async Task<IActionResult> DisplayArtistSearchResults(ArtistSearchViewModel asvm, int[] selectedGenres,  String sortOrder, string SelectedCustomerId = null, string SelectedCustomerEmail = null)
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
            if (selectedGenres != null && selectedGenres.Length > 0)
            {
                artistQuery = artistQuery.Where(ar => ar.Genres.Any(g => selectedGenres.Contains(g.GenreId) && g.IsActive));
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

            switch (sortOrder)
            {
                case "title_desc":
                    artistQuery = artistQuery.OrderByDescending(a => a.ArtistName);
                    break;
                
                case "title_asc":
                    artistQuery = artistQuery.OrderBy(a => a.ArtistName);
                    break;
                    
                case "rating_desc":
                    artistQuery = artistQuery.OrderByDescending(a => a.Reviews.Any() ? a.Reviews.Average(r => r.Rating) : 0);
                    break;
                
                case "rating_asc":
                    artistQuery = artistQuery.OrderBy(a => a.Reviews.Any() ? a.Reviews.Average(r => r.Rating) : 0);
                    break;
                    
                default: // "title_asc" acts as the default fallback
                    artistQuery = artistQuery.OrderBy(a => a.ArtistName);
                    break;
            }

            // Execute query
            var results = await artistQuery
                            .Include(ar => ar.Genres)
                            .Include(ar => ar.Albums)
                            .Include(ar => ar.Songs)
                            .Include(ar => ar.Reviews.Where(r => r.Status == ReviewStatus.Approve))
                            .ToListAsync();

            ViewBag.SearchName = asvm.ArtistName;
            ViewBag.SearchRating = asvm.Rating;
            ViewBag.SearchRatingBound = asvm.RatingBound;
            ViewBag.CurrentGenres = selectedGenres;
            ViewBag.SelectedCustomerId = SelectedCustomerId;
            ViewBag.SelectedCustomerEmail = SelectedCustomerEmail;
            TempData["DisplayArtistsMessage"] = "Displaying " + results.Count() + " of " + _context.Artists.Count() + " artists";
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