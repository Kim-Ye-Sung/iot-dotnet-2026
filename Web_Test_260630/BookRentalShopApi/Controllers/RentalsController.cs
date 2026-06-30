using BookRentalShopApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookRentalShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalsController : ControllerBase
    {
        private readonly BookRentalShopContext _context;

        public RentalsController(BookRentalShopContext context)
        {
            _context = context;
        }

        // GET: api/rentals
        [HttpGet]
        public async Task<IActionResult> GetRentals()
        {
            var rentals = await _context.Rentals.ToListAsync();
            return Ok(rentals);
        }

        // GET: api/rentals/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRental(int id)
        {
            var rental = await _context.Rentals
                .FirstOrDefaultAsync(x => x.RentalIdx == id);

            if (rental == null)
            {
                return NotFound();
            }

            return Ok(rental);
        }
    }
}