using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CoffeeAPI.Data;
using CoffeeAPI.Models;

namespace CoffeeAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CoffeeController : ControllerBase
{
    private readonly AppDbContext _db;

    public CoffeeController(AppDbContext db)
    {
        _db = db;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var coffees = await _db.Coffees
            .Include(c => c.Type)
            .Include(c => c.CoffeeIngredients)
            .ThenInclude(ci => ci.Ingredient)
            .ToListAsync();

        return Ok(coffees);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var coffee = await _db.Coffees
            .Include(c => c.Type)
            .Include(c => c.CoffeeIngredients)
            .ThenInclude(ci => ci.Ingredient)
            .FirstOrDefaultAsync(c => c.Id == id);

        return coffee is null ? NotFound() : Ok(coffee);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Coffee coffee)
    {
        _db.Coffees.Add(coffee);
        await _db.SaveChangesAsync();
        return CreatedAtAction(nameof(Get), new { id = coffee.Id }, coffee);
    }
}