using HS_APP_1.Models;
using Microsoft.AspNetCore.Mvc;

namespace HS_APP_1.Controllers
{
    public class AccountController:Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel model) {
            if (model.Username == "admin" && model.Password == "123")
            {
                // Create Session and store user
                HttpContext.Session.SetString("User", model.Username);

                // Redirect to Homepage
                return RedirectToAction("Index", "Home");
            }

            // If username or password is incorrect then error
            ViewBag.Error = "Invalid Psername or Password";
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
