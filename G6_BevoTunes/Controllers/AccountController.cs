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
                ZipCode = rvm.ZipCode,
                Status = UserStatus.Active
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
                await EmailController.SendEmailAsync("", String.Format("Your account registration is successful, {0} {1}", newUser.FirstName, newUser.LastName), String.Format("Welcome to BevoTunes! This message was intended for {0}", newUser.Email));
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
        public async Task<IActionResult> Index()
        {
            IndexViewModel ivm = new IndexViewModel();

            // 1. Get the email from the current login cookie
            string id = User.Identity.Name;

            // 2. Try to find the user in the database
            // We use FindByNameAsync because in your setup, Email IS the UserName
            AppUser user = await _userManager.FindByNameAsync(id);

            // 3. THE GUARD: This prevents the crash
            if (user == null)
            {
                // If the user isn't found, it means the cookie is out of sync.
                // We sign them out and send them to Login to refresh the cookie.
                await _signInManager.SignOutAsync();
                return RedirectToAction("Login", "Account");
            }

            // 4. Now it is safe to map the properties because we know 'user' is not null
            ivm.Email = user.Email;
            ivm.HasPassword = true;
            ivm.UserID = user.Id;
            ivm.UserName = user.UserName;
            ivm.FirstName = user.FirstName;
            ivm.LastName = user.LastName;
            ivm.Address = user.Address;
            ivm.ZipCode = user.ZipCode;
            ivm.PhoneNumber = user.PhoneNumber;

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
            AppUser user = await _userManager.FindByIdAsync(id);

            if (user == null) return NotFound();

            bool IsCustomer = await _userManager.IsInRoleAsync(user, "Customer");

            // Toggle logic
            if (user.Status == UserStatus.Active)
            {
                user.Status = IsCustomer ? UserStatus.Deleted : UserStatus.Blocked;
            }
            else
            {
                user.Status = UserStatus.Active;
            }
            
            var result = await _userManager.UpdateAsync(user);
            
            if (result.Succeeded)
            {
                return RedirectToAction("UserIndex", new { message = "User status updated successfully." });
            }
            return RedirectToAction("UserIndex", new { error = "Failed to update user status." });
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
        private static readonly string[] AllowedRoles = { "Customer", "Employee" };

        [Authorize(Roles = "Employee,Admin")]
        public IActionResult CreateCustomer(string role = "Customer")
        {
            if (!AllowedRoles.Contains(role)) role = "Customer";
            ViewBag.Role = role;
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Employee,Admin")]
        public async Task<IActionResult> CreateCustomer(RegisterViewModel rvm, string role = "Customer")
        {
            if (!AllowedRoles.Contains(role)) role = "Customer";

            if (!ModelState.IsValid)
            {
                ViewBag.Role = role;
                return View(rvm);
            }

            AppUser newUser = new AppUser {
                UserName = rvm.Email,
                Email = rvm.Email,
                PhoneNumber = rvm.PhoneNumber,
                FirstName = rvm.FirstName,
                LastName = rvm.LastName,
                Address = rvm.Address,
                ZipCode = rvm.ZipCode,
                Status = UserStatus.Active
            };

            AddUserModel aum = new AddUserModel {
                User = newUser, Password = rvm.Password, RoleName = role
            };

            IdentityResult result = await Utilities.AddUser.AddUserWithRoleAsync(aum, _userManager, _context);

            if (result.Succeeded) {
                if (role == "Customer")
                {
                    await EmailController.SendEmailAsync("", String.Format("Your account registration by an employee is successful, {0} {1}", newUser.FirstName, newUser.LastName), String.Format("Welcome to BevoTunes! This message was intended for {0}", newUser.Email));
                }
                return RedirectToAction(nameof(UserIndex));
            }
            
            foreach (var error in result.Errors) ModelState.AddModelError("", error.Description);
            ViewBag.Role = role;
            return View(rvm);
        }
        // GET: /Account/Edit
        [Authorize]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null) return NotFound();

            AppUser userToEdit = await _context.Users
                .Include(u => u.CreditCards)
                .FirstOrDefaultAsync(u => u.Id == id);

            if (userToEdit == null) return NotFound();

            // Mapping the data to the ViewModel
            EditViewModel evm = new EditViewModel
            {
                UserID = userToEdit.Id,
                FirstName = userToEdit.FirstName,
                LastName = userToEdit.LastName, 
                Email = userToEdit.Email,
                PhoneNumber = userToEdit.PhoneNumber,
                Address = userToEdit.Address,
                ZipCode = userToEdit.ZipCode,
            };

            return View(evm);
        }

        // POST: /Account/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditViewModel evm)
        {
            if (!ModelState.IsValid) return View(evm);

            // 1. Get the user from the database
            AppUser userToUpdate = await _userManager.FindByIdAsync(evm.UserID);
            AppUser loggedInUser = await _userManager.FindByNameAsync(User.Identity.Name);

            if (userToUpdate == null) return NotFound();

            // 2. Update Profile Fields (Name, Address, etc.)
            if (!(User.IsInRole("Employee") && userToUpdate.Id == loggedInUser.Id))
            {
                userToUpdate.FirstName = evm.FirstName;
                userToUpdate.LastName = evm.LastName;
            }

            if (User.IsInRole("Admin") || userToUpdate.Id == loggedInUser.Id)
            {
                userToUpdate.Email = evm.Email;
                userToUpdate.UserName = evm.Email; // Keep UserName in sync
            }

            userToUpdate.PhoneNumber = evm.PhoneNumber;
            userToUpdate.Address = evm.Address;
            userToUpdate.ZipCode = evm.ZipCode;
            // userToUpdate.City = evm.City;
            // userToUpdate.State = evm.State;

            // 3. Save the Profile Changes
            var updateResult = await _userManager.UpdateAsync(userToUpdate);
            if (!updateResult.Succeeded)
            {
                foreach (var error in updateResult.Errors) ModelState.AddModelError("", error.Description);
                return View(evm);
            }

            // 4. PASSWORD CHANGE (If requested)
            if (!string.IsNullOrWhiteSpace(evm.NewPassword))
            {
                // Re-fetch to ensure we have the latest data
                var freshUser = await _userManager.FindByIdAsync(evm.UserID);

                if ((User.IsInRole("Admin") || User.IsInRole("Employee")) && evm.UserID != loggedInUser.Id)
                {
                    // 1. Check if they have a password to remove
                    var hasPassword = await _userManager.HasPasswordAsync(freshUser);
                    if (hasPassword)
                    {
                        var removeResult = await _userManager.RemovePasswordAsync(freshUser);
                        if (!removeResult.Succeeded)
                        {
                            foreach (var error in removeResult.Errors) ModelState.AddModelError("", error.Description);
                            return View(evm);
                        }
                    }

                    // 2. Add the NEW password
                    var addResult = await _userManager.AddPasswordAsync(freshUser, evm.NewPassword);
                    if (!addResult.Succeeded)
                    {
                        // If the password is too simple (e.g., no capital letter), it fails here
                        foreach (var error in addResult.Errors) ModelState.AddModelError("", error.Description);
                        return View(evm);
                    }

                    // 3. Sync the Security Stamp
                    await _userManager.UpdateSecurityStampAsync(freshUser);
                }

                if (evm.UserID == loggedInUser.Id)
                {
                    var result = await _userManager.ChangePasswordAsync(loggedInUser, evm.OldPassword, evm.NewPassword);

                    //if the attempt to change the password worked
                    if (result.Succeeded)
                    {
                        //sign in the user with the new password
                        await _signInManager.SignInAsync(loggedInUser, isPersistent: false);

                        //send the user back to the home page
                        return RedirectToAction("Index", "Account");
                    }
                    else //attempt to change the password didn't work
                    {
                        //Add all the errors from the result to the model state
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }

                        //send the user back to the change password page to try again
                        return View(evm);
                    }
                }
            }
            return RedirectToAction("Index", "Account");
        }
    }
}