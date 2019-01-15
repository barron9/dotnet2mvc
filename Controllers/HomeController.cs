
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

using WebApplication3.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;

using System.Threading.Tasks;
using System.Security.Claims;
using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Authentication;

namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
        public object WebSecurity { get; private set; }

        [Authorize]
        [AutoValidateAntiforgeryToken]
        [HttpGet]
        public ObjectResult Index()
        {
            var isAuth = HttpContext.User.Identity.IsAuthenticated.ToString();
            var employee = new Human { id = 1, name = "home index" , isAuth = isAuth};
            return new ObjectResult(employee);
        }
        [HttpGet]
        public ViewResult Godaddy()
        {
            var employee = new Human { id = 2, name = "godaddy test" };

            return View(employee);
        }

        [HttpGet]
        public async Task<IActionResult> register( Human employee)
        {

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,employee.isAuth),
                new Claim(ClaimTypes.Name,employee.name),
                new Claim(ClaimTypes.NameIdentifier,employee.id.ToString(),ClaimValueTypes.Integer),

            };

            var identity = new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);
            var principles = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(principles);

            return RedirectToAction("Index","Home");
           // return (HttpContext.User.Identity.IsAuthenticated.ToString());
        }

   

        [HttpGet]
        [Authorize]
        public IActionResult userinfo()
        {

            return View();
        }



        public ViewResult Denied()
        {

            return View();
        }
    }
}
