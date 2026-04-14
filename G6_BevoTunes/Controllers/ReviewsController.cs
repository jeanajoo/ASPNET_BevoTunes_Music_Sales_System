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

        // GET: Reviews/Create
        [Authorize]
        public IActionResult Create()
        {
            AppUser user = _userManager.GetUserAsync(User).Result;

            var ownedSongs = _context.OrderDetails
                .Where(od => od.Order.Customer.Id == user.Id && od.Song != null)
                .Select(od => od.Song)
                .Distinct()
                .ToList();

            var ownedAlbums = _context.OrderDetails
                .Where(od => od.Order.Customer.Id == user.Id && od.Album != null)
                .Select(od => od.Album)
                .Distinct()
                .ToList();

            var ownedArtists = _context.OrderDetails
                .Where(od => od.Order.Customer.Id == user.Id && od.Artist != null)
                .Select(od => od.Artist)
                .Distinct()     
                .ToList();

            ViewBag.OwnedSongs = new SelectList(ownedSongs, "SongId", "SongTitle");
            ViewBag.OwnedAlbums = new SelectList(ownedAlbums, "AlbumId", "AlbumTitle");
            ViewBag.OwnedArtists = new SelectList(ownedArtists, "ArtistId", "ArtistName");

            return View();
        }

        // POST: Reviews/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("ReviewID,Description,Rating,Status")] Review review, int? SelectedSong, 
        int? SelectedAlbum, int? SelectedArtist)
        {
            AppUser user = await _userManager.GetUserAsync(User);

            var ownedSongs = _context.OrderDetails
                .Where(od => od.Order.Customer.Id == user.Id && od.Song != null)
                .Select(od => od.Song)
                .Distinct()
                .ToList();

            var ownedAlbums = _context.OrderDetails
                .Where(od => od.Order.Customer.Id == user.Id && od.Album != null)
                .Select(od => od.Album)
                .Distinct()
                .ToList();

            var ownedArtists = _context.OrderDetails
                .Where(od => od.Order.Customer.Id == user.Id && od.Artist != null)
                .Select(od => od.Artist)
                .Distinct()     
                .ToList();
                
            if (ModelState.IsValid)
            {
                review.Reviewer = user;
                review.ReviewerID = user.Id;
                    
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
                                
                bool ownProduct = _context.Orders
                    .Any(o => o.Customer.Id == user.Id &&
                            o.OrderDetails.Any(od =>
                                (od.Song != null && review.Song != null && od.Song.SongId == review.Song.SongId) ||
                                (od.Album != null && review.Album != null && od.Album.AlbumId == review.Album.AlbumId) ||
                                (od.Artist != null && review.Artist != null && od.Artist.ArtistId == review.Artist.ArtistId)
                            ));

                if (!ownProduct)
                {
                    return Unauthorized();
                }
                
                review.Status = ReviewStatus.Pending;

                _context.Add(review);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.OwnedSongs = new SelectList(ownedSongs, "SongId", "SongTitle");
            ViewBag.OwnedAlbums = new SelectList(ownedAlbums, "AlbumId", "AlbumTitle");
            ViewBag.OwnedArtists = new SelectList(ownedArtists, "ArtistId", "ArtistName");

            return View(review);
        }

        // GET: Reviews/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            
            if (id == null)
            {
                return NotFound();
            }

            var review = await _context.Reviews.FindAsync(id);

            if (review.ReviewerID != _userManager.GetUserId(User) && !User.IsInRole("Admin") && !User.IsInRole("Employee"))
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

            if (review.ReviewerID != _userManager.GetUserId(User) && !User.IsInRole("Admin") && !User.IsInRole("Employee"))
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
        [Authorize]
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
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var review = await _context.Reviews.FindAsync(id);
            if (review != null)
            {
                review.Description = null;
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
