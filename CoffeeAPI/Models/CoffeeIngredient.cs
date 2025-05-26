
namespace CoffeeAPI.Models
{
    public class CoffeeIngredient
    {
        public int CoffeeId { get; set; }
        public Coffee Coffee { get; set; } = null!;

        public int IngredientId { get; set; }
        public Ingredient Ingredient { get; set; } = null!;
    }
}