using Microsoft.AspNetCore.Identity;

namespace BlogApp.API.Services
{
    public class SeedDataService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public SeedDataService(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task SeedAsync()
        {
            await SeedRolesAsync();
            await SeedSuperAdminUserAsync();
            await SeedAdminUserAsync();
        }

        private async Task SeedRolesAsync()
        {
            var roles = new[] { "SuperAdmin", "Admin", "Creator", "Viewer" };

            foreach (var role in roles)
            {
                if (!await _roleManager.RoleExistsAsync(role))
                {
                    await _roleManager.CreateAsync(new IdentityRole(role));
                }
            }
        }

        private async Task SeedSuperAdminUserAsync()
        {
            var superAdminEmail = "ad.blogspace@gmail.com";
            var superAdminPassword = "BlogSpaceAdmin@123!";

            var adminUser = await _userManager.FindByEmailAsync(superAdminEmail);

            if (adminUser == null)
            {
                adminUser = new IdentityUser
                {
                    UserName = "Super_Admin",
                    Email = superAdminEmail,
                    EmailConfirmed = true
                };

                var result = await _userManager.CreateAsync(adminUser, superAdminPassword);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(adminUser, "SuperAdmin");
                }
            }
        }

        private async Task SeedAdminUserAsync()
        {
            var adminEmail = "nareshbizresearch@gmail.com";
            var adminPassword = "BlogSpaceAdmin@234!";

            var adminUser = await _userManager.FindByEmailAsync(adminEmail);

            if (adminUser == null)
            {
                adminUser = new IdentityUser
                {
                    UserName = "Admin_User",
                    Email = adminEmail,
                    EmailConfirmed = true
                };

                var result = await _userManager.CreateAsync(adminUser, adminPassword);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(adminUser, "Admin");
                }
            }
        }
    }
}
