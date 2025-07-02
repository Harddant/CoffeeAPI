using CoffeeAPI.Models;

namespace CoffeeAPI.Data.Seeders
{
    public static class CoffeeOfTheDaySeeder
    {
        public static void Seed(AppDbContext context)
        {
            if (context.CoffeeOfTheDay.Any()) return;

            var coffeeOfTheDay = context.Coffees.FirstOrDefault(c => c.Name == "Iced Caramel Latte");

            if (coffeeOfTheDay != null)
            {
                context.CoffeeOfTheDay.Add(new CoffeeOfTheDay
                {
                    Coffee = coffeeOfTheDay,
                    Date = DateTime.Today
                });
            }
        }
    }
}