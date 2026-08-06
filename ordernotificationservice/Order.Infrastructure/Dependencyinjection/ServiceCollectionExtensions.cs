namespace Order.Infrastructure.Dependencyinjection
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Order.Application.Interfaces;
    using Order.Infrastructure.Data;
    using Order.Infrastructure.Messaging;
    using Order.Infrastructure.Repositories;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfratructure( this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<OrderDbContext>(options =>
            options.UseSqlite(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<INotificationPublisher, ConsoleNotificationPublisher>();

            return services;
        }
    }
}
