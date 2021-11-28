using CrudDemo.Data.Services;
using CrudDemo.Data.Services.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CrudDemo.Data
{
    public static class ServiceCollectionMapper
    {
        public static IServiceCollection AddDemoData(this IServiceCollection services, IConfiguration configuration)
        {
            return services
                .AddDbContext<DemoDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("CrudDemoConn")))
                .AddScoped<IEmployeeRepository, EmployeeRepository>()
                .AddScoped<IProjectRepository, ProjectRepository>()
                .AddScoped<ICrudDataService, CrudDataService>();
        }
    }
}
