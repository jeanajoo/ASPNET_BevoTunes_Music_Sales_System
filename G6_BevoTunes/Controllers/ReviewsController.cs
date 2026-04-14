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

namespace G6_BevoTunes.Controllers
{
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
        public async Task<IActionResult> Index()
        {
            return View(await _context.Reviews.ToListAsync());
        }

        // GET: Reviews/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var review = await _context.Reviews
                .FirstOrDefaultAsync(m => m.ReviewID == id);

            if (review == null)
            {
                return NotFound();
            }

            return View(review);
        }

        private List<Song> GetOwnedSongs(AppUser user)
        {
            return _context.OrderDetails
                .Where(od => od.Order.Customer.Id == user.Id && od.Song != null)
                .Select(od => od.Song)
                .Distinct()
                .ToList();
        }

        private List<Album> GetOwnedAlbums(AppUser user)
        {
            return _context.OrderDetails
                .Where(od => od.Order.Customer.Id == user.Id && od.Album != null)
                .Select(od => od.Album)
                .Distinct()
                .ToList();
        }

        private List<Artist> GetOwnedArtists(AppUser user)
        {
            HashSet<Artist> ownSongsArtists = _context.OrderDetails
                .Where(od => od.Order.Customer.Id == user.Id && od.Song != null)
                .Include(od => od.Song)
                .ThenInclude(s => s.Artists)
                .SelectMany(od => od.Song.Artists)
                .Distinct()
                .ToHashSet();

            HashSet<Artist> ownAlbumsArtists = _context.OrderDetails
                .Where(od => od.Order.Customer.Id == user.Id && od.Album != null)
                .Include(od => od.Album)
                .ThenInclude(s => s.Artists)
                .SelectMany(od => od.Album.Artists)
                .Distinct()
                .ToHashSet();

            return ownSongsArtists.Union(ownAlbumsArtists).ToList();
        }

        // GET: Reviews/Create
        [Authorize(Roles = "Customer")]
        public IActionResult Create()
        {
            AppUser user = _userManager.GetUserAsync(User).Result;

            var ownedSongs = GetOwnedSongs(user);

            var ownedAlbums = GetOwnedAlbums(user);

            var ownedArtists = GetOwnedArtists(user);
            
            bool hasProduct = ownedSongs.Any() || ownedAlbums.Any() || ownedArtists.Any();

            if (hasProduct == false)
            {
                return Unauthorized();
            }

            ViewBag.OwnedSongs = new SelectList(ownedSongs, "SongId", "SongTitle");
            ViewBag.OwnedAlbums = new SelectList(ownedAlbums, "AlbumId", "AlbumTitle");
            ViewBag.OwnedArtists = new SelectList(ownedArtists, "ArtistId", "ArtistName");
            ViewBag.HasProduct = hasProduct;
    
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

            bool hasProduct = ownedSongs.Any() || ownedAlbums.Any() || ownedArtists.Any();
                
            if (ModelState.IsValid)
            {
                review.Reviewer = user;
                // review.ReviewerID = user.Id;
                    
                ViewBag.OwnedSongs = new SelectList(ownedSongs, "SongId", "SongTitle");
                ViewBag.OwnedAlbums = new SelectList(ownedAlbums, "AlbumId", "AlbumTitle");
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

                _context.Add(review);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.OwnedSongs = new SelectList(ownedSongs, "SongId", "SongTitle");
            ViewBag.OwnedAlbums = new SelectList(ownedAlbums, "AlbumId", "AlbumTitle");
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

            var review = await _context.Reviews.Include(r => r.Reviewer)
                .FirstOrDefaultAsync(r => r.ReviewID == id);

            if (review.Reviewer.Id != _userManager.GetUserId(User) && !User.IsInRole("Admin") && !User.IsInRole("Employee"))
            {
                return Unauthorized();
            }

            if (review == null)
            {
                return NotFound();
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

            AppUser user = await _userManager.GetUserAsync(User);

            if (review.Reviewer.Id != _userManager.GetUserId(User) && !User.IsInRole("Admin") && !User.IsInRole("Employee"))
            {
                return Unauthorized();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(review);
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
            return View(review);
        }

        // GET: Reviews/Delete/5
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var review = await _context.Reviews
                .FirstOrDefaultAsync(m => m.ReviewID == id);
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
            if (review != null || review.Description != "")
            {
                review.Description = "";
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Reviews/Approve/5
        [Authorize(Roles = "Admin, Employee")]
        public async Task<IActionResult> Approve(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var review = await _context.Reviews.FindAsync(id);

            if (review == null)
            {
                return NotFound();
            }

            review.Status = ReviewStatus.Approve;

            _context.Update(review);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: Reviews/Reject/5
        [Authorize(Roles = "Admin, Employee")]
        public async Task<IActionResult> Reject(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var review = await _context.Reviews.FindAsync(id);

            if (review == null)
            {
                return NotFound();
            }

            review.Status = ReviewStatus.Reject;

            _context.Update(review);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        
        private bool ReviewExists(int id)
        {
            return _context.Reviews.Any(e => e.ReviewID == id);
        }
    }
}
