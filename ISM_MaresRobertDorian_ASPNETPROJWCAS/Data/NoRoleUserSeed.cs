using Microsoft.AspNetCore.Identity;

namespace ISM_MaresRobertDorian_ASPNETPROJWCAS.Data
{
    public class NoRoleUserSeed
    {
        private const string basicEmail = "joe@mail.com";
        private const string password = "Qwerty1234!";

        public static async Task EnsurePopulatedAsync(IApplicationBuilder app)
        {
            var serviceProvider = app.ApplicationServices.CreateScope().ServiceProvider;
            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

            IdentityUser user = await userManager.FindByEmailAsync(basicEmail);

            if (user == null)
            {
                user = new IdentityUser
                {
                    UserName = basicEmail,
                    Email = basicEmail,
                    EmailConfirmed = true
                };
                await userManager.CreateAsync(user, password);
            }
        }
    }
}
