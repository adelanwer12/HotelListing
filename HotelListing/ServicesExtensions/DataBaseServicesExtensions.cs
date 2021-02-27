using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelListing.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HotelListing.ServicesExtensions
{
    public static class DataBaseServicesExtensions
    {
        public static IServiceCollection AddDataBaseServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<DatabaseContext>(opt =>
            {
                opt.UseSqlServer(config.GetConnectionString("Default"));
            });
            services.AddDbContext<IdentityContext>(opt =>
            {
                opt.UseSqlServer(config.GetConnectionString("Identity"));
            });
            return services;
        }
    }
}
