using CoffeeAPI.Data.Seeders;

namespace CoffeeAPI.Data
{
    public static class DbInitializer
    {
        public static void Seed(AppDbContext context)
        {
            var coffeeTypes = CoffeeTypeSeeder.Seed(context);
            var ingredients = IngredientSeeder.Seed(context);
            CoffeeSeeder.Seed(context, coffeeTypes, ingredients);
            context.SaveChanges();

            CoffeeOfTheDaySeeder.Seed(context);
            context.SaveChanges();
        }
    }
}