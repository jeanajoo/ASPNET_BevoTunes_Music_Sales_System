using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

//TODO: Change these using statements to match your project
using G6_BevoTunes.DAL;
using G6_BevoTunes.Models;
using G6_BevoTunes.Utilities;
using System;

//TODO: Change this namespace to match your project
namespace G6_BevoTunes.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly PasswordValidator<AppUser> _passwordValidator;
        private readonly AppDbContext _context;

        public AccountController(AppDbContext appDbContext, UserManager<AppUser> userManager, SignInManager<AppUser> signIn)
        {
            _context = appDbContext;
            _userManager = userManager;
            _signInManager = signIn;
            //user manager only has one password validator
            _passwordValidator = (PasswordValidator<AppUser>)userManager.PasswordValidators.FirstOrDefault();
        }

        // GET: /Account/Register
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel rvm)
        {
            //if registration data is valid, create a new user on the database
            if (ModelState.IsValid == false)
            {
                return View(rvm);
            }

            // This code maps the RegisterViewModel to the AppUser domain model
            AppUser newUser = new AppUser
            {
                UserName = rvm.Email,
                Email = rvm.Email,
                PhoneNumber = rvm.PhoneNumber,
                FirstName = rvm.FirstName,
                LastName = rvm.LastName,
                Address = rvm.Address,
                ZipCode = rvm.ZipCode
            }; 

            // create AddUserModel
            AddUserModel aum = new AddUserModel()
            {
                User = newUser, // Now 'newUser' will be recognized
                Password = rvm.Password,
                RoleName = "Customer"
            };

            // This code uses the AddUser utility to create a new user
            IdentityResult result = await Utilities.AddUser.AddUserWithRoleAsync(aum, _userManager, _context);

            if (result.Succeeded) 
            {
                await _signInManager.PasswordSignInAsync(rvm.Email, rvm.Password, false, lockoutOnFailure: false);
                return RedirectToAction("Index", "Home");
            }
            else  
            {
                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(rvm);
            }
        }

        // GET: /Account/Login
        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            if (User.Identity.IsAuthenticated) //user has been redirected here from a page they're not authorized to see
            {
                return View("Error", new string[] { "Access Denied" });
            }
            _signInManager.SignOutAsync(); //this removes any old cookies hanging around
            ViewBag.ReturnUrl = returnUrl; //pass along the page the user should go back to
            return View();
        }

        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel lvm, string? returnUrl)
        {
            if (ModelState.IsValid == false) return View(lvm);

            var user = await _userManager.FindByEmailAsync(lvm.Email);
            if (user != null && user.Status == UserStatus.Blocked)
            {
                ModelState.AddModelError("", "Your account has been disabled. Please contact a Admin.");
                return View(lvm);
            }
            var result = await _signInManager.PasswordSignInAsync(lvm.Email, lvm.Password, lvm.RememberMe, lockoutOnFailure: false);

            if (result.Succeeded) return Redirect(returnUrl ?? "/");
            
            ModelState.AddModelError("", "Invalid login attempt.");
            return View(lvm);
        }

        public IActionResult AccessDenied()
        {
            return View("Error", new string[] { "You are not authorized for this resource" });
        }

        //GET: Account/Index
        public IActionResult Index()
        {
            IndexViewModel ivm = new IndexViewModel();

            //get user info
            String id = User.Identity.Name;
            AppUser user = _context.Users.FirstOrDefault(u => u.UserName == id);

            //populate the view model
            //(i.e. map the domain model to the view model)
            ivm.Email = user.Email;
            ivm.HasPassword = true;
            ivm.UserID = user.Id;
            ivm.UserName = user.UserName;

            //send data to the view
            return View(ivm);
        }



        //Logic for change password
        // GET: /Account/ChangePassword
        public ActionResult ChangePassword()
        {
            return View();
        }



        // POST: /Account/ChangePassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ChangePassword(ChangePasswordViewModel cpvm)
        {
            //if user forgot a field, send them back to 
            //change password page to try again
            if (ModelState.IsValid == false)
            {
                return View(cpvm);
            }

            //Find the logged in user using the UserManager
            AppUser userLoggedIn = await _userManager.FindByNameAsync(User.Identity.Name);

            //Attempt to change the password using the UserManager
            var result = await _userManager.ChangePasswordAsync(userLoggedIn, cpvm.OldPassword, cpvm.NewPassword);

            //if the attempt to change the password worked
            if (result.Succeeded)
            {
                //sign in the user with the new password
                await _signInManager.SignInAsync(userLoggedIn, isPersistent: false);

                //send the user back to the home page
                return RedirectToAction("Index", "Home");
            }
            else //attempt to change the password didn't work
            {
                //Add all the errors from the result to the model state
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                //send the user back to the change password page to try again
                return View(cpvm);
            }
        }

        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult LogOff()
        {
            //sign the user out of the application
            _signInManager.SignOutAsync();

            //send the user back to the home page
            return RedirectToAction("Index", "Home");
        }
        // Get: /Account/List
        [Authorize(Roles = "Employee,Admin")]
        public async Task<IActionResult> UserIndex()
        {
            UserIndexViewModel uivm = new UserIndexViewModel();
            uivm.Customers = [.. await _userManager.GetUsersInRoleAsync("Customer")];

            if (User.IsInRole("Admin"))
            {
                uivm.Employees = [.. await _userManager.GetUsersInRoleAsync("Employee")];
                uivm.Managers = [.. await _userManager.GetUsersInRoleAsync("Admin")];
            }
            
            return View(uivm);
        }
        // POST: /Account/ToggleStatus
        [HttpPost]
        [Authorize(Roles = "Employee,Admin")]
        public async Task<IActionResult> ToggleStatus(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();

            // Toggle logic
            if (user.Status == UserStatus.Active)
            {
                user.Status = UserStatus.Blocked;
            }
            else
            {
                user.Status = UserStatus.Active;
            }

            await _userManager.UpdateAsync(user);
            return RedirectToAction("UserIndex"); 
        }

        // POST: /Account/PromoteToManager
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> PromoteToManager(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                await _userManager.AddToRoleAsync(user, "Admin");
                await _userManager.RemoveFromRoleAsync(user, "Employee");
            }
            return RedirectToAction(nameof(UserIndex));
        }
        [Authorize(Roles = "Employee,Admin")]
        public IActionResult CreateCustomer() => View();

        [HttpPost]
        [Authorize(Roles = "Employee,Admin")]
        public async Task<IActionResult> CreateCustomer(RegisterViewModel rvm)
        {
            if (ModelState.IsValid == false) return View(rvm);

            AppUser newUser = new AppUser {
                UserName = rvm.Email, Email = rvm.Email, 
                FirstName = rvm.FirstName, LastName = rvm.LastName,
                PhoneNumber = rvm.PhoneNumber
            };

            AddUserModel aum = new AddUserModel {
                User = newUser, Password = rvm.Password, RoleName = "Customer"
            };

            IdentityResult result = await Utilities.AddUser.AddUserWithRoleAsync(aum, _userManager, _context);

            if (result.Succeeded) {
                return RedirectToAction(nameof(UserIndex));
            }
            
            foreach (var error in result.Errors) ModelState.AddModelError("", error.Description);
            return View(rvm);
        }
        // GET: /Account/Edit
        public async Task<IActionResult> Edit(string id)
        {
            // 1. Security Check: Only Managers can edit someone else. 
            // Everyone else can only edit themselves.
            AppUser userLoggedIn = await _userManager.FindByNameAsync(User.Identity.Name);

            if (id != userLoggedIn.Id && !User.IsInRole("Admin"))
            {
                return View("Error", new string[] { "You do not have permission to edit this profile." });
            }

            // 2. Find the user to edit
            AppUser userToEdit = await _userManager.FindByIdAsync(id);
            if (userToEdit == null) return NotFound();

            // 3. Map to AccountViewModel
            EditViewModel evm = new EditViewModel
            {
                FirstName = userToEdit.FirstName,
                LastName = userToEdit.LastName,
                PhoneNumber = userToEdit.PhoneNumber,
                Address = userToEdit.Address,
            };

            return View(evm);
        }
        // POST: /Account/Edit
        [HttpPost]  
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditViewModel evm)
        {
            if (ModelState.IsValid == false) return View(evm);

            AppUser userToUpdate = await _userManager.FindByIdAsync(evm.UserID);
            
            // 1. Basic Info Update
            userToUpdate.FirstName = evm.FirstName;
            userToUpdate.LastName = evm.LastName;
            userToUpdate.Address = evm.Address;
            userToUpdate.PhoneNumber = evm.PhoneNumber;

            // 2. Credit Card Update (Assume you added CreditCard1/2 to AppUser model)
            if (!string.IsNullOrEmpty(evm.CardNumber1))
            {
                string type = GetCardType(evm.CardNumber1);
                if (type == "Invalid Card Type") {
                    ModelState.AddModelError("CardNumber1", "Invalid card number or format.");
                    return View(evm);
                }
                userToUpdate.CustCreditCard1 = evm.CardNumber1;
            }

            // 3. Password Change (Only if they filled out the fields)
            if (!string.IsNullOrEmpty(evm.NewPassword))
            {
                if (string.IsNullOrEmpty(evm.OldPassword))
                {
                    ModelState.AddModelError("OldPassword", "Current password is required to set a new one.");
                    return View(evm);
                }

                var changePass = await _userManager.ChangePasswordAsync(userToUpdate, evm.OldPassword, evm.NewPassword);
                if (!changePass.Succeeded)
                {
                    foreach (var error in changePass.Errors) ModelState.AddModelError("", error.Description);
                    return View(evm);
                }
            }

            await _userManager.UpdateAsync(userToUpdate);
            return RedirectToAction("Index", "Home");
        }

        // credit card type helper method
        private string GetCardType(string cardNumber)
        {
            if (string.IsNullOrEmpty(cardNumber)) return "None";
            
            string cleanNumber = cardNumber.Replace("-", "").Replace(" ", "");

            if (cleanNumber.Length == 15 && cleanNumber.StartsWith("3"))
            {
                return "American Express";
            }
            
            if (cleanNumber.Length == 16)
            {
                if (cleanNumber.StartsWith("4")) return "Visa";
                if (cleanNumber.StartsWith("54")) return "MasterCard";
                if (cleanNumber.StartsWith("6")) return "Discover";
            }

            return "Invalid Card Type";
        }
    }
 }