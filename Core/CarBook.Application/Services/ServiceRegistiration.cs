using Microsoft.Extensions.DependencyInjection;
using MediatR;

namespace CarBook.Application.Services
{
    public static class ServiceRegistiration
    {
        public static void SaveApplicationServices(
            this IServiceCollection services)
        {
            services.AddMediatR(typeof(ServiceRegistiration).Assembly);
        }
    }
}