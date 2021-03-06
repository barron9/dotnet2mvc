﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using WebApplication3.Models;
using WebApplication3.Services;

namespace WebApplication3.Controllers
{

    public class ApiController : Controller
    {
        private readonly HumanDBContext _db;


        private IUserService _userService;

        // users hardcoded for simplicity, store in a db with hashed passwords in production applications
        public static List<Human> _humans = new List<Human>
        {
        };


        public ApiController(IUserService userService, HumanDBContext db)
        {
            _db = db;
            _userService = userService;
        }



        [Authorize]
        [AutoValidateAntiforgeryToken]
        [HttpGet]
        public ObjectResult Index()
        {
            var name = HttpContext.Session.GetString("auth");
            return (new ObjectResult(_humans));
        }
        [HttpGet]
        public JsonResult Godaddy()
        {

            foreach (var Human in _db.Human)
            {
                //Console.WriteLine(Human.token);
                _humans.Add(Human);
            }
            return Json(_humans);
        }
        [HttpGet]
        public ViewResult Do()
        {

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> login(String username, String password)
        {

            try
            {
                // var authheader= Request.Headers["Authorization"];
                /*
                var userheader = Request.Headers["Username"];
                var passheader = Request.Headers["Password"];
                var grantheader = Request.Headers["grant_type"];
                if (string.IsNullOrEmpty(userheader) || string.IsNullOrEmpty(passheader) || string.IsNullOrEmpty(grantheader) || grantheader != "password"
                    //  || string.IsNullOrEmpty(authheader)
                    )
                {
                    throw new Exception("AUTH NOT SET");
                   // return null;
                }
                */
                /*
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,userheader),
                new Claim(ClaimTypes.NameIdentifier,grantheader),

            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principles = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(principles);

    */
                var tokenHandler = new JwtSecurityTokenHandler();

                TripleDESCryptoServiceProvider TDES = new TripleDESCryptoServiceProvider();
                TDES.GenerateIV();
                TDES.GenerateKey();
                var key = Encoding.ASCII.GetBytes("THIS IS USED TO SIGN AND VERIFY JWT TOKENS, REPLACE IT WITH YOUR OWN SECRET, IT CAN BE ANY STRING");

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim(ClaimTypes.Name,username.ToString())
                    }),
                    Expires = DateTime.UtcNow.AddMinutes(30),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
                };
                var token1 = tokenHandler.CreateToken(tokenDescriptor);

                var token2 = tokenHandler.WriteToken(token1);
                // var zaman = DateTime.UtcNow.AddMinutes(30);
                var zaman = DateTimeOffset.UtcNow.AddMinutes(30).ToUnixTimeSeconds();

                var employeex = new Human(0, username, password, zaman.ToString(), token2);
                //_humanContext.Add(employeex);

                //var varmi = _db.Human.FirstOrDefault(b => b.name == username && b.password == password);
                var varmi = _db.Human.Where(b => b.name == username && b.password == password)
                               .Count();
                if (varmi < 1)
                {
                    //return Json(new { result = "check your login", status = "error" });
                    return RedirectToAction("Denied","Api");

                }
                else if (varmi == 1)
                {

                    var result = _db.Human.SingleOrDefault(b => b.name == username && b.password == password);
                    result.token = token2;
                    result.expires = zaman.ToString();
                    _db.SaveChanges();
                    return Json(new { expire = zaman.ToString(), token = token2 });

                }
                else
                {
                    _db.Add(employeex);
                    _db.SaveChanges();
                    return Json(new { expire = zaman.ToString(), token = token2 });

                }




                /*
                if (varmi < 1)
                {


                } else if (varmi ==1 && entity!=null) {
                    entity.token = token2;
                    entity.expires = zaman.ToString();
                    _db.Update(entity);
                    _db.SaveChanges();
                    return Json(new { expire = zaman.ToString(), token = token2 });

                }
                else
                {

                    _db.Add(employeex);
                    _db.SaveChanges();
                    // return Json((employeex));
                    return Json(new { expire = zaman.ToString(), token = token2 });
                }
                */
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());

            }
            // return RedirectToAction("Index", "Home");
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
