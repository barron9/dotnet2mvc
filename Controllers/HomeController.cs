
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;


namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
        public ObjectResult Index()
        {
            var employee = new Human { id = 1, name = "test 333" };
            return new ObjectResult(employee);
        }
        [HttpGet]
        public ViewResult Godaddy()
        {
            var employee = new Human { id = 1, name = "Mark Upston" };

            return View(employee);
        }

        [HttpGet]
        public JsonResult register( Human employee)
        {

            return Json(employee);
        }

        public ViewResult Denied()
        {

            return View();
        }
    }
}
