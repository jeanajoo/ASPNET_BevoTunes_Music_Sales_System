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
using Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Manage.Internal;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace G6_BevoTunes.Controllers
{
    [Authorize(Roles = "Customer, Admin, Employee")]
    public class OrderDetailsController : Controller
    {
        private readonly AppDbContext _context;

        private readonly UserManager<AppUser> _userManager;

        public OrderDetailsController(AppDbContext context, UserManager<AppUser> userManager)
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

        [Authorize(Roles = "Customer, Admin, Employee")]
        // GET: OrderDetails
        public async Task<IActionResult> Index()
        {
            AppUser user = await _userManager.GetUserAsync(User);

            if (User.IsInRole("Customer"))
            {
                var orderDetails = await _context.OrderDetails
                .Include(od => od.Song).ThenInclude(s => s.Promotions)
                .Include(od => od.Album).ThenInclude(a => a.Promotions)
                .Include(od => od.Order).ThenInclude(o => o.Customer)
                .Where(od => od.Order.Customer.Id == user.Id && od.Order.OrderStatus == OrderStatus.InCart)
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

        // GET: OrderDetails/Details/5
        [HttpGet]
        [Authorize(Roles = "Customer, Admin, Employee")]
        public async Task<IActionResult> Details(int? id)
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

        // GET: OrderDetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OrderDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Customer, Admin, Employee")]
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
        [Authorize(Roles = "Customer, Admin, Employee")]

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
        [Authorize(Roles = "Customer, Admin, Employee")]
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
        public async Task<IActionResult> Checkout(int SelectedCard, CustCreditCard newCard)
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
                

                if (!ModelState.IsValid)
                {
                    var cust_card = await _context.OrderDetails.Include(od => od.Order)
                        .ThenInclude(o => o.Customer).ThenInclude(c => c.CreditCards).Where(od => od.Order != null &&
                        od.Order.Customer != null &&
                        od.Order.Customer.Id == user.Id).ToListAsync();

                    var credit_card = cust_card
                        .SelectMany(od => od.Order.Customer.CreditCards)
                        .DistinctBy(c => c.CustCreditCardID)
                        .ToList();

                    var creditCardItems = credit_card.Select(c => new {
                        c.CustCreditCardID,
                        Display = $"**** **** **** {c.CardNumber[^4..]} - {c.CardType}"
                        }).ToList();

                    creditCardItems.Add(new { CustCreditCardID = 0, Display = "Use a new card" });
                    ViewBag.creditCards = new SelectList(creditCardItems, "CustCreditCardID", "Display");

                    return View("Checkout", ordered_items);
                }
            }

            return RedirectToAction("Index", "OrderDetails");
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

            var orderdetail = await _context.OrderDetails.ToListAsync();

            return RedirectToAction("Checkout", "OrderDetails");
        }

        private bool OrderDetailExists(int id)
        {
            return _context.OrderDetails.Any(e => e.OrderDetailID == id);
        }
    }
}
