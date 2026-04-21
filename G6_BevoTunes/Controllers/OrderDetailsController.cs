using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using G6_BevoTunes.DAL;
using G6_BevoTunes.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration.UserSecrets;

namespace G6_BevoTunes.Controllers
{
    public class OrderDetailsController : Controller
    {
        private readonly AppDbContext _context;

        private readonly UserManager<AppUser> _userManager;

        public OrderDetailsController(AppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [Authorize(Roles = "Customer, Admin, Employee")]
        // GET: OrderDetails
        public async Task<IActionResult> Index()
        {
            AppUser user = await _userManager.GetUserAsync(User);

            if (User.IsInRole("Customer"))
            {
                return View(await _context.OrderDetails.Include(od => od.Song).ThenInclude(s => s.Artists).Include(od => od.Song)
                .ThenInclude(s => s.Reviews).Include(od => od.Song).ThenInclude(s => s.Promotions)
                .Include(od => od.Album).ThenInclude(a => a.Artists)
                .Include(od => od.Album).ThenInclude(a => a.Promotions)
                .Include(od => od.Album).ThenInclude(a => a.Reviews).Include(od => od.Order)
                .ThenInclude(o => o.Customer).Where(od => od.Order.Customer.Id == user.Id && od.Order.OrderStatus == OrderStatus.InCart).ToListAsync());
            } 
            else if (User.IsInRole("Admin") || User.IsInRole("Employee")) 
            {
                var allOrder = await _context.OrderDetails.Include(od => od.Song).ThenInclude(s => s.Artists).Include(od => od.Song)
                .ThenInclude(s => s.Reviews).Include(od => od.Song).ThenInclude(s => s.Promotions)
                .Include(od => od.Album).ThenInclude(s => s.Artists)
                .Include(od => od.Album).ThenInclude(a => a.Promotions)
                .Include(od => od.Album).ThenInclude(a => a.Reviews).Include(od => od.Order)
                .ThenInclude(o => o.Customer).ToListAsync();

                return View(allOrder);
            }

            return Unauthorized();

        }

        // GET: OrderDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderDetail = await _context.OrderDetails
                .FirstOrDefaultAsync(m => m.OrderDetailID == id);
            if (orderDetail == null)
            {
                return NotFound();
            }

            return View(orderDetail);
        }

        // GET: OrderDetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OrderDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderDetailID,PurchasedPrice")] OrderDetail orderDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orderDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(orderDetail);
        }

        // // GET: OrderDetails/Edit/5
        // public async Task<IActionResult> Edit(int? id)
        // {
        //     if (id == null)
        //     {
        //         return NotFound();
        //     }

        //     var orderDetail = await _context.OrderDetails.FindAsync(id);
        //     if (orderDetail == null)
        //     {
        //         return NotFound();
        //     }
        //     return View(orderDetail);
        // }

        // // POST: OrderDetails/Edit/5
        // // To protect from overposting attacks, enable the specific properties you want to bind to.
        // // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // public async Task<IActionResult> Edit(int id, [Bind("OrderDetailID,PurchasedPrice")] OrderDetail orderDetail)
        // {
        //     if (id != orderDetail.OrderDetailID)
        //     {
        //         return NotFound();
        //     }

        //     if (ModelState.IsValid)
        //     {
        //         try
        //         {
        //             _context.Update(orderDetail);
        //             await _context.SaveChangesAsync();
        //         }
        //         catch (DbUpdateConcurrencyException)
        //         {
        //             if (!OrderDetailExists(orderDetail.OrderDetailID))
        //             {
        //                 return NotFound();
        //             }
        //             else
        //             {
        //                 throw;
        //             }
        //         }
        //         return RedirectToAction(nameof(Index));
        //     }
        //     return View(orderDetail);
        // }

        // GET: OrderDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderDetail = await _context.OrderDetails
                .FirstOrDefaultAsync(m => m.OrderDetailID == id);
            if (orderDetail == null)
            {
                return NotFound();
            }

            return View(orderDetail);
        }

        // POST: OrderDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var orderDetail = await _context.OrderDetails.FindAsync(id);
            if (orderDetail != null)
            {
                _context.OrderDetails.Remove(orderDetail);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderDetailExists(int id)
        {
            return _context.OrderDetails.Any(e => e.OrderDetailID == id);
        }
    }
}
