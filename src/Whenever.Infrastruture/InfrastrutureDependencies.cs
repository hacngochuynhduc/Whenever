using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Whenever.Infrastruture.Extension;
using Whenever.Infrastruture.Manager;

namespace Whenever.Infrastruture;

public static class InfrastrutureDependencies
{
    public static IServiceCollection AddUnitOfWorkService<TContext>(this IServiceCollection services)
        where TContext : DbContext
    {
        if(services == null)
            throw new ArgumentNullException(nameof(services));
        services.AddScoped<IRepositoryExtension, UnitOfWork<TContext>>();
        services.AddScoped<IUnitOfWork, UnitOfWork<TContext>>();
        services.AddScoped<IUnitOfWork<TContext>, UnitOfWork<TContext>>();
        return services;
    }
    
}