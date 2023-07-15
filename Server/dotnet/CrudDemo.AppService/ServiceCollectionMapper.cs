using CrudDemo.App.PipelineBehaviors;
using CrudDemo.Data;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;

namespace CrudDemo.App;

public static class ServiceCollectionMapper
{
    public static IServiceCollection AddAppServices(this IServiceCollection services, IConfiguration configuration)
    {
        return services
            .AddDemoData(configuration)
            //.AddMediatR(typeof(ServiceCollectionMapper).Assembly)
            .AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()))
            .AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>))
            .AddValidatorsFromAssembly(typeof(ServiceCollectionMapper).Assembly);
    }
}