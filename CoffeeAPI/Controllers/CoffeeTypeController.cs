using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CoffeeAPI.Data;
using CoffeeAPI.Models;

[ApiController]
[Route("api/[controller]")]
public class CoffeeTypeController : ControllerBase
{
    private readonly AppDbContext _context;

    public CoffeeTypeController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CoffeeType>>> GetCoffeeTypes()
    {
        return await _context.CoffeeTypes.ToListAsync();
    }
}