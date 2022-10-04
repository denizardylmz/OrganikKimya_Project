using System.Reflection;
using Application.Mappings;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class ConfigureServices
{

    public static void AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());

        var mapperConfigurations = new MapperConfiguration(opt =>
            opt.AddProfile(new ItemProfile()));
        
        var mapper = mapperConfigurations.CreateMapper();
        
        services.AddSingleton(mapper);
    }
    
}