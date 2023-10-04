using Jazani.Application.Admins.Services.Implementations;
using Jazani.Application.Admins.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Jazani.Application.Generals.Services;
using Jazani.Application.Generals.Services.Implementations;

namespace Jazani.Application.Cores.Contexts
{
    public static class ApplicationServicesRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddTransient<IOfficeService, OfficeService>();

            services.AddTransient<IMineralTypeService, MineralTypeService>();

            return services;
        }
    }
}
