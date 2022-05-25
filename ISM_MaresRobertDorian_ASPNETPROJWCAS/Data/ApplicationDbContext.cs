using ISM_MaresRobertDorian_ASPNETPROJWCAS.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ISM_MaresRobertDorian_ASPNETPROJWCAS.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Review>? Reviews { get; set; }
        public DbSet<Game>? Games { get; set; }
    }
}