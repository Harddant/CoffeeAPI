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
            var coffeeTypes = new[]
            {
                new CoffeeType { Name = "Hot" },
                new CoffeeType { Name = "Iced" },
                new CoffeeType { Name = "Espresso" },
                new CoffeeType { Name = "Latte" },
            };

            context.CoffeeTypes.AddRange(coffeeTypes);

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
                "https://i.imgur.com/pE0dCfL.jpeg",
                coffeeTypes[0],
                espressoShot
            );

            AddCoffeeWithIngredients(
                context,
                "Vanilla Latte",
                "Sweet and milky",
                "",
                coffeeTypes[1],
                espressoShot, milk, vanilla
            );

            AddCoffeeWithIngredients(
                context,
                "Iced Caramel Latte",
                "Chilled and sweet",
                "https://i.imgur.com/QKWOtg9.jpeg",
                coffeeTypes[1],
                espressoShot, milk, caramel, ice
            );

            AddCoffeeWithIngredients(
                context,
                "Sweet Espresso",
                "With sugar kick",
                "",
                coffeeTypes[2],
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
