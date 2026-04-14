using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using G6_BevoTunes.Models;
using G6_BevoTunes.DAL;
using Microsoft.EntityFrameworkCore;

namespace G6_BevoTunes.Controllers;

public class HomeController : Controller
{
    private readonly AppDbContext _context;
    public HomeController(AppDbContext context)
    {
        _context = context;
    }
    public async Task<IActionResult> Index()
    {
        HomeViewModel hvm = new HomeViewModel();

        List<Promotion> featuredPromo = await _context.Promotions
            .Include(p => p.Artists)
            .Include(p => p.Albums)
            .Include(p => p.Songs)
            .Where(p => p.PromotionType == PromotionType.FEATURED && p.PromotionActive == true)
            .ToListAsync();

        foreach (Promotion promo in featuredPromo)
        {
            hvm.FeaturedArtists.AddRange(promo.Artists.OrderBy(a => a.ArtistName).ToList());
            hvm.FeaturedAlbums.AddRange(promo.Albums.OrderBy(a => a.AlbumId).ToList());
            hvm.FeaturedSongs.AddRange(promo.Songs.OrderBy(s => s.SongId).ToList());
        }
        return View(hvm);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Seed()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
