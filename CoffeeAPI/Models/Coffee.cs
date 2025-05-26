namespace CoffeeAPI.Models
{
    public class Coffee
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string? ImageUrl { get; set; }

        public int TypeId { get; set; }
        public CoffeeType Type { get; set; } = null!;
        
        public ICollection<CoffeeIngredient> CoffeeIngredients { get; set; } = new List<CoffeeIngredient>();
    }
}