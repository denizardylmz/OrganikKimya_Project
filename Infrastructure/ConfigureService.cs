using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class ConfigureService
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var serviceVersion = new MySqlServerVersion(new Version(8, 0, 30));

        services.AddDbContext<IdentityAppDb>(options =>
            options.UseMySql(configuration.GetConnectionString("DefaultConnection"),
                serviceVersion));

        services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<IdentityAppDb>();
        services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<IdentityAppDb>());



        return services;
    } 
}