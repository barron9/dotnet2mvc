﻿
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
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;
using WebApplication3.Services;

namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {

        private IUserService _userService;

        // users hardcoded for simplicity, store in a db with hashed passwords in production applications
        public static List<Human> _humans = new List<Human>
        {
        };
        public static List<ids> _ids= new List<ids>{
        
        };

        public HomeController(IUserService userService)
        {
            _userService = userService;
        }



        [Authorize]
        [AutoValidateAntiforgeryToken]
        [HttpGet]
        public ObjectResult Index()
        {
            //var isAuth = HttpContext.User.Identity.IsAuthenticated.ToString();
            // var token = HttpContext.User.Identity.AuthenticationTy
            //var getall = _userService.GetAll();
            return new ObjectResult(_humans);
            //return View();
        }
        [HttpGet]
        public JsonResult Godaddy()
        {
         
            return Json(_humans);
        }
        [HttpGet]
        public ViewResult Do()
        {

            return View();
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
            var user = _userService.Authenticate(employee);

           
            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();

            TripleDESCryptoServiceProvider TDES = new TripleDESCryptoServiceProvider();
            TDES.GenerateIV();
             TDES.GenerateKey();
            var key = Encoding.ASCII.GetBytes("THIS IS USED TO SIGN AND VERIFY JWT TOKENS, REPLACE IT WITH YOUR OWN SECRET, IT CAN BE ANY STRING");

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, employee.name.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
           
            employee.token = tokenHandler.WriteToken(token);
            var employeex = new Human(employee.id, employee.name, "iptal", employee.token);
            _humans.Add(employeex);
            var zaman = DateTime.Now;
            _ids.Add(new ids(employee.id, zaman.ToString()));
            
           // _humans.Add(new Human(1,"asd","zxc","asdfr"));
            return RedirectToAction("Index","Home");
          // return (employee.token);
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
