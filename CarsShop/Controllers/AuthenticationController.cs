using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CarsShop.Filters;
using CarsShop.Models;

namespace CarsShop.Controllers
{
    public class AuthenticationController : Controller
    {
        //Старые методы для одного слоя
        //[TestActionFilter]
        //public IActionResult Index()
        //{
        //    return View();
        //}

        //[HttpPost]
        ////[AllowAnonymous] - Allow anonymous users
        //public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View("Error");
        //    }

        //    var user = AuthenticateUser(loginViewModel.UserName);

        //    if (user == null)
        //    {
        //        return View("Error");
        //    }

        //    var claims = new List<Claim>
        //    {
        //        new(ClaimTypes.Name, loginViewModel.UserName),
        //        new("AnyTestValueIwantToAdd","123124"),
        //        new(ClaimTypes.Role,"Administrator")
        //    };


        //    var claimsIdentity = new ClaimsIdentity(
        //        claims, CookieAuthenticationDefaults.AuthenticationScheme);

        //    var authProperties = new AuthenticationProperties
        //    {

        //    };

        //    await HttpContext.SignInAsync(
        //        CookieAuthenticationDefaults.AuthenticationScheme,
        //        new ClaimsPrincipal(claimsIdentity),
        //        authProperties);

        //    return RedirectToAction("AuthorizedView");
        //}

        //[Authorize(Roles = "Administrator")]
        //public IActionResult AuthorizedView()
        //{
        //    return View();
        //}

        //[Authorize(Roles = "User")]
        //public IActionResult NotAuthorizedView()
        //{
        //    return View();
        //}

        //public IActionResult Forbidden()
        //{
        //    return View();
        //}

        //[HttpPost]
        //[Authorize]
        //public async Task<IActionResult> Logout()
        //{
        //    await HttpContext.SignOutAsync();
        //    return RedirectToAction("Index", "Home");
        //}

        //private UserViewModel? AuthenticateUser(string username)
        //{
        //    return UsersController.Get.FirstOrDefault(model => model.UserName.Equals(username));
        //}
    }
}
