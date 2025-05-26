namespace CoffeeAPI.Models;

public class CoffeeOfTheDay
{
    public int Id { get; set; }
    public int CoffeeId { get; set; }
    public Coffee Coffee { get; set; } = null!;
    public DateTime Date { get; set; }
}