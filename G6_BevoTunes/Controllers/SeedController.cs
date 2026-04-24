using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


//TODO: Update this using statement to include your project name
using G6_BevoTunes.Models;
using G6_BevoTunes.DAL;
using G6_BevoTunes.Seeding;
using System;
using Microsoft.AspNetCore.Authorization;

//TODO: Upddate this namespace to match your project name
namespace G6_BevoTunes.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SeedController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public SeedController(AppDbContext db, UserManager<AppUser> um, RoleManager<IdentityRole> rm)
        {
            _context = db;
            _userManager = um;
            _roleManager = rm;
        }

        public async Task<IActionResult> Seed()
        {
            try
            {
                //call the method to seed the roles
                SeedGenres.SeedAllGenres(_context);
                SeedArtists.SeedAllArtists(_context);
                SeedAlbums.SeedAllAlbums(_context);
                SeedSongs.SeedAllSongs(_context);
                SeedPromotions.SeedAllPromotions(_context);
                await SeedRoles.AddAllRoles(_roleManager);
                await SeedUsers.SeedAllUsers(_userManager, _context);
                await SeedCustCreditCards.SeedAllCustCreditCards(_context, _userManager);
                await SeedOrders.SeedAllOrders(_context, _userManager);
                await SeedReviews.SeedAllReviews(_context, _userManager);
            }
            catch (Exception ex)
            {
                //add the error messages to a list of strings
                List<String> errorList = new List<String>();

                //Add the outer message
                errorList.Add(ex.Message);

                //Add the message from the inner exception
                errorList.Add(ex.InnerException.Message);

                //Add additional inner exception messages, if there are any
                if (ex.InnerException.InnerException != null)
                {
                    errorList.Add(ex.InnerException.InnerException.Message);
                }

                return View("Error", errorList);
            }

            //this is the happy path - seeding worked!
            return Redirect("https://www.youtube.com/watch?v=dQw4w9WgXcQ");
        }
        
    }
}
