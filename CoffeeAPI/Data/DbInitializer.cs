using CoffeeAPI.Models;

namespace CoffeeAPI.Data
{
    public static class DbInitializer
    {
        public static void Seed(AppDbContext context)
        {
            if (context.CoffeeTypes.Any() || context.Coffees.Any() || context.Ingredients.Any())
                return;

            // Coffee Types
            var espressoType = new CoffeeType { Name = "Espresso" };
            var latteType = new CoffeeType { Name = "Latte" };
            var icedType = new CoffeeType { Name = "Iced" };

            context.CoffeeTypes.AddRange(espressoType, latteType, icedType);

            // Ingredients
            var espressoShot = new Ingredient { Name = "Espresso Shot" };
            var milk = new Ingredient { Name = "Milk" };
            var vanilla = new Ingredient { Name = "Vanilla Syrup" };
            var caramel = new Ingredient { Name = "Caramel Syrup" };
            var ice = new Ingredient { Name = "Ice Cubes" };
            var sugar = new Ingredient { Name = "Sugar" };

            context.Ingredients.AddRange(espressoShot, milk, vanilla, caramel, ice, sugar);

            // Add coffees using helper method (replace these image URLs with yours from Imgur)
            AddCoffeeWithIngredients(
                context,
                "Classic Espresso",
                "Strong and small",
                "https://imgur.com/a/3gvY24M",
                espressoType,
                espressoShot
            );

            AddCoffeeWithIngredients(
                context,
                "Vanilla Latte",
                "Sweet and milky",
                "",
                latteType,
                espressoShot, milk, vanilla
            );

            AddCoffeeWithIngredients(
                context,
                "Iced Caramel Latte",
                "Chilled and sweet",
                "https://imgur.com/a/61PzNNG",
                icedType,
                espressoShot, milk, caramel, ice
            );

            AddCoffeeWithIngredients(
                context,
                "Sweet Espresso",
                "With sugar kick",
                "",
                espressoType,
                espressoShot, sugar
            );

            context.SaveChanges();

            // Coffee of the day
            var coffeeOfTheDay = context.Coffees.FirstOrDefault(c => c.Name == "Iced Caramel Latte");

            if (coffeeOfTheDay != null)
            {
                context.CoffeeOfTheDay.Add(new CoffeeOfTheDay
                {
                    Coffee = coffeeOfTheDay,
                    Date = DateTime.Today
                });

                context.SaveChanges();
            }
        }

        private static void AddCoffeeWithIngredients(
            AppDbContext context,
            string name,
            string description,
            string imageUrl,
            CoffeeType type,
            params Ingredient[] ingredients)
        {
            var coffee = new Coffee
            {
                Name = name,
                Description = description,
                ImageUrl = imageUrl,
                Type = type
            };

            context.Coffees.Add(coffee);

            foreach (var ingredient in ingredients)
            {
                context.CoffeeIngredients.Add(new CoffeeIngredient
                {
                    Coffee = coffee,
                    Ingredient = ingredient
                });
            }
        }
    }
}
