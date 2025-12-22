using Microsoft.AspNetCore.Mvc;
using DZ4_5.Models;

namespace DZ4_5.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    private static List<Book> books = new List<Book>
    {
        new Book { Id = 1, Title = "Book One", Author = "Author A", Year = 1999 },
        new Book { Id = 2, Title = "Book Two", Author = "Author B", Year = 2005 },
        new Book { Id = 3, Title = "Book Three", Author = "Author C", Year = 2015 }
    };

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(books);
    }

    [HttpGet("{id:int}")]
    public IActionResult GetById(int id)
    {
        var book = books.FirstOrDefault(b => b.Id == id);
        if (book == null)
            return NotFound("Book not found");
        return Ok(book);
    }

    [HttpGet("search")]
    public IActionResult Search([FromQuery] string title, [FromQuery] string? author)
    {
        if (string.IsNullOrWhiteSpace(title))
            return BadRequest("Parameter 'title' is required");

        var results = books
            .Where(b => b.Title.Contains(title, System.StringComparison.OrdinalIgnoreCase));

        if (!string.IsNullOrWhiteSpace(author))
            results = results.Where(b => b.Author.Contains(author, System.StringComparison.OrdinalIgnoreCase));

        return Ok(results.ToList());
    }

    [HttpPost]
    public IActionResult Create([FromBody] Book book)
    {
        if (string.IsNullOrWhiteSpace(book.Title) || string.IsNullOrWhiteSpace(book.Author))
            return BadRequest("Title and Author are required");
        if (book.Year < 1800)
            return BadRequest("Year must be >= 1800");

        var newId = books.Max(b => b.Id) + 1;
        book.Id = newId;
        books.Add(book);

        return CreatedAtAction(nameof(GetById), new { id = book.Id }, book);
    }

    [HttpPut("{id:int}")]
    public IActionResult Update(int id, [FromBody] Book book)
    {
        var existing = books.FirstOrDefault(b => b.Id == id);
        if (existing == null)
            return NotFound("Book not found");

        if (string.IsNullOrWhiteSpace(book.Title) || string.IsNullOrWhiteSpace(book.Author))
            return BadRequest("Title and Author are required");
        if (book.Year < 1800)
            return BadRequest("Year must be >= 1800");

        existing.Title = book.Title;
        existing.Author = book.Author;
        existing.Year = book.Year;

        return Ok(existing);
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        var existing = books.FirstOrDefault(b => b.Id == id);
        if (existing == null)
            return NotFound("Book not found");

        books.Remove(existing);
        return NoContent();
    }
}