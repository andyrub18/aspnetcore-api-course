using my_books.Data.Models;
using my_books.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_books.Data.Services
{
    public class AuthorService
    {
        private AppDbContext _context;

        public AuthorService(AppDbContext context)
        {
            _context = context;
        }

        public void AddAuthor(AuthorVM author)
        {
            var _author = new Author()
            {
                FullName = author.FullName
            };

            _context.Authors.Add(_author);
            _context.SaveChanges();
        }

        public AuthorWithBooksVM GetAuthor(int authorId)
        {
            var _authour = _context.Authors.Where(n => n.Id == authorId).Select(author => new AuthorWithBooksVM()
            {
                FullName = author.FullName,
                BookTitles = author.Book_Authors.Select(n => n.Book.Title).ToList()
            }).FirstOrDefault();

            return _authour;
        }
    }
}
