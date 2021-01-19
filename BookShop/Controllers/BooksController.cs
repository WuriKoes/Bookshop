using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using BookShop.Data;
using BookShop.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Controllers
{    
    public class BooksController : BaseApiController
    {
        private readonly DataContext _context;
        public BooksController(DataContext context)
        {
            _context = context;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetUsersAsync()
        {
            return await _context.Books.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetUserAsync(int id)
        {

            return await _context.Books.FindAsync(id);
        }

        [HttpPost("{add}")]
        public async Task<ActionResult<Book>> AddBook(string author, string title, string description, 
                                        string category, string genre, string code)
        {
            using var hmac = new HMACSHA512();

            var book = new Book()
            {
              Author = author,
              Title = title,
              Description = description,
              Category = category,
              Genre = genre,
              BookCodeHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(code)),
              BookCodeSalt = hmac.Key
            };

            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            return book;
        }

        public async Task<int> DeleteBook(int? id)
        {
            int result = 0;

            if (_context != null)
            {
                var book = await _context.Books.FirstOrDefaultAsync(x => x.Id == id);

                if (book != null)
                {
                    _context.Books.Remove(book);
                    result = await _context.SaveChangesAsync();
                }
                return result;
            }

            return result;
        }


        public async Task UpdateBook(Book book)
        {
            if (_context != null)
            {
                _context.Books.Update(book);

                await _context.SaveChangesAsync();
            }
        }
    }
}