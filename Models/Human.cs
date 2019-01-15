using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public class Human
    {
        public Human() { }
        public Human(int id, string name, string expires, string token)
        {
            this.id = id;
            this.name = name;
            this.expires = expires;
            this.token = token;
        }

        public int id { get; set; }
        public String name { get; set; }
        public String expires { get; set; }
        public String token { get; set; }

    }
}
