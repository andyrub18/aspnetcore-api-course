using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_books.Data.Services;
using my_books.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        public BookService _bookService;
        public BooksController(BookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet("books")]
        public IActionResult GetAllBooks()
        {
            var allBooks = _bookService.GetAllBooks();
            return Ok(allBooks);
        }

        [HttpGet("books/{id}")]
        public IActionResult GetBook(int id)
        {
            var book = _bookService.GetBook(id);
            return Ok(book);
        }

        [HttpPost("books")]
        public IActionResult AddBook([FromBody]BookVM book)
        {
            _bookService.AddBook(book);
            return Ok();
        }

        [HttpPut("books/{id}")]
        public IActionResult UpdateBook(int id, [FromBody]BookVM book)
        {
            var updateBook = _bookService.UpdateBook(id, book);
            return Ok(updateBook);
        }

        [HttpDelete("books/{id}")]
        public IActionResult DeleteBook(int id)
        {
            _bookService.DeleteBook(id);
            return Ok();
        }
    }
}
