using bookapi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookapi.Repository
{
    public class BookRepository : IBook
    {


        private readonly BookContext _context;
        public BookRepository(BookContext context)
        {
            _context = context;
        }

        public async  Task<string> GetBookbyId(int Id)
        {
            var name = await _context.Books.Where(c => c.Id == Id).Select(n => n.Title).FirstOrDefaultAsync();
            return name;
        }

        public async Task<Book> GetBookDetails(int Id)
        {
            var emp = await _context.Books.FirstOrDefaultAsync(c => c.Id == Id);
            return emp;
        }

    }
}
