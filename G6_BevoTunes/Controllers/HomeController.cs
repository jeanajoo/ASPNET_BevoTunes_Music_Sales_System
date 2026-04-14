using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using G6_BevoTunes.Models;
using G6_BevoTunes.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

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
            .Include(p => p.Artists).ThenInclude(a => a.Albums)
            .Include(p => p.Albums)
            .Include(p => p.Songs).ThenInclude(s => s.Albums)
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
    [Authorize]
    public async Task<IActionResult> MusicRights(string searchString, string sortOrder)
    {
        String userId = User.Identity.Name;
        var mySongs = _context.OrderDetails
            .Include(od => od.Order)
            .Include(od => od.Song).ThenInclude(s => s.Artists)
            .Include(od => od.Song).ThenInclude(s => s.Genres)
            .Include(od => od.Song).ThenInclude(s => s.Albums)
            .Where(od => od.Order.Recipient.UserName == userId && od.Order.OrderStatus == OrderStatus.Ordered).Select(od => od.Song)
            .Distinct(); 

        if (!String.IsNullOrEmpty(searchString))
        {
            mySongs = mySongs.Where(s => s.SongTitle.Contains(searchString) || 
                                        s.Artists.Any(a => a.ArtistName.Contains(searchString)));
        }

        switch (sortOrder)
        {
            case "title_desc": mySongs = mySongs.OrderByDescending(s => s.SongTitle); break;
            case "Artist": mySongs = mySongs.OrderBy(s => s.Artists.FirstOrDefault().ArtistName); break;
            default: mySongs = mySongs.OrderBy(s => s.SongTitle); break;
        }
        return View(await mySongs.ToListAsync());
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
