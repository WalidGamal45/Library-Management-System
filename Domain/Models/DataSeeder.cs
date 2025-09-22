// Data/DataSeeder.cs
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public static class DataSeeder
{
    public static async Task SeedRolesAndAdminAsync(IServiceProvider services, IConfiguration config)
    {
        var roleMgr = services.GetRequiredService<RoleManager<IdentityRole>>();
        var userMgr = services.GetRequiredService<UserManager<ApplicationUser>>();

        string[] roles = new[] { "Administrator", "Librarian", "Staff" };
        foreach (var r in roles) if (!await roleMgr.RoleExistsAsync(r)) await roleMgr.CreateAsync(new IdentityRole(r));

        var adminEmail = config["Seed:AdminEmail"] ?? "admin@library.local";
        var admin = await userMgr.FindByEmailAsync(adminEmail);
        if (admin == null)
        {
            admin = new ApplicationUser { UserName = "admin", Email = adminEmail, FullName = "System Admin", EmailConfirmed = true };
            var result = await userMgr.CreateAsync(admin, config["Seed:AdminPassword"] ?? "Admin@123");
            if (result.Succeeded) await userMgr.AddToRoleAsync(admin, "Administrator");
        }
    }
}
