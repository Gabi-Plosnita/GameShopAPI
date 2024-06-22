using GameShop.EntityLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameShop.DataAccess.DataContext
{
    public class GameShopDbContext : DbContext
    {
        public DbSet<Game> Games { get; set; }

        public DbSet<GameCompany> GameCompanies { get; set; }

        public DbSet<Category> Categories { get; set; }

        public GameShopDbContext(DbContextOptions<GameShopDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Game //
            modelBuilder.Entity<Game>()
                .HasOne(g => g.GameCompany)
                .WithMany(gc => gc.Games)
                .HasForeignKey(g => g.GameCompanyId);

            modelBuilder.Entity<Game>()
                .HasOne(g => g.Category)
                .WithMany(c => c.Games)
                .HasForeignKey(g => g.CategoryId);

        }
    }
}
