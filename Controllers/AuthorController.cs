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
    public class AuthorController : ControllerBase
    {
        private AuthorService _authorService;
        public AuthorController(AuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpPost("authors")]
        public IActionResult AddAuthor([FromBody] AuthorVM author)
        {
            _authorService.AddAuthor(author);
            return Ok();
        }

        [HttpGet("authors/{id}")]
        public IActionResult GetAuthor(int id)
        {
            var response = _authorService.GetAuthor(id);
            return Ok(response);
        }
    }
}
