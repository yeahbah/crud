using Crud.Authentication.IdentityAuth;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Crud.Authentication.DbContext;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}

internal class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var dbUser = Environment.GetEnvironmentVariable("SQLUSER");
        var dbPasswd = Environment.GetEnvironmentVariable("SQLPASSWD");
        var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
        builder.UseSqlServer($"Server=tcp:127.0.0.1,1433;Database=CrudDemoSecurityDb;Trusted_Connection=true;integrated security=false;User Id={dbUser};password={dbPasswd}");
        
        return new ApplicationDbContext(builder.Options);
    }
}