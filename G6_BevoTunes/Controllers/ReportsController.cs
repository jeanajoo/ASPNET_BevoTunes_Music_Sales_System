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
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Storage;

namespace G6_BevoTunes.Controllers
{
    public class ReportsController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public ReportsController(AppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> AllSongsSoldReport()
        {
            List<OrderDetail> orderDetails = _context.OrderDetails.Include(od => od.Song).ToList();
            Dictionary<Song, Tuple<Int32, Decimal>> songSales = new Dictionary<Song, Tuple<Int32, Decimal>>();
            Decimal totalSales = 0m;
            foreach (OrderDetail od in orderDetails)
            {
                if (od.Song == null)
                {
                    continue;
                }

                if (songSales.ContainsKey(od.Song))
                {
                    songSales[od.Song] = new Tuple<Int32, Decimal>(songSales[od.Song].Item1 + 1, songSales[od.Song].Item2 + od.PurchasedPrice);
                }
                else
                {
                    songSales[od.Song] = new Tuple<Int32, Decimal>(1, od.PurchasedPrice);
                }
                totalSales += od.PurchasedPrice;
            }
            ViewBag.SongSalesCount = songSales.Count;
            ViewBag.SongSales = songSales;
            ViewBag.TotalSales = totalSales;

            return View();
        }

        public async Task<IActionResult> AllAlbumsReport()
        {
            List<OrderDetail> orderDetails = _context.OrderDetails.Include(od => od.Album).ToList();
            Dictionary<Album, Tuple<Int32, Decimal>> albumSales = new Dictionary<Album, Tuple<Int32, Decimal>>();
            Decimal totalSales = 0m;
            foreach (OrderDetail od in orderDetails)
            {
                if (od.Album == null)
                {
                    continue;
                }

                if (albumSales.ContainsKey(od.Album))
                {
                    albumSales[od.Album] = new Tuple<Int32, Decimal>(albumSales[od.Album].Item1 + 1, albumSales[od.Album].Item2 + od.PurchasedPrice);
                }
                else
                {
                    albumSales[od.Album] = new Tuple<Int32, Decimal>(1, od.PurchasedPrice);
                }
                totalSales += od.PurchasedPrice;
            }
            ViewBag.AlbumSalesCount = albumSales.Count;
            ViewBag.AlbumSales = albumSales;
            ViewBag.TotalSales = totalSales;

            return View();
        }

        public async Task<IActionResult> TopSellingBandsReport()
        {
            List<Genre> genres = _context.Genres
                .Include(g => g.Songs).ThenInclude(s => s.OrderDetails)
                .Include(g => g.Songs).ThenInclude(s => s.Artists)
                .Include(g => g.Albums).ThenInclude(a => a.OrderDetails)
                .Include(g => g.Albums).ThenInclude(a => a.Artists)
                .ToList();

            Dictionary<Genre, Tuple<Artist, Int32, Decimal, Int32, Decimal>> reportData
                = new Dictionary<Genre, Tuple<Artist, Int32, Decimal, Int32, Decimal>>();

            foreach (Genre genre in genres)
            {
                Dictionary<int, Tuple<Artist, Int32, Decimal, Int32, Decimal>> artistData
                    = new Dictionary<int, Tuple<Artist, Int32, Decimal, Int32, Decimal>>();

                foreach (Song song in genre.Songs)
                {
                    foreach (OrderDetail od in song.OrderDetails)
                    {
                        foreach (Artist artist in song.Artists)
                        {
                            if (artistData.ContainsKey(artist.ArtistId))
                            {
                                var prev = artistData[artist.ArtistId];
                                artistData[artist.ArtistId] = Tuple.Create(
                                    prev.Item1, prev.Item2 + 1, prev.Item3 + od.PurchasedPrice,
                                    prev.Item4, prev.Item5);
                            }
                            else
                            {
                                artistData[artist.ArtistId] = Tuple.Create(artist, 1, od.PurchasedPrice, 0, 0m);
                            }
                        }
                    }
                }

                foreach (Album album in genre.Albums)
                {
                    foreach (OrderDetail od in album.OrderDetails)
                    {
                        foreach (Artist artist in album.Artists)
                        {
                            if (artistData.ContainsKey(artist.ArtistId))
                            {
                                var prev = artistData[artist.ArtistId];
                                artistData[artist.ArtistId] = Tuple.Create(
                                    prev.Item1, prev.Item2, prev.Item3,
                                    prev.Item4 + 1, prev.Item5 + od.PurchasedPrice);
                            }
                            else
                            {
                                artistData[artist.ArtistId] = Tuple.Create(artist, 0, 0m, 1, od.PurchasedPrice);
                            }
                        }
                    }
                }

                if (artistData.Count == 0) continue;

                var topEntry = artistData
                    .OrderByDescending(a => a.Value.Item3 + a.Value.Item5)
                    .ThenBy(a => a.Value.Item1.ArtistName)
                    .First();

                reportData[genre] = Tuple.Create(
                    topEntry.Value.Item1,
                    topEntry.Value.Item2,
                    topEntry.Value.Item3,
                    topEntry.Value.Item4,
                    topEntry.Value.Item3 + topEntry.Value.Item5);
            }

            ViewBag.ReportData = reportData;
            return View();
        }
    }
}