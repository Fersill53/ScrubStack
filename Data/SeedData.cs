using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ScrubStack.Data.Models;

namespace ScrubStack.Data
{
    public static class SeedData
    {
        public static async Task InitializeAsync(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
            var context = serviceProvider.GetRequiredService<ApplicationDbContext>();

            // Seed roles
            string[] roles = { "Admin", "Staff", "Viewer" };

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            // Seed default admin
            var adminEmail = "admin@scrubstack.local"; // Change before deploy
            var adminPassword = "Admin123";             // Change before deploy

            var adminUser = await userManager.FindByEmailAsync(adminEmail);
            if (adminUser == null)
            {
                adminUser = new IdentityUser { UserName = adminEmail, Email = adminEmail, EmailConfirmed = true };
                var result = await userManager.CreateAsync(adminUser, adminPassword);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, "Admin");
                }
            }

            // ✅ Seed Instrument Sets
            if (!await context.InstrumentSets.AnyAsync())
            {
                var sets = new List<InstrumentSet>
                {
                    new() { SetName = "Basic Ortho Set" },
                    new() { SetName = "Major Tray" },
                    new() { SetName = "Hand and Foot Tray" },
                    new() { SetName = "Hip Tray" }
                };

                context.InstrumentSets.AddRange(sets);
                await context.SaveChangesAsync();
            }
        }
    }
}
