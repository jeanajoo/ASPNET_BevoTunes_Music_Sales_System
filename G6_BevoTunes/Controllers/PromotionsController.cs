using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using G6_BevoTunes.DAL;
using G6_BevoTunes.Models;

namespace G6_BevoTunes.Controllers
{
    public class PromotionsController : Controller
    {
        private readonly AppDbContext _context;

        public PromotionsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Promotions
        public async Task<IActionResult> Index()
        {
            return View(await _context.Promotions.Include(p => p.Artists).Include(p => p.Albums).Include(p => p.Songs).ToListAsync());
        }

        // GET: Promotions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var promotion = await _context.Promotions.Include(p => p.Albums).Include(p => p.Artists).Include(p => p.Songs)
                .FirstOrDefaultAsync(m => m.PromotionId == id);
            if (promotion == null)
            {
                return NotFound();
            }

            return View(promotion);
        }

        private SelectList GetAllSongs() => new SelectList(_context.Songs.OrderBy(s => s.SongTitle), "SongId", "SongTitle");
        private SelectList GetAllAlbums() => new SelectList(_context.Albums.OrderBy(a => a.AlbumName), "AlbumId", "AlbumName");
        private SelectList GetAllArtists() => new SelectList(_context.Artists.OrderBy(a => a.ArtistName), "ArtistId", "ArtistName");

        // GET: Promotions/Create
        public IActionResult Create()
        {
            ViewBag.AllSongs = GetAllSongs();
            ViewBag.AllAlbums = GetAllAlbums();
            ViewBag.AllArtists = GetAllArtists();
            return View();
        }

