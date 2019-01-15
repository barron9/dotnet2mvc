using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public class ids
    {
        public ids() { }
        public ids(int id, string time)
        {
            this.id = id;
            this.time = time;
        
        }

        public int id { get; set; }

        private string time { get; set; }
    }
}
