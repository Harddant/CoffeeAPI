using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CoffeeAPI.Data;
using CoffeeAPI.Models;

[ApiController]
[Route("api/[controller]")]
public class CoffeeOfTheDayController : ControllerBase
{
    private readonly AppDbContext _context;

    public CoffeeOfTheDayController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CoffeeOfTheDay>>> GetCoffeeOfTheDay()
    {
        return await _context.CoffeeOfTheDay.Include(c => c.Coffee).ToListAsync();
    }
}