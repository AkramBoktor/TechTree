using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechTreeMVCWebApplication.Data;
using TechTreeMVCWebApplication.Models;

namespace TechTreeMVCWebApplication.Controllers
{
    public class UserAuthController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationDbContext _context;

        public UserAuthController(ApplicationDbContext _context,
                                  SignInManager<ApplicationUser> _signInManager,
                                  UserManager<ApplicationUser> _userManager)
        {
            this._context = _context;
            this._signInManager = _signInManager;
            this._userManager = _userManager;
        }
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            loginModel.LoginInValid = "true";

            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(loginModel.Email,
                                                                     loginModel.Password,
                                                                     loginModel.RememberMe,
                                                                     lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    loginModel.LoginInValid = "";
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt");
                }

            }
            return PartialView("_UserLoginPartial", loginModel);

        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout(string returnUrl = null)
        {
            await _signInManager.SignOutAsync();

            if (returnUrl != null)
            {
                return LocalRedirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterUser(RegistrationModel registrationModel)
        {
            registrationModel.RegistrationInValid = "true";
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser
                {
                    UserName = registrationModel.Email,
                    Email = registrationModel.Email,
                    PhoneNumber = registrationModel.PhoneNumber,
                    FirstName = registrationModel.FirstName,
                    LastName = registrationModel.LastName,
                    Address1 = registrationModel.Address1,
                    Address2 = registrationModel.Address2,
                    PostCode = registrationModel.PostCode

                };

                var result = await _userManager.CreateAsync(user, registrationModel.Password);

                if (result.Succeeded)
                {
                    registrationModel.RegistrationInValid = "";

                    await _signInManager.SignInAsync(user, isPersistent: false);

                    return PartialView("_UserRegisterationPartial", registrationModel);
                }

                AddErrorsToModelState(result);

            }
            return PartialView("_UserRegisterationPartial", registrationModel);


        }


        //check id username exists
        [AllowAnonymous]
        public async Task<bool> UserNameCheck(string userName)
        {
            var userNameExists = await this._context.Users.AnyAsync(u => u.UserName.ToLower() == userName.ToLower());
            if (userNameExists)
            {
                ModelState.AddModelError("User Name", "User Name already exists");
                return true;
            }

            return false;
        }
        private void AddErrorsToModelState(IdentityResult result)
        {
            foreach (var error in result.Errors)
                ModelState.AddModelError(string.Empty, error.Description);
        }
    }
}
