using Microsoft.EntityFrameworkCore;
using Tongue.Data.Access.Repositories;
using Tongue.Data.DbContexts;
using Tongue.Users.Services;

namespace Tongue.Web.Extensions;

public static class ServiceExtension
{
    public static void AddDependencyInjections(this IServiceCollection service)
    {
        // services
        service.AddScoped<IUserService, UserService>();
        
        // repositories
        service.AddScoped<IUserRepository, UserRepository>();
    }
    
    public static void AddDatabaseContexts(this IServiceCollection service, IConfiguration configuration)
    {
        service.AddDbContext<TonguePgDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("TonguePgDbConnection"));
        });
        service.AddScoped<DbContext>(provider => provider.GetService<TonguePgDbContext>()!);
    }
}
