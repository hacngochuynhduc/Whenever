using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Whenever.Infrastruture.Data;
using Whenver.Base.Entities;

namespace Whenever.Infrastruture;

public static class IdentityDependencies
{
    public static IServiceCollection AddDbContextService<TContext>(this IServiceCollection services)
     where TContext :  DbContext
    {
        if(services ==null)
            throw new ArgumentNullException(nameof(services));

        services.AddIdentity<User, Role>(options =>
            {
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = false;
            })
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();
        return services;
    }
}