using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MvcCookieAuthSample.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using MvcCookieAuthSample.ViewModels;
using Microsoft.AspNetCore.Identity;
using MvcCookieAuthSample.Data;

namespace MvcCookieAuthSample.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }

            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in  result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Register(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                ViewData["ReturnUrl"] = returnUrl;
                var identieyUser = new ApplicationUser
                {
                    Email = registerViewModel.Email,
                    UserName = registerViewModel.Email,
                    NormalizedUserName = registerViewModel.Email,

                };
                var identityResult = await _userManager.CreateAsync(identieyUser, registerViewModel.Password);
                if (identityResult.Succeeded)
                {
                    await _signInManager.SignInAsync(identieyUser, new AuthenticationProperties { IsPersistent = true });
                    return RedirectToLocal(returnUrl);
                }
                else
                {
                    AddErrors(identityResult);
                }
            }

            return View();

        }

        public IActionResult Login(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                ViewData["ReturnUrl"] = returnUrl;
                var user = await _userManager.FindByEmailAsync(loginViewModel.Email);
                if (user == null)
                {

                }

                await _signInManager.SignInAsync(user, new AuthenticationProperties { IsPersistent = true });
                return RedirectToLocal(returnUrl);
            }
            return View();

        }


        public async Task<IActionResult> makinLogin(string returnUrl = "/")
        {
            var claims = new List<Claim>{
                new Claim(ClaimTypes.Name,"jesse"),
                new Claim(ClaimTypes.Role,"admin")
            };

            var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimIdentity));
            return Redirect(returnUrl);
            //return Ok();
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            // await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }
    }
}
