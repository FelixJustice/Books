using Books.Context;
using Books.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Books.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BooksContext _dbContext;

        public BooksController(BooksContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetBooks(string? author, long? year, string? publisher)
        {
            try
            {
                var books = _dbContext.Books.AsQueryable();

                if (author != null) books = books.Where(b => b.Author == author);

                if (year != null) books = books.Where(b => b.Year == year);

                if (publisher != null) books = books.Where(b => b.Publisher == publisher);

                return Ok(books.ToList());
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error. Contact the IT department.");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetBook(string id)
        {
            try
            {
                // Check that the id of the book that we want to get is a valid long value.
                if (!long.TryParse(id, out var bookId)) return NotFound(new { message = $"{id} is not a valid number" });

                // Looks for the book by the id and if it does not find any by the id default value is null.
                var result = _dbContext.Books.FirstOrDefault(b => b.Id == bookId);

                if (result == null) return NotFound(new {message = $"Book with id: {id} does not exist in our database"});

                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error. Contact the IT department.");
            }
        }

        [HttpPost]
        public IActionResult PostBook(Book book)
        {
            try
            {
                // We first check that we have values in those properties that is required in posted Book object.
                if(book.Title.Trim().Length == 0) return BadRequest("Titles value can't be empty.");
                if(book.Author.Trim().Length == 0) return BadRequest("Author value can't be empty.");
                if(book.Publisher != null && book.Publisher.Trim().Length == 0) return BadRequest("Publisher it can't be empty.");
                if (book.Year == 0) return BadRequest("Year is either missing or value can't be 0");

                // We then check of this books existence and if not found it returns false.
                var exists = _dbContext.Books.Any(b =>
                    b.Title == book.Title && b.Author == book.Author && b.Year == book.Year);

                if (exists) return BadRequest("Book you wanted to add already exists.");

                _dbContext.Add(book);
                _dbContext.SaveChanges();

                return Ok(new { book.Id });
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error. Contact the IT department.");
            }
            
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(string id)
        {
            try
            {
                // We check tha the requested delete id is a long value.
                if (!long.TryParse(id, out var bookId)) return NotFound(new { message = $"{id} is not a valid number" });

                // We then check of this books existence with the id and if not found default will be returned which is null.
                var result = _dbContext.Books.FirstOrDefault(b => b.Id == bookId);

                if (result == null) return NotFound(new { message = $"Book with id: {id} does not exist in our database" });

                _dbContext.Books.Remove(result);
                _dbContext.SaveChanges();

                return StatusCode(204);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error. Contact the IT department.");
            }
        }
    }
}