        // POST: Promotions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PromotionId,PromotionType,DiscountPrice,PromotionActive")] Promotion promotion, string ProductCategory, int? SelectedProductId)
        {
            if (ProductCategory == null || SelectedProductId == null)
            {
                ModelState.AddModelError("", "You must select a product category and a product item.");
            }

            if (promotion.PromotionType == PromotionType.DISCOUNT && ProductCategory == "Artist")
            {
                ModelState.AddModelError("", "Discount promotions can only be applied to Songs or Albums.");
            }

            if (promotion.PromotionType == PromotionType.DISCOUNT && promotion.DiscountPrice <= 0)
            {
                ModelState.AddModelError("DiscountPrice", "Discount price must be greater than zero.");
            }

            if (promotion.PromotionType != PromotionType.DISCOUNT)
            {
                promotion.DiscountPrice = 0;
                ModelState.Remove("DiscountPrice");
            }

            if (ProductCategory == "Song")
            {
                var song = await _context.Songs.FindAsync(SelectedProductId);
                if (song != null)
                {
                    Promotion existing = _context.Promotions.Include(p => p.Songs).Where(p => p.Songs.Contains(song) && p.PromotionType == promotion.PromotionType).FirstOrDefault();
                    if (existing != null)
                    {
                        ModelState.AddModelError("", "Existing Promotion with Song Exists");
                    }
                    promotion.Songs = new List<Song> { song };
                }
            }
            else if (ProductCategory == "Album")
            {
                var album = await _context.Albums.FindAsync(SelectedProductId);
                if (album != null)
                {
                    Promotion existing = _context.Promotions.Include(p => p.Albums).Where(p => p.Albums.Contains(album) && p.PromotionType == promotion.PromotionType).FirstOrDefault();
                    if (existing != null)
                    {
                        ModelState.AddModelError("", "Existing Promotion with Album Exists");
                    }
                    promotion.Albums = new List<Album> { album };
                }
            }
            else if (ProductCategory == "Artist")
            {
                var artist = await _context.Artists.FindAsync(SelectedProductId);
                if (artist != null)
                {
                    Promotion existing = _context.Promotions.Include(p => p.Artists).Where(p => p.Artists.Contains(artist) && p.PromotionType == promotion.PromotionType).FirstOrDefault();
                    if (existing != null)
                    {
                        ModelState.AddModelError("", "Existing Promotion with Artist Exists");
                    }
                    promotion.Artists = new List<Artist> { artist };
                }
            }

            if (!ModelState.IsValid)
            {
                ViewBag.AllSongs = GetAllSongs();
                ViewBag.AllAlbums = GetAllAlbums();
                ViewBag.AllArtists = GetAllArtists();
                ViewBag.SelectedProductCategory = ProductCategory;
                ViewBag.SelectedProductId = SelectedProductId;
                return View(promotion);
            }

            _context.Add(promotion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Promotions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var promotion = await _context.Promotions
                .Include(p => p.Songs)
                .Include(p => p.Albums)
                .Include(p => p.Artists)
                .FirstOrDefaultAsync(p => p.PromotionId == id);
            if (promotion == null)
            {
                return NotFound();
            }

            ViewBag.AllSongs = GetAllSongs();
            ViewBag.AllAlbums = GetAllAlbums();
            ViewBag.AllArtists = GetAllArtists();

            if (promotion.Songs.Count > 0)
            {
                ViewBag.SelectedProductCategory = "Song";
                ViewBag.SelectedProductId = promotion.Songs[0].SongId;
            }
            else if (promotion.Albums.Count > 0)
            {
                ViewBag.SelectedProductCategory = "Album";
                ViewBag.SelectedProductId = promotion.Albums[0].AlbumId;
            }
            else if (promotion.Artists.Count > 0)
            {
                ViewBag.SelectedProductCategory = "Artist";
                ViewBag.SelectedProductId = promotion.Artists[0].ArtistId;
            }

            return View(promotion);
        }

        // POST: Promotions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PromotionId,PromotionType,DiscountPrice,PromotionActive")] Promotion promotion, string ProductCategory, int? SelectedProductId)
        {
            if (id != promotion.PromotionId)
            {
                return NotFound();
            }

            if (ProductCategory == null || SelectedProductId == null)
            {
                ModelState.AddModelError("", "You must select a product category and a product item.");
            }

            if (promotion.PromotionType == PromotionType.DISCOUNT && ProductCategory == "Artist")
            {
                ModelState.AddModelError("", "Discount promotions can only be applied to Songs or Albums.");
            }

            if (promotion.PromotionType == PromotionType.DISCOUNT && promotion.DiscountPrice <= 0)
            {
                ModelState.AddModelError("DiscountPrice", "Discount price must be greater than zero.");
            }

            if (promotion.PromotionType != PromotionType.DISCOUNT)
            {
                promotion.DiscountPrice = 0;
                ModelState.Remove("DiscountPrice");
            }

            if (ProductCategory == "Song")
            {
                var song = await _context.Songs.FindAsync(SelectedProductId);
                if (song != null)
                {
                    Promotion existing = _context.Promotions.Include(p => p.Songs).Where(p => p.Songs.Contains(song) && p.PromotionType == promotion.PromotionType && p.PromotionId != promotion.PromotionId).FirstOrDefault();
                    if (existing != null)
                    {
                        ModelState.AddModelError("", "Existing Promotion with Song Exists");
                    }
                    promotion.Songs = new List<Song> { song };
                }
            }
            else if (ProductCategory == "Album")
            {
                var album = await _context.Albums.FindAsync(SelectedProductId);
                if (album != null)
                {
                    Promotion existing = _context.Promotions.Include(p => p.Albums).Where(p => p.Albums.Contains(album) && p.PromotionType == promotion.PromotionType && p.PromotionId != promotion.PromotionId).FirstOrDefault();
                    if (existing != null)
                    {
                        ModelState.AddModelError("", "Existing Promotion with Album Exists");
                    }
                    promotion.Albums = new List<Album> { album };
                }
            }
            else if (ProductCategory == "Artist")
            {
                var artist = await _context.Artists.FindAsync(SelectedProductId);
                if (artist != null)
                {
                    Promotion existing = _context.Promotions.Include(p => p.Artists).Where(p => p.Artists.Contains(artist) && p.PromotionType == promotion.PromotionType && p.PromotionId != promotion.PromotionId).FirstOrDefault();
                    if (existing != null)
                    {
                        ModelState.AddModelError("", "Existing Promotion with Artist Exists");
                    }
                    promotion.Artists = new List<Artist> { artist };
                }
            }

            if (!ModelState.IsValid)
            {
                ViewBag.AllSongs = GetAllSongs();
                ViewBag.AllAlbums = GetAllAlbums();
                ViewBag.AllArtists = GetAllArtists();
                ViewBag.SelectedProductCategory = ProductCategory;
                ViewBag.SelectedProductId = SelectedProductId;
                return View(promotion);
            }

            try
            {
                var existingPromotion = await _context.Promotions
                    .Include(p => p.Songs)
                    .Include(p => p.Albums)
                    .Include(p => p.Artists)
                    .FirstOrDefaultAsync(p => p.PromotionId == id);

                if (existingPromotion == null)
                {
                    return NotFound();
                }

                existingPromotion.PromotionType = promotion.PromotionType;
                existingPromotion.DiscountPrice = promotion.DiscountPrice;
                existingPromotion.PromotionActive = promotion.PromotionActive;
                existingPromotion.Songs = promotion.Songs;
                existingPromotion.Albums = promotion.Albums;
                existingPromotion.Artists = promotion.Artists;

                _context.Update(existingPromotion);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PromotionExists(promotion.PromotionId))
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

        // GET: Promotions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var promotion = await _context.Promotions
                .FirstOrDefaultAsync(m => m.PromotionId == id);
            if (promotion == null)
            {
                return NotFound();
            }

            return View(promotion);
        }

        // POST: Promotions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var promotion = await _context.Promotions.FindAsync(id);
            if (promotion != null)
            {
                _context.Promotions.Remove(promotion);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PromotionExists(int id)
        {
            return _context.Promotions.Any(e => e.PromotionId == id);
        }
    }
}
