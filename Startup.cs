﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.Cookies;
using WebApplication3.Services;
using WebApplication3.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApplication3
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        { services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options=> {
                options.LoginPath = "/api/do";
                options.AccessDeniedPath = "/api/denied";
            });
            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                // Set a short timeout for easy testing.
                options.IdleTimeout = TimeSpan.FromSeconds(10);
                options.Cookie.HttpOnly = true;
            });
            services.AddDbContext<HumanDBContext>(options => options.UseSqlServer(@"Data Source=(local);Initial Catalog=WebApplication3;Integrated Security=True",b=>b.UseRowNumberForPaging()));
            services.AddMvc();
            services.AddScoped<IUserService, UserService>();
         

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
         
             app.UseDeveloperExceptionPage();
            app.UseAuthentication();
            app.UseSession();

            app.UseMvc(ConfigureRoute);
            // app.UseWelcomePage();
            //app.UseDefaultFiles();
            //app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
            app.Run(async (context) =>
            {
               // throw new Exception("nothing found");
               await context.Response.WriteAsync("!");
            });


        }


        private void ConfigureRoute(IRouteBuilder routeBuilder)
        {
            //Api/Index 
            //routeBuilder.MapRoute("Default", "/api/do");
            routeBuilder.MapRoute("Default", "{controller=api}/{action=do}/{id?}");
        }
    }
}
