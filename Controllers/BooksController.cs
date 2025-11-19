using Contemporary_Programming_Final_Project.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookModel = Contemporary_Programming_Final_Project.Models.Books;

namespace Contemporary_Programming_Final_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BooksController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Books
        // Returns first 5 books, or a specific book by ISBN
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookModel>>> GetBooks(long? isbn)
        {
            if (!isbn.HasValue)
            {
                return await _context.Books.Take(5).ToListAsync();
            }

            var book = await _context.Books.FindAsync(isbn.Value);

            if (book == null)
            {
                return NotFound();
            }

            return new List<BookModel> { book };
        }

        // GET: api/Books/{isbn}
        [HttpGet("{isbn}")]
        public async Task<ActionResult<BookModel>> GetBookByISBN(long isbn)
        {
            var book = await _context.Books.FindAsync(isbn);

            if (book == null)
            {
                return NotFound();
            }

            return book;
        }

        // POST: api/Books
        [HttpPost]
        public async Task<ActionResult<BookModel>> PostBook(BookModel book)
        {
            if (book.ISBN == 0)
            {
                return BadRequest("ISBN is required");
            }

            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBookByISBN), new { isbn = book.ISBN }, book);
        }

        // PUT: api/Books/{isbn}
        [HttpPut("{isbn}")]
        public async Task<IActionResult> PutBook(long isbn, BookModel updatedBook)
        {
            if (isbn != updatedBook.ISBN)
            {
                return BadRequest();
            }

            _context.Entry(updatedBook).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(isbn))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Books/{isbn}
        [HttpDelete("{isbn}")]
        public async Task<IActionResult> DeleteBook(long isbn)
        {
            var book = await _context.Books.FindAsync(isbn);
            if (book == null)
            {
                return NotFound();
            }

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BookExists(long isbn)
        {
            return _context.Books.Any(e => e.ISBN == isbn);
        }
    }
}
