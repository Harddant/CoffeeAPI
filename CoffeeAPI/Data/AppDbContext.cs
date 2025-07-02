using CoffeeAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CoffeeAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Coffee> Coffees { get; set; }
        public DbSet<CoffeeType> CoffeeTypes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<CoffeeIngredient> CoffeeIngredients { get; set; }
        public DbSet<CoffeeOfTheDay> CoffeeOfTheDay { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Composite key for CoffeeIngredient
            modelBuilder.Entity<CoffeeIngredient>()
                .HasKey(ci => new { ci.CoffeeId, ci.IngredientId });

            // Relationships
            modelBuilder.Entity<CoffeeIngredient>()
                .HasOne(ci => ci.Coffee)
                .WithMany(c => c.CoffeeIngredients)
                .HasForeignKey(ci => ci.CoffeeId);

            modelBuilder.Entity<CoffeeIngredient>()
                .HasOne(ci => ci.Ingredient)
                .WithMany(i => i.CoffeeIngredients)
                .HasForeignKey(ci => ci.IngredientId);

            modelBuilder.Entity<CoffeeOfTheDay>()
                .HasOne(cotd => cotd.Coffee)
                .WithMany()
                .HasForeignKey(cotd => cotd.CoffeeId);
        }
    }
}