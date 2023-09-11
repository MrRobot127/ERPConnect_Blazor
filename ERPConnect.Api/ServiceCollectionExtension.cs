using ERPConnect.Api.Interface;
using ERPConnect.Api.Models;
using ERPConnect.Api.Repositories;
using Microsoft.EntityFrameworkCore;
using System;

namespace ERPConnect.Api
{
    public static class ServiceCollectionExtension
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextPool<AppDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DBConnection")));
            services.AddControllers();

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IMasterEntryRepository, MasterEntryRepository>();
        }
    }
}
