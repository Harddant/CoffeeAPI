using CoffeeAPI.Models;

namespace CoffeeAPI.Data.Seeders
{
    public static class CoffeeTypeSeeder
    {
        public static CoffeeType[] Seed(AppDbContext context)
        {
            if (context.CoffeeTypes.Any()) return Array.Empty<CoffeeType>();

            var types = new[]
            {
                new CoffeeType { Name = "Hot" },
                new CoffeeType { Name = "Iced" },
                new CoffeeType { Name = "Espresso" },
                new CoffeeType { Name = "Latte" },
            };

            context.CoffeeTypes.AddRange(types);
            return types;
        }
    }
}