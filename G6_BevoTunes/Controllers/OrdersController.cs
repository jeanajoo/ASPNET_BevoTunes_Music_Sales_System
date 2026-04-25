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
using System.Security.Cryptography;

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

        private void GetPurchasePrice(OrderDetail orderDetail)
        {
            if (orderDetail.Song != null && orderDetail.Song?.Promotions!= null && orderDetail.Song.Promotions.Any(p => p.PromotionType == PromotionType.DISCOUNT && p.PromotionActive == true))
            {
                orderDetail.PurchasedPrice = orderDetail.Song.Promotions
                .First(p => p.PromotionType == PromotionType.DISCOUNT).DiscountPrice;
            }
            else if (orderDetail.Album != null && orderDetail.Album?.Promotions!= null && orderDetail.Album.Promotions.Any(p => p.PromotionType == PromotionType.DISCOUNT && p.PromotionActive == true))
            {
                orderDetail.PurchasedPrice = orderDetail.Album.Promotions
                .First(p => p.PromotionType == PromotionType.DISCOUNT).DiscountPrice;
            }
            else if (orderDetail.Song != null)
            {
                orderDetail.PurchasedPrice = orderDetail.Song.SongPrice;
            }
            else if (orderDetail.Album != null)
            {
                orderDetail.PurchasedPrice = orderDetail.Album.AlbumPrice;
            }
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
            if(id != null)
            {
                Order order = _context.Orders.Where(o => o.OrderID == id)
                .Include(o => o.OrderDetails).ThenInclude(od => od.Song).ThenInclude(s => s.Artists)
                .Include(o => o.OrderDetails).ThenInclude(od => od.Song).ThenInclude(s => s.Reviews)
                .Include(o => o.OrderDetails).ThenInclude(od => od.Song).ThenInclude(s => s.Promotions)
                .Include(o => o.OrderDetails).ThenInclude(od => od.Album).ThenInclude(a => a.Artists)
                .Include(o => o.OrderDetails).ThenInclude(od => od.Album).ThenInclude(a => a.Promotions)
                .Include(o => o.OrderDetails).ThenInclude(od => od.Album).ThenInclude(a => a.Reviews)
                .Include(o => o.OrderDetails).ThenInclude(od => od.Order).ThenInclude(o => o.Customer)
                .FirstOrDefault();

                if (order == null)
                {
                    return NotFound();
                }
                
                return View(order);

            }

            AppUser user = await _userManager.GetUserAsync(User);

            if (User.IsInRole("Customer"))
            {
                Order? currentCart = _context.Orders.FirstOrDefault(o => o.Customer.Id == user.Id && o.OrderStatus == OrderStatus.InCart);
                
                if (currentCart == null)
                {
                    currentCart = new Order()
                    {
                        Customer = user,
                        Recipient = user,
                        OrderStatus = OrderStatus.InCart,
                    };
                    _context.Orders.Add(currentCart);
                    _context.SaveChanges();
                }

                var orderDetails = await _context.OrderDetails
                .Include(od => od.Song).ThenInclude(s => s.Promotions)
                .Include(od => od.Album).ThenInclude(a => a.Promotions)
                .Include(od => od.Order).ThenInclude(o => o.Customer)
                .Where(od => od.Order.OrderID == currentCart.OrderID)
                .ToListAsync();

                foreach (var orderDetail in orderDetails)
                {
                    GetPurchasePrice(orderDetail);
                }

                await _context.SaveChangesAsync();

                return View(await _context.OrderDetails.Include(od => od.Song).ThenInclude(s => s.Artists)
                .Include(od => od.Song).ThenInclude(s => s.Reviews)
                .Include(od => od.Song).ThenInclude(s => s.Promotions)
                .Include(od => od.Album).ThenInclude(a => a.Artists)
                .Include(od => od.Album).ThenInclude(a => a.Promotions)
                .Include(od => od.Album).ThenInclude(a => a.Reviews)
                .Include(od => od.Order).ThenInclude(o => o.Customer)
                .Where(od => od.Order.Customer.Id == user.Id && od.Order.OrderStatus == OrderStatus.InCart).ToListAsync());
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

        [HttpGet]
        public async Task<IActionResult> OrderDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderDetail = await _context.OrderDetails.Include(od => od.Song).ThenInclude(s => s.Artists).Include(od => od.Song)
                .ThenInclude(s => s.Reviews).Include(od => od.Song).ThenInclude(s => s.Promotions)
                .Include(od => od.Album).ThenInclude(s => s.Artists)
                .Include(od => od.Album).ThenInclude(a => a.Promotions)
                .Include(od => od.Album).ThenInclude(a => a.Reviews).Include(od => od.Order)
                .FirstOrDefaultAsync(m => m.OrderDetailID == id);

            if (orderDetail == null)
            {
                return NotFound();
            }

            return View(orderDetail);
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

        [HttpGet]
        [Authorize(Roles = "Customer, Admin, Employee")]
        public async Task<IActionResult> Checkout(int id)
        {
            AppUser user = await _userManager.GetUserAsync(User);

            var ordered_items = await _context.OrderDetails.Include(od => od.Order)
            .Include(od => od.Song).ThenInclude(s => s.Promotions)
            .Include(od => od.Album).ThenInclude(a => a.Promotions)
            .Where(od => od.Order.Customer.Id == user.Id && od.Order.OrderStatus == OrderStatus.InCart).ToListAsync();

            var cust_card = await _context.OrderDetails.Include(od => od.Order)
            .ThenInclude(o => o.Customer).ThenInclude(c => c.CreditCards).Where(od => od.Order != null &&
                 od.Order.Customer != null &&
                 od.Order.Customer.Id == user.Id).ToListAsync();

            var credit_card = cust_card
                .SelectMany(od => od.Order.Customer.CreditCards)
                .DistinctBy(c => c.CustCreditCardID)
                .Where(c => c.ActiveStatus == true)
                .ToList();

            var creditCardItems = credit_card.Select(c => new {
                c.CustCreditCardID,
                Display = $"**** **** **** {c.CardNumber[^4..]} - {c.CardType}"
                }).ToList();

            creditCardItems.Add(new { CustCreditCardID = 0, Display = "Use a new card" });

            ViewBag.creditCards = new SelectList(creditCardItems, "CustCreditCardID", "Display");
            
            return View(ordered_items);
        }

        [HttpPost]
        [Authorize(Roles = "Customer, Admin, Employee")]
        public async Task<IActionResult> Checkout(int SelectedCard, CustCreditCard newCard, Order order)
        {
            AppUser user = await _userManager.GetUserAsync(User);

                var ordered_items = await _context.OrderDetails
                    .Include(od => od.Order)
                    .Include(od => od.Song).ThenInclude(s => s.Promotions)
                    .Include(od => od.Album).ThenInclude(a => a.Promotions)
                    .Where(od => od.Order.Customer.Id == user.Id && od.Order.OrderStatus == OrderStatus.InCart)
                    .ToListAsync();

            if (SelectedCard == 0)
            {
                ModelState.Clear();
                TryValidateModel(newCard);
                ModelState.Remove("User"); 
                ModelState.Remove("UserId");

                if (!Enum.IsDefined(typeof(CardType), newCard.CardType))
                {
                    ModelState.AddModelError("newCard.CardType", "Please select a card type.");
                }
                
                if (user.Status != UserStatus.Active)
                {
                    ModelState.AddModelError("", "Buyer account is not active.");
                }

                if (newCard.CardNumber.Length == 15)
                {
                    newCard.CardType = CardType.Amex;
                } 
                else if (newCard.CardNumber.StartsWith("54"))
                {
                    newCard.CardType = CardType.MasterCard;
                }
                else if (newCard.CardNumber.StartsWith("4"))
                {
                    newCard.CardType = CardType.Visa;
                }
                else if (newCard.CardNumber.StartsWith("6"))
                {
                    newCard.CardType = CardType.Discover;
                }
                else
                {
                    ModelState.AddModelError("", "Card Type cannot be recognised");
                }


                if (!ModelState.IsValid)
                {
                    var cust_card = await _context.OrderDetails.Include(od => od.Order)
                        .ThenInclude(o => o.Customer).ThenInclude(c => c.CreditCards).Where(od => od.Order != null &&
                        od.Order.Customer != null &&
                        od.Order.Customer.Id == user.Id).ToListAsync();

                    var credit_card = cust_card
                        .SelectMany(od => od.Order.Customer.CreditCards)
                        .DistinctBy(c => c.CustCreditCardID)
                        .Where(c => c.ActiveStatus == true)
                        .ToList();

                    var creditCardItems = credit_card.Select(c => new {
                        c.CustCreditCardID,
                        Display = $"**** **** **** {c.CardNumber[^4..]} - {c.CardType}"
                        }).ToList();

                    creditCardItems.Add(new { CustCreditCardID = 0, Display = "Use a new card" });
                    ViewBag.creditCards = new SelectList(creditCardItems, "CustCreditCardID", "Display");

                    return View("Checkout", ordered_items);
                }
                else
                {
                    var tempCard = new CustCreditCard
                    {
                        CardNumber = newCard.CardNumber,
                        CardType = newCard.CardType,
                        User = user,
                        ActiveStatus = false
                    };

                    var currentOrder = await _context.Orders
                        .FirstOrDefaultAsync(o => o.Customer.Id == user.Id && o.OrderStatus == OrderStatus.InCart);

                    currentOrder.Card = tempCard;

                    // currentOrder.Recipient = user;

                    await _context.SaveChangesAsync();
                }
            }
            else
            {
                var existingCard = await _context.CustCreditCards
                    .FirstOrDefaultAsync(c => c.CustCreditCardID == SelectedCard);

                ModelState.Clear();

                if (existingCard == null)
                {
                    ModelState.AddModelError("", "Selected card not found.");
                }

                if (user.Status != UserStatus.Active)
                {
                    ModelState.AddModelError("", "Buyer account is not active.");
                }

                if (!ModelState.IsValid)
                {
                    var cust_card = await _context.OrderDetails.Include(od => od.Order)
                    .ThenInclude(o => o.Customer).ThenInclude(c => c.CreditCards).Where(od => od.Order != null &&
                    od.Order.Customer != null &&
                    od.Order.Customer.Id == user.Id).ToListAsync();

                var credit_card = cust_card
                    .SelectMany(od => od.Order.Customer.CreditCards)
                    .DistinctBy(c => c.CustCreditCardID)
                    .Where(c => c.ActiveStatus == true)
                    .ToList();

                var creditCardItems = credit_card.Select(c => new {
                    c.CustCreditCardID,
                    Display = $"**** **** **** {c.CardNumber[^4..]} - {c.CardType}"
                    }).ToList();

                creditCardItems.Add(new { CustCreditCardID = 0, Display = "Use a new card" });
                ViewBag.creditCards = new SelectList(creditCardItems, "CustCreditCardID", "Display");

                return View("Checkout", ordered_items);
                
                }
                var currentOrder = await _context.Orders
                    .FirstOrDefaultAsync(o => o.Customer.Id == user.Id && o.OrderStatus == OrderStatus.InCart);

                currentOrder.Card = existingCard;

                // currentOrder.Recipient = user;

                await _context.SaveChangesAsync();
            }
            
            return RedirectToAction("ConfirmCheckout", "Orders");
        }

        [HttpGet]
        [Authorize(Roles = "Customer, Admin, Employee")]
        public async Task<IActionResult> PurchaseAsGift ()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Customer, Admin, Employee")]
        public async Task<IActionResult> PurchaseAsGift (string RecipientEmail)
        {
            AppUser user = await _userManager.GetUserAsync(User);

            if (string.IsNullOrWhiteSpace(RecipientEmail))
            {
                ModelState.AddModelError("RecipientEmail", "Recipient Email is required");
            }

            var userEmails = await _userManager.Users
            .Select(u => u.Email).ToListAsync();

            if (!userEmails.Contains(RecipientEmail))
            {
                ModelState.AddModelError("RecipientEmail", "Recipient Email/Account not found");
            }

            if (user.Email == RecipientEmail)
            {
                ModelState.AddModelError("RecipientEmail", "Cannot Gift an Order to Yourself");
            }

            if (!ModelState.IsValid)
            {
                return View();
            }

            var recipient = await _userManager.FindByEmailAsync(RecipientEmail);

            var currentOrder = await _context.Orders
                    .FirstOrDefaultAsync(o => o.Customer.Id == user.Id && o.OrderStatus == OrderStatus.InCart);

            if (recipient != null)
            {
                currentOrder.Recipient = recipient;

                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Checkout", "Orders");
        }

        [HttpGet]
        [Authorize(Roles = "Admin, Employee, Customer")]
        public async Task<IActionResult> ConfirmCheckout()
        {
            AppUser user = await _userManager.GetUserAsync(User);

            var order = await _context.Orders.Include(o => o.OrderDetails)
            .ThenInclude(od => od.Song).ThenInclude(s => s.Promotions)
            .Include(o => o.Card) 
            .Include(o => o.Recipient)
            .Include(o => o.OrderDetails)
            .ThenInclude(od => od.Album).ThenInclude(a => a.Promotions)
            .Where(o => o.OrderStatus == OrderStatus.InCart && o.Customer.Id == user.Id)
            .ToListAsync();

            return View(order);
        }

        [HttpGet]
        [Authorize(Roles = "Admin, Employee, Customer")]
        public async Task<IActionResult> Confirm ()
        {
            AppUser user = await _userManager.GetUserAsync(User);

            var currentOrder = await _context.Orders.Include(o => o.Customer).Include(o => o.Recipient)
                .Include(o => o.OrderDetails).ThenInclude(od => od.Song).ThenInclude(s => s.Genres)
                .Include(o => o.OrderDetails).ThenInclude(od => od.Album).ThenInclude(a => a.Genres)
                .FirstOrDefaultAsync(o => o.Customer.Id == user.Id && o.OrderStatus == OrderStatus.InCart);

            currentOrder.OrderDate = DateTime.Now;
            currentOrder.OrderStatus = OrderStatus.Ordered;

            await _context.SaveChangesAsync();

            Genre recommend_genre = null;

            foreach (var item in currentOrder.OrderDetails)
            {
                if (item.Song?.Genres != null && item.Song.Genres.Any())
                {
                    recommend_genre = item.Song.Genres.First();
                }
                else if (item.Album?.Genres != null && item.Album.Genres.Any())
                {
                    recommend_genre = item.Album.Genres.First();
                }
            }

            Artist recomendedArtist = _context.Artists.Include(a => a.Songs).Include(a => a.Albums)
                .Where(a => a.Genres.Contains(recommend_genre)).OrderByDescending(a => a.Reviews.Average(r => r.Rating)).FirstOrDefault();
            
            Int32 songCount = recomendedArtist.Songs.Count();
            Int32 albumCount = recomendedArtist.Albums.Count();
            Int32 totalCount = songCount + albumCount;

            Int32 randomPick = RandomNumberGenerator.GetInt32(totalCount);
            Song recommend_song = null;
            Album recommend_album = null;
            if(randomPick < songCount)
            {
                recommend_song = recomendedArtist.Songs[randomPick];
            }
            else
            {
                recommend_album = recomendedArtist.Albums[randomPick - songCount];
            }


            if (currentOrder.Customer.Id != currentOrder.Recipient.Id)
            {
                string subject = String.Format("Dear {0} {1}, Your order [#{2}] for {3} {4} is successful", currentOrder.Customer.FirstName, currentOrder.Customer.LastName, currentOrder.OrderID, currentOrder.Recipient.FirstName, currentOrder.Recipient.LastName);
                string body = String.Format("This message was intended for {0}", currentOrder.Customer.Email);
                await EmailController.SendEmailAsync("", subject, body);

                subject = String.Format("Dear {0} {1}, You have recieved a Order [#{2}] from {3} {4}", currentOrder.Recipient.FirstName, currentOrder.Recipient.LastName, currentOrder.OrderID,currentOrder.Customer.FirstName, currentOrder.Customer.LastName);
                body = String.Format("This gift consist of: \n <table><tr><th>Items</th></tr>");
                foreach (OrderDetail od in currentOrder.OrderDetails)
                {
                    if(od.Album != null)
                    {
                        body += String.Format("<tr>Album: {0}</tr>", od.Album.AlbumName);
                    }
                    if(od.Song != null)
                    {
                        body += String.Format("<tr>Song: {0}</tr>", od.Song.SongTitle);
                    }
                }
                body += "</table> \n We also recommend the ";

                if(recommend_album != null)
                {
                    body += String.Format("album: {0} that may interest you.", recommend_album.AlbumName);
                }

                if(recommend_song != null)
                {
                    body += String.Format("song: {0} that may interest you.", recommend_song.SongTitle);
                }
                await EmailController.SendEmailAsync("", subject, body);
            }
            else
            {
                string subject = String.Format("Dear {0} {1}, your purchase Order [#{2}] is successful", currentOrder.Recipient.FirstName, currentOrder.Recipient.LastName, currentOrder.OrderID);
                string body = String.Format("This order consist of: \n <table><tr><th>Items</th></tr>");
                foreach (OrderDetail od in currentOrder.OrderDetails)
                {
                    if(od.Album != null)
                    {
                        body += String.Format("<tr>Album: {0}</tr>", od.Album.AlbumName);
                    }
                    if(od.Song != null)
                    {
                        body += String.Format("<tr>Song: {0}</tr>", od.Song.SongTitle);
                    }
                }
                body += "</table> \n We also recommend the ";

                if(recommend_album != null)
                {
                    body += String.Format("album: {0} that may interest you.", recommend_album.AlbumName);
                }

                if(recommend_song != null)
                {
                    body += String.Format("song: {0} that may interest you.", recommend_song.SongTitle);
                }
                await EmailController.SendEmailAsync("", subject, body);
            }

            return View();
        }

        [HttpGet]
        [Authorize(Roles = "Admin, Employee, Customer")]
        public async Task<IActionResult> Refund (int? orderID)
        {
            var currentOrder = await _context.Orders
                .Include(o => o.Customer).Include(o => o.Recipient)
                .Include(o => o.OrderDetails).ThenInclude(o => o.Song)
                .Include(o => o.OrderDetails).ThenInclude(o => o.Album)
                .Where(o => o.OrderID == orderID)
                .FirstOrDefaultAsync();

            return View(currentOrder);
        }

        [HttpGet]
        [Authorize(Roles = "Admin, Employee, Customer")]
        public async Task<IActionResult> CancellOrder (int? orderID)
        {
            if (orderID == null)
            {
                NotFound();
            }

            var currentOrder = await _context.Orders
                .Include(o => o.Customer).Include(o => o.Recipient)
                .Include(o => o.OrderDetails).ThenInclude(o => o.Song)
                .Include(o => o.OrderDetails).ThenInclude(o => o.Album)
                .Where(o => o.OrderID == orderID)
                .FirstOrDefaultAsync();

            currentOrder?.OrderStatus = OrderStatus.Refunded;

            await _context.SaveChangesAsync();

            var currentSong = currentOrder?.OrderDetails
                .Where(od => od.Song != null)
                .Select(od => od.Song)
                .ToList();
            
            var currentAlbum = currentOrder?.OrderDetails
                .Where(od => od.Album != null)
                .Select(od => od.Album)
                .ToList();

            if (currentOrder?.Recipient.Id != currentOrder?.Customer.Id)
            {
            string subject = String.Format("Dear {0} {1}, Your order [#{2}] for {3} {4} has been successful Refunded", currentOrder.Customer.FirstName, currentOrder.Customer.LastName, currentOrder.OrderID, currentOrder.Recipient.FirstName, currentOrder.Recipient.LastName);
            string body = String.Format("The following items from the order you have refunded has been removed from the recipient's account: \n <table><tr><th>Items</th></tr>");
                foreach (OrderDetail od in currentOrder.OrderDetails)
                {
                    if(od.Album != null)
                    {
                        body += String.Format("<tr>Album: {0}</tr>", od.Album.AlbumName);
                    }
                    if(od.Song != null)
                    {
                        body += String.Format("<tr>Song: {0}</tr>", od.Song.SongTitle);
                    }
                }
            await EmailController.SendEmailAsync("", subject, body);

            subject = String.Format("Dear {0} {1}, Your order [#{2}] from {3} {4} has been successful Refunded", currentOrder.Recipient.FirstName, currentOrder.Recipient.LastName, currentOrder.OrderID, currentOrder.Customer.FirstName, currentOrder.Customer.LastName);
            body = String.Format("The following items from the order you have refunded has been removed from your account: \n <table><tr><th>Items</th></tr>");
                foreach (OrderDetail od in currentOrder.OrderDetails)
                {
                    if(od.Album != null)
                    {
                        body += String.Format("<tr>Album: {0}</tr>", od.Album.AlbumName);
                    }
                    if(od.Song != null)
                    {
                        body += String.Format("<tr>Song: {0}</tr>", od.Song.SongTitle);
                    }
                }
            await EmailController.SendEmailAsync("", subject, body);

            }
            else
            {
            string subject = String.Format("Dear {0} {1}, Your order [#{2}] has been successful Refunded", currentOrder.Recipient.FirstName, currentOrder.Recipient.LastName, currentOrder.OrderID);
            string body = String.Format("The following items from the order you have refunded has been removed from your account: \n <table><tr><th>Items</th></tr>");
                foreach (OrderDetail od in currentOrder.OrderDetails)
                {
                    if(od.Album != null)
                    {
                        body += String.Format("<tr>Album: {0}</tr>", od.Album.AlbumName);
                    }
                    if(od.Song != null)
                    {
                        body += String.Format("<tr>Song: {0}</tr>", od.Song.SongTitle);
                    }
                }
            await EmailController.SendEmailAsync("", subject, body);
            }
            return View();
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
