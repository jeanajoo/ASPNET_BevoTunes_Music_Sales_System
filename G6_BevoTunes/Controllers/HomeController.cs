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
        List<Order> myOrders = await _context.Orders
            .Where(o => o.Recipient.UserName == userId && o.OrderStatus == OrderStatus.Ordered)
            .Include(o => o.OrderDetails)
            .ThenInclude(od => od.Song)
            .ThenInclude(s => s.Artists)
            .Include(o => o.OrderDetails)
            .ThenInclude(od => od.Song)
            .ThenInclude(s => s.Genres)
            .Include(o => o.OrderDetails)
            .ThenInclude(od => od.Album)
            .ThenInclude(a => a.Songs)
            .Include(o => o.OrderDetails)
            .ThenInclude(od => od.Album)
            .ThenInclude(a => a.Songs)
            .ThenInclude(s => s.Artists)
            .Include(o => o.OrderDetails)
            .ThenInclude(od => od.Album)
            .ThenInclude(a => a.Songs)
            .ThenInclude(s => s.Genres)
            .ToListAsync();
        
        List<Song> mySongs = new List<Song>();
        foreach(Order o in myOrders)
        {
            foreach(OrderDetail od in o.OrderDetails)
            {
                if(od.Song != null)
                {
                    mySongs.Add(od.Song);
                }
                 if(od.Album != null)
                {

                    foreach(Song s in od.Album.Songs)
                    {
                        mySongs.Add(s);
                    }
                }
            }
        }

        if (!String.IsNullOrEmpty(searchString))
        {
            searchString = searchString.ToLower();
            mySongs = mySongs.Where(s => s.SongTitle.ToLower().Contains(searchString) || 
                                        s.Artists.Any(a => a.ArtistName.ToLower().Contains(searchString))||
                                        s.Genres.Any(g => g.GenreName.ToLower().Contains(searchString)) ||
                                        s.Albums.Any(al => al.AlbumName.ToLower().Contains(searchString))).ToList();
        }

        switch (sortOrder)
        {
            case "title": mySongs = mySongs.OrderBy(s => s.SongTitle).ToList(); break;
            case "artist": mySongs = mySongs.OrderBy(s => s.Artists.FirstOrDefault().ArtistName).ToList(); break;
            case "genre": mySongs = mySongs.OrderBy(s => s.Genres.FirstOrDefault().GenreName).ToList(); break;
            default: mySongs = mySongs.OrderBy(s => s.SongTitle).ToList(); break;
        }

        return View(mySongs);
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
