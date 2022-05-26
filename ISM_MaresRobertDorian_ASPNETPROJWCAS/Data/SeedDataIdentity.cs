using Microsoft.AspNetCore.Identity;

namespace ISM_MaresRobertDorian_ASPNETPROJWCAS.Data
{
    public class SeedDataIdentity
    {
        private const string adminEmail = "admin@mail.com";
        private const string password = "Qwerty1234!";
    
        public static async Task EnsurePopulatedAsync(IApplicationBuilder app)
        {
            var serviceProvider = app.ApplicationServices.CreateScope().ServiceProvider;
            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

            IdentityUser user = await userManager.FindByEmailAsync(adminEmail);

            if(user == null)
            {
                user = new IdentityUser
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    EmailConfirmed = true
                };
                await userManager.CreateAsync(user, password);
            }

            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            string roleName = "ADMIN_ROLE";

            if(!await roleManager.RoleExistsAsync(roleName))
            {
                await roleManager.CreateAsync(new IdentityRole(roleName));
            }

            var gameMasterAdminEmail = "gameAdmin@mail.com";
            var gameMasterAdmin = await userManager.FindByEmailAsync(gameMasterAdminEmail);
            if(gameMasterAdmin == null)
            {
                gameMasterAdmin = new IdentityUser
                {
                    UserName = gameMasterAdminEmail,
                    Email = gameMasterAdminEmail,
                    EmailConfirmed = true
                };

                await userManager.CreateAsync(gameMasterAdmin, password);
                await userManager.AddToRoleAsync(gameMasterAdmin, roleName);
            }
        }
    }
}
