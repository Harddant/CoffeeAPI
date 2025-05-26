namespace CoffeeAPI.Models
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public ICollection<CoffeeIngredient> CoffeeIngredients { get; set; } = new List<CoffeeIngredient>();
    }
}