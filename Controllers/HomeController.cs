using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;


namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
        public ObjectResult Index()
        {
            var employee = new Human { id = 1, name = "Mark Upston" };
            return new ObjectResult(employee);
            //return "home controller";
        }

        public ViewResult Godaddy() {
            var employee = new Human { id = 1, name = "Mark Upston" };

            return View(employee);
        }
    }
}
