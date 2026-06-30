using BookRentalShopApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookRentalShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DivisionsController : ControllerBase
    {
        private readonly BookRentalShopContext _context;

        public DivisionsController(BookRentalShopContext context)
        {
            _context = context;
        }

        // GET: api/divisions
        [HttpGet]
        public async Task<IActionResult> GetDivisions()
        {
            var divisions = await _context.Divisions.ToListAsync();
            return Ok(divisions);
        }

        // GET: api/divisions/B001
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDivision(string id)
        {
            var division = await _context.Divisions
                .FirstOrDefaultAsync(x => x.DivCode == id);

            if (division == null)
            {
                return NotFound();
            }

            return Ok(division);
        }
    }
}