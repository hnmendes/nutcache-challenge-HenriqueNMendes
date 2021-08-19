using hr.Domain.Interfaces.Repositories;
using hr.Domain.Interfaces.Services;
using hr.Domain.Services;
using hr.Infra.Context;
using hr.Infra.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace hr.API.Config
{
    public static class DIConfig
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services)
        {
            services.AddScoped<HrDbContext>();
            services.AddScoped<IPeopleRepository, PeopleRepository>();
            services.AddScoped<IPeopleService, PeopleService>();

            return services;
        }
    }
}
