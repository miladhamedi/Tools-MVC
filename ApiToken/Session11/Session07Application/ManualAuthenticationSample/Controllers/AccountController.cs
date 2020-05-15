using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ManualAuthenticationSample.Common;
using ManualAuthenticationSample.Entities;
using ManualAuthenticationSample.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace ManualAuthenticationSample.Controllers
{
    public class AccountController : Controller
    {
        private FadContext _context;
        private IMemoryCache _cache;
        private ILogger<AccountController> _logger;

        public AccountController(FadContext context, IMemoryCache cache, ILogger<AccountController> logger)
        {
            _context = context;
            _cache = cache;
            _logger = logger;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _context.Users.SingleOrDefault(q => q.UserName == model.UserName);
                if(user == null)
                {
                    _logger.LogError("Invalid UserName {0}", model.UserName);
                    ModelState.AddModelError("","invalid username & password");
                    return View(model);
                }
             
                var hashPassword =  EncyrptionUtility.GenerateHashWithSalt(model.Password, user.PasswordSalt);
                if(user.Password != hashPassword)
                {
                    ModelState.AddModelError("", "invalid username & password");
                    return View(model);
                }
                var userRoles = _context.UserRoles.Where(q => q.UserId == user.Id).Select(q => q.RoleId).ToList();
                var roles = string.Join(',', userRoles);

                var claims = new List<Claim>
                {
                        new Claim(ClaimTypes.Name, user.UserName),
                        new Claim("FullName", user.UserName),
                        new Claim("Role", roles),
                        //new Claim(ClaimTypes.Role, "Administrator"),
                };

                var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    //AllowRefresh = <bool>,
                    // Refreshing the authentication session should be allowed.

                    ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
                    // The time at which the authentication ticket expires. A 
                    // value set here overrides the ExpireTimeSpan option of 
                    // CookieAuthenticationOptions set with AddCookie.

                    //IsPersistent = true,
                    // Whether the authentication session is persisted across 
                    // multiple requests. When used with cookies, controls
                    // whether the cookie's lifetime is absolute (matching the
                    // lifetime of the authentication ticket) or session-based.

                    //IssuedUtc = <DateTimeOffset>,
                    // The time at which the authentication ticket was issued.

                    //RedirectUri = <string>
                    // The full path or absolute URI to be used as an http 
                    // redirect response value.
                };

                List<Permissions> userPermissions =
                    _context.Permissions.Where(q => q.RolePermissions.Any(r => userRoles.Contains(r.RoleId))).ToList();
                var key = string.Format(CacheConstants.UserPermissionsCacheKey, user.UserName);
                _cache.Set(key, userPermissions);
                

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);
            }
            return RedirectToAction("Index", "Home");
        }


      
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {

                //check password with confirmpassword
                //check user name already!!!!!
                var saltPassword = Guid.NewGuid().ToString();
                var hashPassword = EncyrptionUtility.GenerateHashWithSalt(model.Password, saltPassword); //EncyrptionUtility.HashSHA256($"{saltPassword}{model.Password}");

                var user = new Users
                {
                    CreateDate = DateTime.Now,
                    Id = Guid.NewGuid(),
                    IsActive = true,
                    UserName = model.UserName,
                    PasswordSalt = saltPassword,
                    Password = hashPassword
                };
                await _context.AddAsync(user);
                await _context.SaveChangesAsync();

                return RedirectToAction("Login");
            }
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(
                 CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }
    }
}