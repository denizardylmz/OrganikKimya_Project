using System.Reflection;
using Application.Common.Behaviours;
using Application.DTOs;
using Application.Identity.Validation;
using Application.Item.Commands.Validation;
using Application.Item.CreateItem;
using Application.Mappings;
using AutoMapper;
using FluentValidation;
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
        services.AddScoped<IValidator<CreateItemCommand>, CreateItemValidation>();
        services.AddScoped<IValidator<UserLogInRequest>, LogInValidation>();
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
    }
    
}