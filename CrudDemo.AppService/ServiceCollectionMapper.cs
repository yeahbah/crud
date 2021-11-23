using System;
using Microsoft.Extensions.DependencyInjection;
using CrudDemo.Data;
using MediatR;
using FluentValidation;
using CrudDemo.App.PipelineBehaviors;
using Microsoft.Extensions.Configuration;

namespace CrudDemo.App
{
    public static class ServiceCollectionMapper
    {
        public static IServiceCollection AddAppServices(this IServiceCollection services, IConfiguration configuration)
        {
            return services                
                .AddDemoData(configuration)
                .AddMediatR(typeof(ServiceCollectionMapper).Assembly)
                .AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>))
                .AddValidatorsFromAssembly(typeof(ServiceCollectionMapper).Assembly)
                .AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}
