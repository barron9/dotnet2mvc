using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public class Human
    {
        public Human(int id) { }
        public Human(int id, string name, string isAuth, string token)
        {
            this.id = id;
            this.name = name;
            this.isAuth = isAuth;
            this.token = token;
        }

        public int id { get; set; }
        public String name { get; set; }
        public String isAuth { get; set; }
        public String token { get; set; }

    }
}
