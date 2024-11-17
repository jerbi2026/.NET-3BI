using Microsoft.EntityFrameworkCore;
using WebApp.Models;
namespace WebApp
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Ajoutez vos DbSet pour chaque entité dans votre modèle
        public DbSet<Product> Products { get; set; }
    }
}
