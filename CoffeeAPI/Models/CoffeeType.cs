namespace CoffeeAPI.Models;

public class CoffeeType
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public ICollection<Coffee> Coffees { get; set; } = new List<Coffee>();
}