using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public class HumanDBContext : DbContext
    {

        public DbSet<Human> Human { get; set; }

        public HumanDBContext(DbContextOptions<HumanDBContext>options) :base (options){

        }
        /*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Human>().HasData(
                new Human (1,"username","testtime","dbtesttoken")
                );
        }
        */
        //entitts

        


        

    }
}
