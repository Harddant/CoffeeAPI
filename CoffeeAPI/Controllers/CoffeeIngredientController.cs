using CoffeeAPI.Data;
using CoffeeAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoffeeAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CoffeeIngredientController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CoffeeIngredientController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CoffeeIngredient>>> GetAll()
        {
            return await _context.CoffeeIngredients
                .Include(ci => ci.Coffee)
                .Include(ci => ci.Ingredient)
                .ToListAsync();
        }
    }
}