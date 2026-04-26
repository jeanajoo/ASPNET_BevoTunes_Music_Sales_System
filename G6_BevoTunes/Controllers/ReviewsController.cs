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
using Microsoft.CodeAnalysis.Elfie.Serialization;
using Microsoft.AspNetCore.Identity;
using System.Diagnostics.Eventing.Reader;
using NuGet.Protocol;

namespace G6_BevoTunes.Controllers
{
    [Authorize(Roles = "Customer, Admin, Employee")]
    public class ReviewsController : Controller
    {
        private readonly AppDbContext _context;

        private readonly UserManager<AppUser> _userManager;

        public ReviewsController(AppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Reviews
        [Authorize(Roles= "Customer, Admin, Employee")]
        public async Task<IActionResult> Index()
        {
            AppUser user = await _userManager.GetUserAsync(User);

            var ownedSongs = GetOwnedSongs(user);
            var ownedAlbums = GetOwnedAlbums(user);
            var ownedArtists = GetOwnedArtists(user);

            ViewBag.hasProduct = ownedSongs.Any() || ownedAlbums.Any() || ownedArtists.Any();
            
            var userId = _userManager.GetUserId(User);
            if (User.IsInRole("Admin") || User.IsInRole("Employee")) {
                return View(await _context.Reviews.Include(r => r.Reviewer).
                Include(r => r.Artist).Include(r => r.Song).Include(r => r.Album)
                .OrderByDescending(r => r.Reviewer.Id == userId).ThenBy(r => r.Status).ToListAsync());
            }
            
            return View(await _context.Reviews.Include(r => r.Reviewer).
                Include(r => r.Artist).Include(r => r.Song).Include(r => r.Album)
                .Where(r => r.Status == ReviewStatus.Approve || (r.Status == ReviewStatus.Pending && r.Reviewer.Id == userId))
                .OrderByDescending(r => r.Reviewer.Id == userId).ThenBy(r => r.Status).ToListAsync());

        }

        // GET: Reviews/Details/5
        [Authorize(Roles= "Customer, Admin, Employee")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var review = await _context.Reviews
                .Include(r => r.Reviewer)
                .Include(r => r.Approver)
                .Include(r => r.Song).Include(r => r.Album)
                .Include(r => r.Artist).FirstOrDefaultAsync(m => m.ReviewID == id);

            if (review == null)
            {
                return NotFound();
            }

            return View(review);
        }

        private List<Song> GetOwnedSongs(AppUser user)
        {
            if (user == null)
                return new List<Song>();
                
            return _context.OrderDetails
                .Include(od => od.Order)
                .Include(od => od.Song)
                .Where(od => od.Order != null && od.Order.Recipient != null && od.Order.Recipient.Id == user.Id 
                && od.Song != null && od.Order.OrderStatus == OrderStatus.Ordered)
                .Select(od => od.Song)
                .Distinct()
                .ToList();
        }

        private List<Song> GetOwnedAlbumSongs (AppUser user)
        {
            if (user == null)
                return new List<Song>();

            return _context.OrderDetails
                .Include(od => od.Order)
                .Include(od => od.Album)
                .ThenInclude(a => a.Songs)
                .Where(od => od.Order != null && od.Order.Recipient != null && od.Order.Recipient.Id == user.Id 
                && od.Album != null && od.Order.OrderStatus == OrderStatus.Ordered)
                .SelectMany(od => od.Album.Songs)
                .Distinct()
                .ToList();
        }

        private List<Album> GetOwnedAlbums(AppUser user)
        {
            if (user == null)
                return new List<Album>();
                
            return _context.OrderDetails
                .Include(od => od.Order)
                .Include(od => od.Album)
                .Where(od => od.Order != null && od.Order.Recipient != null && od.Order.Recipient.Id == user.Id 
                && od.Album != null && od.Order.OrderStatus == OrderStatus.Ordered)
                .Select(od => od.Album)
                .Distinct()
                .ToList();
        }

        private List<Artist> GetOwnedArtists(AppUser user)
        {
            if (user == null)
                return new List<Artist>();
                
            HashSet<Artist> ownSongsArtists = _context.OrderDetails
                .Where(od => od.Order != null && od.Order.Recipient != null && od.Order.Recipient.Id == user.Id 
                && od.Song != null && od.Order.OrderStatus == OrderStatus.Ordered)
                .Include(od => od.Song)
                .ThenInclude(s => s.Artists)
                .SelectMany(od => od.Song.Artists)
                .Distinct()
                .ToHashSet();

            HashSet<Artist> ownAlbumsArtists = _context.OrderDetails
                .Where(od => od.Order != null && od.Order.Recipient != null && od.Order.Recipient.Id == user.Id 
                && od.Album != null && od.Order.OrderStatus == OrderStatus.Ordered)
                .Include(od => od.Album)
                .ThenInclude(s => s.Artists)
                .SelectMany(od => od.Album.Artists)
                .Distinct()
                .ToHashSet();

            return ownSongsArtists.Union(ownAlbumsArtists).ToList();
        }

        private bool OwnsSong(AppUser user, int songId)
        {
            if (user == null)
                return false;
            return GetOwnedSongs(user).Any(s => s.SongId == songId) || GetOwnedAlbumSongs(user).Any(s => s.SongId == songId);
        }

        private bool OwnsAlbum(AppUser user, int albumId)
        {
            if (user == null)
                return false;
            return GetOwnedAlbums(user).Any(a => a.AlbumId == albumId);
        }

        private bool OwnsArtist(AppUser user, int artistId)
        {
            if (user == null)
                return false;
            return GetOwnedArtists(user).Any(a => a.ArtistId == artistId);
        }

        // GET: Reviews/Create
        [Authorize(Roles = "Customer")]
        public IActionResult Create(int? songId, int? albumId, int? artistId)
        {
            AppUser user = _userManager.GetUserAsync(User).Result;

            var ownedSongs = GetOwnedSongs(user);
            var ownedAlbumSongs = GetOwnedAlbumSongs(user);
            var ownedAlbums = GetOwnedAlbums(user);
            var ownedArtists = GetOwnedArtists(user);
            
            bool hasProduct = ownedSongs.Any() || ownedAlbums.Any() || ownedArtists.Any();

            if (hasProduct == false)
            {
                return Unauthorized();
            }

            // Validate ownership if specific product is provided
            if (songId.HasValue && !OwnsSong(user, songId.Value))
            {
                return Unauthorized();
            }
            if (albumId.HasValue && !OwnsAlbum(user, albumId.Value))
            {
                return Unauthorized();
            }
            if (artistId.HasValue && !OwnsArtist(user, artistId.Value))
            {
                return Unauthorized();
            }

            var allSongs = ownedSongs.Union(ownedAlbumSongs).ToList();

            ViewBag.OwnedSongs = new SelectList(allSongs, "SongId", "SongTitle", songId);
            ViewBag.OwnedAlbums = new SelectList(ownedAlbums, "AlbumId", "AlbumName", albumId);
            ViewBag.OwnedArtists = new SelectList(ownedArtists, "ArtistId", "ArtistName", artistId);
            ViewBag.HasProduct = hasProduct;
            
            // Set the product type if one was provided as a query parameter
            if (songId.HasValue)
            {
                ViewBag.SelectedProductType = "Song";
                ViewBag.SelectedProductId = songId;
            }
            else if (albumId.HasValue)
            {
                ViewBag.SelectedProductType = "Album";
                ViewBag.SelectedProductId = albumId;
            }
            else if (artistId.HasValue)
            {
                ViewBag.SelectedProductType = "Artist";
                ViewBag.SelectedProductId = artistId;
            }
    
            return View();
        }

        // POST: Reviews/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> Create([Bind("ReviewID,Description,Rating,Status")] Review review, int? SelectedSong, 
        int? SelectedAlbum, int? SelectedArtist)
        {
            AppUser user = await _userManager.GetUserAsync(User);

            var ownedSongs = GetOwnedSongs(user);

            var ownedAlbums = GetOwnedAlbums(user);

            var ownedArtists = GetOwnedArtists(user);

            var ownedAlbumSongs = GetOwnedAlbumSongs(user);

            bool hasProduct = ownedSongs.Any() || ownedAlbums.Any() || ownedArtists.Any();
            
            var allSongs = ownedSongs.Union(ownedAlbumSongs).ToList();

            ModelState.Remove("Reviewer");

            if (ModelState.IsValid)
            {
                review.Reviewer = user;
                // review.ReviewerID = user.Id;
                    
                ViewBag.OwnedSongs = new SelectList(allSongs, "SongId", "SongTitle");
                ViewBag.OwnedAlbums = new SelectList(ownedAlbums, "AlbumId", "AlbumName");
                ViewBag.OwnedArtists = new SelectList(ownedArtists, "ArtistId", "ArtistName");

                if (SelectedSong != null)
                {
                    review.Song = _context.Songs.Find(SelectedSong);
                }
                else if (SelectedAlbum != null)
                {
                    review.Album = _context.Albums.Find(SelectedAlbum);
                }
                else if (SelectedArtist != null)
                {
                    review.Artist = _context.Artists.Find(SelectedArtist);
                }
                                

                if (!hasProduct)
                {
                    return RedirectToAction("Index");
                }
                
                review.Status = ReviewStatus.Pending;

                review.Reviewer = user;

                _context.Add(review);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            ViewBag.OwnedSongs = new SelectList(allSongs, "SongId", "SongTitle");
            ViewBag.OwnedAlbums = new SelectList(ownedAlbums, "AlbumId", "AlbumName");
            ViewBag.OwnedArtists = new SelectList(ownedArtists, "ArtistId", "ArtistName");
            ViewBag.HasProduct = hasProduct;

            return View(review);
        }

        // GET: Reviews/Edit/5
        [Authorize(Roles = "Customer, Admin, Employee")]
        public async Task<IActionResult> Edit(int? id)
        {
            
            if (id == null)
            {
                return NotFound();
            }

            var review = await _context.Reviews.Include(r => r.Reviewer).Include(r => r.Song).Include(r => r.Album)
                .Include(r => r.Artist).FirstOrDefaultAsync(r => r.ReviewID == id);

            if (review == null)
            {
                return NotFound();
            }

            if (review.Reviewer.Id != _userManager.GetUserId(User) && !User.IsInRole("Admin") && !User.IsInRole("Employee"))
            {
                return Unauthorized();
            } else if(review.Status == ReviewStatus.Deleted)
            {
                return Unauthorized();
            }

            return View(review);
        }

        // POST: Reviews/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Customer, Admin, Employee")]
        public async Task<IActionResult> Edit(int id, [Bind("ReviewID,Description,Rating,Status")] Review review)
        {
            if (id != review.ReviewID)
            {
                return NotFound();
            }

            var dbReview = await _context.Reviews
                .Include(r => r.Reviewer)
                .FirstOrDefaultAsync(r => r.ReviewID == id);

            if (dbReview == null)
            {
                return NotFound();
            }

            if (dbReview.Reviewer.Id != _userManager.GetUserId(User) && !User.IsInRole("Admin") && !User.IsInRole("Employee"))
            {
                return Unauthorized();
            } else if (review.Status == ReviewStatus.Deleted)
            {
                return Unauthorized();
            }

            ModelState.Remove("Reviewer");

            if (ModelState.IsValid)
            {
                try
                {
                    // Update the properties from the form input
                    dbReview.Description = review.Description;
                    dbReview.Rating = review.Rating;
                    dbReview.Status = review.Status;

                    _context.Update(dbReview);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReviewExists(review.ReviewID))
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
            return View(dbReview);
        }

        // GET: Reviews/Delete/5
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var review = await _context.Reviews.Include(r => r.Song)
                .Include(r => r.Album).Include(r => r.Artist)
                .FirstOrDefaultAsync(m => m.ReviewID == id);

            if (review.Status == ReviewStatus.Deleted)
            {
                return Unauthorized();
            }
            
            if (review == null)
            {
                return NotFound();
            }

            return View(review);
        }

        // POST: Reviews/Delete/5
        [Authorize(Roles = "Customer")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var review = await _context.Reviews.FindAsync(id);

            if (review.Status == ReviewStatus.Deleted)
            {
                return Unauthorized();
            }
                        
            if (review != null && review.Description != "")
            {
                review.Description = "";
                review.Status = ReviewStatus.Deleted;
                _context.Update(review);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReviewExists(int id)
        {
            return _context.Reviews.Any(e => e.ReviewID == id);
        }
    }
}
