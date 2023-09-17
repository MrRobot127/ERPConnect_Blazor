using ERPConnect.Web.Data;
using ERPConnect.Web.Interface;
using ERPConnect.Web.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Syncfusion.Blazor;

namespace ERPConnect.Web
{
    public static class ServiceCollectionExtension
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("IdentityDbContextConnection") ?? throw new InvalidOperationException("Connection string 'IdentityDbContextConnection' not found.");

            services.AddDbContext<IdentityDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<IdentityDbContext>();

            services.AddAuthentication("Identity.Application").AddCookie();

            services.AddSyncfusionBlazor();
           
            // Add services to the container.
            services.AddRazorPages();
            services.AddServerSideBlazor();

            // Get the base URL from appsettings.json
            var baseUrl = configuration.GetValue<string>("BaseUrl");

            if (string.IsNullOrEmpty(baseUrl))
            {
                throw new InvalidOperationException("Base URL 'BaseUrl' not found in appsettings.json.");
            }

            var baseAddress = new Uri(baseUrl);

            services.AddHttpClient<ICompanyGroupService, CompanyGroupService>(client =>
            {
                client.BaseAddress = baseAddress;
            });

            services.AddHttpClient<IMenuService, MenuService>(client =>
            {
                client.BaseAddress = baseAddress;
            });
        }
    }
}
