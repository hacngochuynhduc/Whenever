using Microsoft.AspNetCore.Identity;
using Whenever.Infrastruture.Data;
using Whenver.Base.Entities;

namespace Whenever.Dashboard;

public static class RoleSeeder
{
    public static async Task SeedRolesAndProfilesAsync(RoleManager<Role> roleManager, UserManager<User> userManager,
        ApplicationDbContext dbContext)
    {
        await SeedRolesAsync(roleManager);
        await SeedUsersAsync(userManager, dbContext);
    }

    private static async Task SeedRolesAsync(RoleManager<Role> roleManager)
    {
        var roleNames = new [] {"SystemAdmin","Admin", "User"};
        foreach (var roleName in roleNames)
            if(!await roleManager.RoleExistsAsync(roleName))
                    await  roleManager.CreateAsync(new Role { Name = roleName, NormalizedName = roleName.ToUpper() });
    }

    private static async Task SeedUsersAsync(UserManager<User> userManager, ApplicationDbContext dbContext)
    {
        // --- Seed SystemAdmin User ---
        if (await userManager.FindByEmailAsync("admin@example.com") == null)
        {
            var adminUser = new User
            {
                UserName = "admin@example.com",
                Email = "admin@example.com",
                FirstName = "System",
                LastName = "Admin",
                EmailConfirmed = true
            };
            await userManager.CreateAsync(adminUser, "Admin@123");
            await userManager.AddToRoleAsync(adminUser, "SystemAdmin");
        }

        // --- Seed EndUser ---
        if (await userManager.FindByEmailAsync("user@example.com") == null)
        {
            var endUser = new User
            {
                UserName = "user@example.com",
                Email = "user@example.com",
                FirstName = "Normal",
                LastName = "User",
                EmailConfirmed = true
            };
            await userManager.CreateAsync(endUser, "User@123");
            await userManager.AddToRoleAsync(endUser, "User");
        }

    }
}