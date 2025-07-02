using CoffeeAPI.Models;

namespace CoffeeAPI.Data.Seeders
{
    public static class CoffeeSeeder
    {
        public static void Seed(AppDbContext context, CoffeeType[] coffeeTypes, Ingredient[] ingredients)
        {
            if (context.Coffees.Any()) return;

            var espressoShot = ingredients.First(i => i.Name == "Espresso Shot");
            var milk = ingredients.First(i => i.Name == "Milk");
            var vanilla = ingredients.First(i => i.Name == "Vanilla Syrup");
            var caramel = ingredients.First(i => i.Name == "Caramel Syrup");
            var ice = ingredients.First(i => i.Name == "Ice Cubes");
            var sugar = ingredients.First(i => i.Name == "Sugar");

            AddCoffeeWithIngredients(context, "Classic Espresso", "Strong and small", "https://i.imgur.com/pE0dCfL.jpeg", coffeeTypes[0], espressoShot);
            AddCoffeeWithIngredients(context, "Vanilla Latte", "Sweet and milky", "", coffeeTypes[1], espressoShot, milk, vanilla);
            AddCoffeeWithIngredients(context, "Iced Caramel Latte", "Chilled and sweet", "https://i.imgur.com/QKWOtg9.jpeg", coffeeTypes[1], espressoShot, milk, caramel, ice);
            AddCoffeeWithIngredients(context, "Sweet Espresso", "With sugar kick", "", coffeeTypes[2], espressoShot, sugar);
        }

        private static void AddCoffeeWithIngredients(AppDbContext context, string name, string description, string imageUrl, CoffeeType type, params Ingredient[] ingredients)
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
