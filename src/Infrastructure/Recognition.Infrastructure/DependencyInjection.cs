using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Protocols;
using Recognition.Application.Abstracts;
using Recognition.Application.Abstracts.Services;
using Recognition.Infrastructure.Services;
using Recognition.Presistance.Contexts;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recognition.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {   
            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseInMemoryDatabase("RecognitionDB")
                    ); ;
            }
            else
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(
                        configuration.GetConnectionString("DefaultConnection"),
                        b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName))

                    );
            }

            services.AddScoped<IApplicationDbContext>(provider => (IApplicationDbContext)provider!.GetService<ApplicationDbContext>());
            // services.AddScoped<IDomainEventService, DomainEventService>();
            services.AddTransient<IUploadService, UploadService>();
            services.AddScoped<IDomainEventService, DomainEventService>();
            return services;
        }
    }
}
