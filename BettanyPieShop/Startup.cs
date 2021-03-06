﻿using System;
using System.Net;
using BethanysPieShop.Factorys;
using BethanysPieShop.Hubs;
using BethanysPieShop.Interfaces.Factorys;
using BethanysPieShop.Interfaces.Models;
using BethanysPieShop.Interfaces.Services;
using BethanysPieShop.Models;
using BethanysPieShop.Models.Contexts;
using BethanysPieShop.Models.Repositorys;
using BethanysPieShop.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace BethanysPieShop
{
    public class Startup
    {
        public IConfiguration Configuration { get; }


        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(option =>
                option.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddTransient<IPieRepository, PieRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<ShoppingCart>(sp => ShoppingCart.GetCart(sp));
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();
            services.AddSingleton<ICoinMarketCapService, CoinMarketCapService>();
            services.AddSingleton<INationalBankOfRepublicBelarusServise, NationalBankOfRepublicBelarusServise>();
            services.AddTransient<ICurrencyConverterService, CurrencyConverterService>();
            services.AddTransient<IPieViewModelFactory, PieViewModelFactory>();

            services.AddMvc();
            services.AddMemoryCache();
            services.AddSession();
            services.AddSignalR();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseSession();
            app.UseAuthentication();
            app.UseSignalR(routes =>
            {
                routes.MapHub<ShoppingCartHub>("/ShoppingCartCount");
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "categoryfilter",
                    template: "Pie/{action}/{category?}",
                    defaults: new { Controller = "Pie", action = "List" });
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}