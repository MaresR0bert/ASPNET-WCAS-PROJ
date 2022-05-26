using Microsoft.AspNetCore.Identity;

namespace ISM_MaresRobertDorian_ASPNETPROJWCAS.Data
{
    public class ReviewUserSeed
    {
        private const string reviewerEmail = "reviewer@mail.com";
        private const string password = "Qwerty1234!";

        public static async Task EnsurePopulatedAsync(IApplicationBuilder app)
        {
            var serviceProvider = app.ApplicationServices.CreateScope().ServiceProvider;
            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            string roleName = "REVIEWER_ROLE";

            if (!await roleManager.RoleExistsAsync(roleName))
            {
                await roleManager.CreateAsync(new IdentityRole(roleName));
            }

            var reviewer = await userManager.FindByEmailAsync(reviewerEmail);
            if (reviewer == null)
            {
                reviewer = new IdentityUser
                {
                    UserName = reviewerEmail,
                    Email = reviewerEmail,
                    EmailConfirmed = true
                };

                await userManager.CreateAsync(reviewer, password);
                await userManager.AddToRoleAsync(reviewer, roleName);
            }
        }
    }
}
