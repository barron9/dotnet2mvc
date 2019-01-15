using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication3.Controllers
{
    public class PhoneController : Controller
    {
        public String Index()
        {
        
            return "phone";
        }
        public string Phone()
        {
            return "+49-333-3333333";
        }
        public string Country()
        {
            return "Germany";
        }
    }
}