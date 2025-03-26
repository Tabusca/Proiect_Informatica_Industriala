using ProiectV2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http; // Pentru sesiune
using System.Collections.Generic;
using System.Linq;

namespace ProiectV2.Controllers
{
    public class AccountController : Controller
    {
        // Lista utilizatorilor stocată temporar în memorie
        public static List<UserApplication> Users = new List<UserApplication>
        {
            new UserApplication
            {
                FirstName = "Alexandra",
                LastName = "Popescu",
                Email = "alexandra@example.com",
                PasswordHash = "1234",
                RememberMe = false,
                CreatedAt = DateTime.Now
            },
            new UserApplication
            {
                FirstName = "Paula",
                LastName = "Pop",
                Email = "paula@example.com",
                PasswordHash = "parola",
                RememberMe = true,
                CreatedAt = DateTime.Now
            }
        };

        // Login (GET)
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // Login (POST)
        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            var user = Users.FirstOrDefault(u => u.Email == email && u.PasswordHash == password);

            if (user != null)
            {
                // Stochează email-ul în sesiune
                HttpContext.Session.SetString("UserEmail", user.Email);
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Email sau parola greșită.");
            return View();
        }

        // Logout
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("UserEmail");
            return RedirectToAction("Index", "Home");
        }
    }
}