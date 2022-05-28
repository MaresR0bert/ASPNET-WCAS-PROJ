using ISM_MaresRobertDorian_ASPNETPROJWCAS.Models;
using Microsoft.EntityFrameworkCore;

namespace ISM_MaresRobertDorian_ASPNETPROJWCAS.Data
{
    public class SeedGames
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

                if (context.Database.GetPendingMigrations().Any())
                {
                    context.Database.Migrate();
                }

                if (context != null && !context.Games.Any())
                {
                    context.Games.AddRange(new Game()
                    {
                        Name = "Half-Life",
                        Publisher = "Valve",
                        GameSize = 1,
                        ImgString = "https://cdn.cloudflare.steamstatic.com/steam/apps/70/capsule_616x353.jpg?t=1591048039",
                        ReleaseDate = DateTime.Now.AddDays(-365 * 23)
                    }, new Game()
                    {
                        Name = "Half-Life 2",
                        Publisher = "Valve CO",
                        GameSize = 2,
                        ImgString = "https://gepig.com/game_cover_460w/11.jpg",
                        ReleaseDate = DateTime.Now.AddDays(-365 * 21)
                    });
                }

                if (context != null) context.SaveChanges();
            }
        }
    
    }

}

