using CoffeeAPI.Models;

namespace CoffeeAPI.Data.Seeders
{
    public static class IngredientSeeder
    {
        public static Ingredient[] Seed(AppDbContext context)
        {
            if (context.Ingredients.Any()) return Array.Empty<Ingredient>();

            var ingredients = new[]
            {
                new Ingredient { Name = "Espresso Shot" },
                new Ingredient { Name = "Milk" },
                new Ingredient { Name = "Vanilla Syrup" },
                new Ingredient { Name = "Caramel Syrup" },
                new Ingredient { Name = "Ice Cubes" },
                new Ingredient { Name = "Sugar" },
            };

            context.Ingredients.AddRange(ingredients);
            return ingredients;
        }
    }
}