using HS_APP_1.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using System.Security.Claims;

namespace HS_APP_1.Controllers
{
    public class AccountController:Controller
    {

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model) {
            if (model.Username == "admin" && model.Password == "123")
            {
                var claims = new List<Claim> { new Claim(ClaimTypes.Name, model.Username) };
                var identity = new ClaimsIdentity(claims, "MyCookiesAuth");
                var priciple = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync("MyCookiesAuth", priciple);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                // If username or password is incorrect then error
                ViewBag.Error = "Invalid Psername or Password";
                return View();
            }
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
