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
    public class CustCreditCardsController : Controller
    {
        private readonly AppDbContext _context;

        public CustCreditCardsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: CustCreditCards
        public async Task<IActionResult> Index()
        {
            return View(await _context.CustCreditCards.ToListAsync());
        }

        // GET: CustCreditCards/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var custCreditCard = await _context.CustCreditCards
                .FirstOrDefaultAsync(m => m.CustCreditCardID == id);
            if (custCreditCard == null)
            {
                return NotFound();
            }

            return View(custCreditCard);
        }

        // GET: CustCreditCards/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CustCreditCards/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustCreditCardID,CardNumber,CardType")] CustCreditCard custCreditCard)
        {
            if (ModelState.IsValid)
            {
                _context.Add(custCreditCard);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(custCreditCard);
        }

        // GET: CustCreditCards/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var custCreditCard = await _context.CustCreditCards.FindAsync(id);
            if (custCreditCard == null)
            {
                return NotFound();
            }
            return View(custCreditCard);
        }

        // POST: CustCreditCards/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CustCreditCardID,CardNumber,CardType")] CustCreditCard custCreditCard)
        {
            if (id != custCreditCard.CustCreditCardID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(custCreditCard);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustCreditCardExists(custCreditCard.CustCreditCardID))
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
            return View(custCreditCard);
        }

        // GET: CustCreditCards/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var custCreditCard = await _context.CustCreditCards
                .FirstOrDefaultAsync(m => m.CustCreditCardID == id);
            if (custCreditCard == null)
            {
                return NotFound();
            }

            return View(custCreditCard);
        }

        // POST: CustCreditCards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var custCreditCard = await _context.CustCreditCards.FindAsync(id);
            if (custCreditCard != null)
            {
                _context.CustCreditCards.Remove(custCreditCard);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustCreditCardExists(int id)
        {
            return _context.CustCreditCards.Any(e => e.CustCreditCardID == id);
        }
    }
}
