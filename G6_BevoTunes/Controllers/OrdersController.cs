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
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace G6_BevoTunes.Controllers
{
    public class OrdersController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public OrdersController(AppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            var orders = _context.Orders.AsQueryable();
            if (User.Identity.IsAuthenticated && User.IsInRole("Customer"))
            {
                orders = orders.Where(o => o.Customer.UserName == User.Identity.Name);
            }
            return View(await orders.ToListAsync());
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .Include(o => o.OrderDetails)
                    .ThenInclude(od => od.Song)
                .Include(o => o.OrderDetails)
                    .ThenInclude(od => od.Album)
                .Include(o => o.Customer)
                .Include(o => o.Recipient)
                .Include(o => o.Card)
                .FirstOrDefaultAsync(m => m.OrderID == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderID,OrderDate,OrderStatus")] Order order)
        {
            if (ModelState.IsValid)
            {
                _context.Add(order);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(order);
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderID,OrderDate,OrderStatus")] Order order)
        {
            if (id != order.OrderID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(order);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(order.OrderID))
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
            return View(order);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .FirstOrDefaultAsync(m => m.OrderID == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order != null)
            {
                _context.Orders.Remove(order);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> AddSongToCart(int? id, string customerId = null)
        {
            if (id == null)
            {
                return NotFound();
            }

            var song = await _context.Songs.FindAsync(id);
            if (song == null)
            {
                return NotFound();
            }

            // Determine which user we're adding to cart for
            AppUser targetUser;

            if (!string.IsNullOrEmpty(customerId))
            {
                // Employee adding for a customer
                targetUser = await _userManager.FindByIdAsync(customerId);
                if (targetUser == null)
                {
                    TempData["ErrorMessage"] = "Customer not found.";
                    return RedirectToAction("Index", "Search");
                }
            }
            else
            {
                // Regular customer or employee adding for currently selected customer
                var currentUser = await _userManager.FindByNameAsync(User.Identity.Name);
                if ((User.IsInRole("Admin") || User.IsInRole("Employee")) && TempData["SelectedCustomerId"] != null)
                {
                    string selectedCustomerId = TempData["SelectedCustomerId"].ToString();
                    TempData.Keep("SelectedCustomerId"); // Preserve for next request
                    targetUser = await _userManager.FindByIdAsync(selectedCustomerId);
                    if (targetUser == null)
                    {
                        TempData["ErrorMessage"] = "Customer not found.";
                        return RedirectToAction("SelectCustomer");
                    }
                }
                else
                {
                    targetUser = currentUser;
                }
            }

            if (_context.Orders
                            .Include(o => o.OrderDetails)
                            .Include(o => o.Recipient)
                            .Where(o => o.Recipient.Email == targetUser.Email)
                            .Any(o => o.OrderDetails
                                            .Any(od => od.Song != null && 
                                                                        od.Song.SongId == song.SongId)))
            {
                TempData["ErrorMessage"] = "This customer has already added this song to their cart/bought this song.";
                return RedirectToAction("Index", "Search");
            }

            var order = await _context.Orders
                                    .Include(o => o.OrderDetails)
                                    .FirstOrDefaultAsync(o => o.Recipient.Email == targetUser.Email 
                                    && o.OrderStatus == OrderStatus.InCart);

            if (order == null)
            {
                order = new Order
                {
                    Customer = targetUser,
                    Recipient = targetUser,
                    OrderStatus = OrderStatus.InCart,
                    OrderDate = DateTime.Now,
                    Card = targetUser.CreditCards.FirstOrDefault()
                };

                var od = new OrderDetail
                {
                    Order = order,
                    Song = song,
                    PurchasedPrice = song.SongPrice
                };

                order.OrderDetails.Add(od);

                if (order.Card == null)
                {
                    TempData["ErrorMessage"] = $"'{targetUser.Email}' has no credit card on file. Please add a credit card before adding items to the cart. TempData User Stored: {TempData["SelectedCustomerEmail"]}";
                    return RedirectToAction("Index", "Search");
                }

                _context.Orders.Add(order);
                await _context.SaveChangesAsync();
            }

            var orderDetail = new OrderDetail
            {
                Order = order,
                Song = song,
                PurchasedPrice = song.SongPrice
            };

            order.OrderDetails.Add(orderDetail);

            _context.OrderDetails.Add(orderDetail);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Song added to cart successfully.";
            return RedirectToAction("Index", "Search");
        }


        public async Task<IActionResult> AddAlbumToCart(int? id, string customerId = null)
        {
            if (id == null)
            {
                return NotFound();
            }

            var album = await _context.Albums.FindAsync(id);
            if (album == null)
            {
                return NotFound();
            }

            // Determine which user we're adding to cart for
            AppUser targetUser;
            if (!string.IsNullOrEmpty(customerId))
            {
                // Employee adding for a customer
                targetUser = await _userManager.FindByIdAsync(customerId);
                if (targetUser == null)
                {
                    TempData["ErrorMessage"] = "Customer not found.";
                    return RedirectToAction("Index", "Search");
                }
            }
            else
            {
                // Regular customer or employee adding for currently selected customer
                var currentUser = await _userManager.FindByNameAsync(User.Identity.Name);
                if ((User.IsInRole("Admin") || User.IsInRole("Employee")) && TempData["SelectedCustomerId"] != null)
                {
                    string selectedCustomerId = TempData["SelectedCustomerId"].ToString();
                    TempData.Keep("SelectedCustomerId"); // Preserve for next request
                    targetUser = await _userManager.FindByIdAsync(selectedCustomerId);
                    if (targetUser == null)
                    {
                        TempData["ErrorMessage"] = "Customer not found.";
                        return RedirectToAction("SelectCustomer");
                    }
                }
                else
                {
                    targetUser = currentUser;
                }
            }

            if (_context.Orders
                            .Include(o => o.OrderDetails)
                            .Include(o => o.Recipient)
                            .Where(o => o.Recipient.Email == targetUser.Email)
                            .Any(o => o.OrderDetails
                                            .Any(od => od.Album != null && 
                                                                        od.Album.AlbumId == album.AlbumId)))
            {
                TempData["ErrorMessage"] = "This customer has already added this album to their cart/bought this album.";
                return RedirectToAction("Index", "Search");
            }

            var order = await _context.Orders
                                    .Include(o => o.OrderDetails)
                                    .FirstOrDefaultAsync(o => o.Recipient.Email == targetUser.Email 
                                    && o.OrderStatus == OrderStatus.InCart);

            if (order == null)
            {
                order = new Order
                {
                    Customer = targetUser,
                    Recipient = targetUser,
                    OrderStatus = OrderStatus.InCart,
                    OrderDate = DateTime.Now,
                    Card = targetUser.CreditCards.FirstOrDefault()
                };

                var od = new OrderDetail
                {
                    Order = order,
                    Album = album,
                    PurchasedPrice = album.AlbumPrice
                };

                order.OrderDetails.Add(od);

                if (order.Card == null)
                {
                    TempData["ErrorMessage"] = $"'{targetUser.Email}' has no credit card on file. Please add a credit card before adding items to the cart.";
                    return RedirectToAction("Index", "Search");
                }

                _context.Orders.Add(order);
                await _context.SaveChangesAsync();
            }

            var orderDetail = new OrderDetail
            {
                Order = order,
                Album = album,
                PurchasedPrice = album.AlbumPrice
            };

            order.OrderDetails.Add(orderDetail);

            _context.OrderDetails.Add(orderDetail);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Album added to cart successfully.";
            return RedirectToAction("Index", "Search");
        }


        

        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.OrderID == id);
        }
        public async Task<IActionResult> Checkout()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            if (user.Status == UserStatus.Blocked)
            {
                return View("Error", new string[] { "Your account is disabled. You cannot checkout." });
            }
            var order = await _context.Orders
                                    .Include(o => o.OrderDetails)
                                    .FirstOrDefaultAsync(o => o.Recipient.UserName == User.Identity.Name 
                                    && o.OrderStatus == OrderStatus.InCart);

            if (order == null)
            {
                return RedirectToAction("Index", "Home"); 
            }

            return View(order); 
        }

        [Authorize(Roles = "Admin, Employee")]
        public async Task<IActionResult> SelectCustomer()
        {
            var customers = await _userManager.GetUsersInRoleAsync("Customer");
            return View(customers);
        }

        [Authorize(Roles = "Admin, Employee")]
        public IActionResult SetCustomerContext(string customerId)
        {
            if (string.IsNullOrEmpty(customerId))
            {
                TempData["ErrorMessage"] = "Please select a customer.";
                return RedirectToAction("SelectCustomer");
            }

            TempData["SelectedCustomerEmail"] = _userManager.FindByIdAsync(customerId).Result.Email;

            TempData["SelectedCustomerId"] = customerId;
            return RedirectToAction("Index", "Search");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult ClearCustomerContext()
        {
            TempData.Remove("SelectedCustomerId");
            return RedirectToAction("Index", "Search");
        }
    }
}
