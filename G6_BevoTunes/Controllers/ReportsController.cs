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
            return View();
        }
    }
}