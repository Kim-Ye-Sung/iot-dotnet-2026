using BookRentalShopApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookRentalShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly BookRentalShopContext _context;

        public MembersController(BookRentalShopContext context)
        {
            _context = context;
        }

        // GET: api/members
        [HttpGet]
        public async Task<IActionResult> GetMembers()
        {
            var members = await _context.Members.ToListAsync();
            return Ok(members);
        }

        // GET: api/members/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMember(int id)
        {
            var member = await _context.Members
                .FirstOrDefaultAsync(x => x.MemberIdx == id);

            if (member == null)
            {
                return NotFound();
            }

            return Ok(member);
        }
    }
}