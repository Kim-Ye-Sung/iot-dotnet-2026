using BookRentalShopApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookRentalShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookRentalShopContext _context;

        public BooksController(BookRentalShopContext context)
        {
            _context = context;
        }

        // GET: api/books
        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            var books = await _context.Books.ToListAsync();
            return Ok(books);
        }

        // GET: api/books/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBook(int id)
        {
            var book = await _context.Books
                .FirstOrDefaultAsync(x => x.BookIdx == id);

            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        // POST: api/books
        [HttpPost]
        public async Task<IActionResult> CreateBook(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBook), new { id = book.BookIdx }, book);
        }

        // PUT: api/books/1
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, Book book)
        {
            if (id != book.BookIdx)
            {
                return BadRequest();
            }

            _context.Entry(book).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/books/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var book = await _context.Books
                .FirstOrDefaultAsync(x => x.BookIdx == id);

            if (book == null)
            {
                return NotFound();
            }

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}