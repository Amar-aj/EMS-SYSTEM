using employee_management_system.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using employee_management_system.Data;
using Microsoft.EntityFrameworkCore;
using employee_management_system.Services;

namespace employee_management_system.Controllers;

public class AccountController(AppDbContext _appDbContext, IPasswordHashService _passwordHashService) : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginRequest user)
    {
        // Authenticate user (you may want to check credentials against your database)
        var userData = await _appDbContext.Users.FirstOrDefaultAsync(x => x.UserName == user.UserName);
        if (userData == null)
        {
            return View(user);
        }
        else
        {
            if (await _passwordHashService.VerifyPasswordAsync(userData.Password, user.Password))
            {

                // Create claims
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, userData.UserName),
                    new Claim(ClaimTypes.Role, userData.Role.ToString())
                    // Add more claims as needed
                };

                // Create identity
                var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);

                // Create authentication properties
                var authProperties = new AuthenticationProperties
                {
                    // You can customize authentication properties if needed
                };

                // Sign in the user
                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);

                return RedirectToAction("Index", "Home");

            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return View(user);
            }
        }


        // Failed login
        ModelState.AddModelError(string.Empty, "Invalid login attempt.");
        return View(user);
    }

    [HttpGet]
    public async Task<IActionResult> Logout()
    {
        // Sign out the user
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

        return RedirectToAction("Index", "Home");
    }

    
    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterRequest user)
    {
        // Hash the user's password before storing it
        var hashedPassword = await _passwordHashService.HashPasswordAsync(user.Password);

        var userData = new UserModel
        {
            UserName = user.UserName,
            Password = hashedPassword,
            Role = UserRole.EMP
        };

        await _appDbContext.AddAsync(userData);
        await _appDbContext.SaveChangesAsync();


        return RedirectToAction("Login");
    }



    [HttpGet]
    [Authorize(Roles = "EMP")] // Example: Only allow EMP to access this action
    public IActionResult EmpAction()
    {
        return View();
    }

}
