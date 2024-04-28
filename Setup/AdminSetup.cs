using Loqui.Models;
using Microsoft.AspNetCore.Identity;

public class AdminSetup
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public AdminSetup(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task SeedAdminAsync()
    {
        if (!await _roleManager.RoleExistsAsync("Admin"))
        {
            var adminRole = new IdentityRole { Name = "Admin" };
            await _roleManager.CreateAsync(adminRole);
        }

        var defaultAdmin = await _userManager.FindByNameAsync("admin");
        if (defaultAdmin == null)
        {
            defaultAdmin = new ApplicationUser { UserName = "admin" };
            var seed = await _userManager.CreateAsync(defaultAdmin, "StrongPassword");

            if (seed.Succeeded)
            {
                await _userManager.AddToRoleAsync(defaultAdmin, "Admin");
            }

            else
            {
                Console.WriteLine("failed to add default admin");
            }
        }
    }
}
