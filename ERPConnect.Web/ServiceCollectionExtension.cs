﻿using ERPConnect.Web.Data;
using ERPConnect.Web.Interface;
using ERPConnect.Web.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ERPConnect.Web
{
    public static class ServiceCollectionExtension
    {
        public static void RegisterServices(this IServiceCollection services,IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DBConnection") ?? throw new InvalidOperationException("Connection string 'DBConnection' not found.");

            services.AddDbContext<IdentityDbContext>(options => options.UseSqlServer(connectionString));

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<IdentityDbContext>();

            services.AddAuthentication("Identity.Application").AddCookie();
            services.AddRazorPages();
            services.AddServerSideBlazor();

            services.AddHttpClient<ICompanyGroupService, CompanyGroupService>(client =>
            {
                client.BaseAddress = new Uri("https://localhost:7165/");
            });
        }
    }
}
